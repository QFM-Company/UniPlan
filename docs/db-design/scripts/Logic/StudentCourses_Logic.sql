USE [UniPlan];
GO

DROP TYPE IF EXISTS CourseIdListType;
GO

CREATE TYPE CourseIdListType AS TABLE
(
    CourseID INT
)
GO

CREATE OR ALTER PROCEDURE SP_StudentCourses_Insert
    @StudentID INT,
    @CourseID INT,
    @IsPassed BIT = 0,
    @EnrollmentID INT OUT
AS
BEGIN
    SET NOCOUNT ON;

    IF @StudentID <= 0
        OR @CourseID <= 0
    BEGIN
        ;THROW 51501, 'StudentCourse validation failed', 1;
    END

	-- ****** I should Add Logic to check if the student able to take this subject (prequist , hours , major) (Fares)


    BEGIN TRY
        INSERT INTO [dbo].[StudentCourses]
        (
            StudentID,
            CourseID,
            IsPassed
        )
        VALUES
        (
            @StudentID,
            @CourseID,
            @IsPassed
        );

        SET @EnrollmentID = CONVERT(INT, SCOPE_IDENTITY());

		if(@IsPassed = 1)
		   update Students
	    	set CompletedHours = CompletedHours + (select c.CreditHours from Courses c where c.CourseID = @CourseID)
	    	where StudentID = @StudentID
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO


CREATE OR ALTER PROCEDURE SP_StudentCourses_Update
    @EnrollmentID INT,
    @IsPassed BIT,
    @Result BIT OUT
AS
BEGIN
    SET NOCOUNT ON;

    IF @EnrollmentID <= 0
    BEGIN
        ;THROW 51501, 'StudentCourse validation failed', 1;
    END

	Declare @OldPassed int;

	select @OldPassed = IsPassed from StudentCourses where EnrollmentID = @EnrollmentID;

	Declare @CourseID int;

	select @CourseID = CourseID from StudentCourses where EnrollmentID = @EnrollmentID;

	Declare @StudentID int;

	select @StudentID = StudentCourses.StudentID from StudentCourses where EnrollmentID = @EnrollmentID;

    BEGIN TRY
        UPDATE [dbo].[StudentCourses]
        SET
            IsPassed = @IsPassed
        WHERE EnrollmentID = @EnrollmentID;

		if(@OldPassed = 1 And @IsPassed = 0)
		   update Students
	    	set CompletedHours = CompletedHours - (select c.CreditHours from Courses c where c.CourseID = @CourseID)
	    	where StudentID = @StudentID

		if(@OldPassed = 0 And @IsPassed = 1)
		   update Students
	    	set CompletedHours = CompletedHours + (select c.CreditHours from Courses c where c.CourseID = @CourseID)
	    	where StudentID = @StudentID

        IF @@ROWCOUNT > 0
            SET @Result = 1;
        ELSE
            SET @Result = 0;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO


CREATE OR ALTER PROCEDURE SP_StudentCourses_Delete
    @EnrollmentID INT,
    @Result BIT OUT
AS
BEGIN
    SET NOCOUNT ON;

	Declare @OldPassed int;

	select @OldPassed = IsPassed from StudentCourses where EnrollmentID = @EnrollmentID;

	Declare @CourseID int;

	select @CourseID = CourseID from StudentCourses where EnrollmentID = @EnrollmentID;

	Declare @StudentID int;

	select @StudentID = StudentCourses.StudentID from StudentCourses where EnrollmentID = @EnrollmentID;


    BEGIN TRY
        DELETE FROM [dbo].[StudentCourses]
        WHERE EnrollmentID = @EnrollmentID;

		if(@OldPassed = 1)
		 update Students
	    	set CompletedHours = CompletedHours - (select c.CreditHours from Courses c where c.CourseID = @CourseID)
	    	where StudentID = @StudentID

        IF @@ROWCOUNT > 0
            SET @Result = 1;
        ELSE
            SET @Result = 0;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO


USE [UniPlan];
GO

CREATE OR ALTER VIEW VW_StudentCourses
AS
SELECT
    SC.CourseID,
	SC.IsPassed ,
    C.CourseName,
    C.CreditHours,
	C.CourseCode,
	SC.EnrollmentID ,
	SC.StudentID
FROM dbo.StudentCourses SC
    INNER JOIN dbo.Courses C
        ON SC.CourseID = C.CourseID;
GO


CREATE OR ALTER PROCEDURE SP_StudentCourses_GetById
    @EnrollmentID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM VW_StudentCourses
    WHERE EnrollmentID = @EnrollmentID;
END;
GO



CREATE OR ALTER PROCEDURE SP_StudentCourses_GetByStudentId
    @StudentID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM VW_StudentCourses
    WHERE StudentID = @StudentID;
END;
GO



CREATE OR ALTER PROCEDURE SP_SyncPassedCourses
    @PassedCoursesIDs CourseIdListType READONLY,
    @StudentId INT,
    @Result BIT OUT
AS
BEGIN
    SET NOCOUNT ON;

    -- التحقق من وجود الطالب
    IF NOT EXISTS (SELECT 1 FROM Students WHERE StudentID = @StudentId)
    BEGIN
        ;THROW 50303, 'Student Does Not Exist', 1;
    END

    -- التحقق من صحة المقررات المُمررة
    IF EXISTS (
        SELECT 1
        FROM @PassedCoursesIDs p
        LEFT JOIN Courses c ON p.CourseID = c.CourseID
        WHERE c.CourseID IS NULL
    )
    BEGIN
        ;THROW 50903, 'One or more provided Course IDs do not exist.', 1;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        -- حذف جميع مقررات الطالب السابقة (تمهيداً لإعادة تعيين الناجح منها)
        DELETE FROM StudentCourses
        WHERE StudentID = @StudentId;

		update Students
		set CompletedHours = 0
		where StudentID = @StudentId;

        -- تعريف متغيرات الحلقة
        DECLARE @CurrentCourseID INT;
        DECLARE @EnrollmentID INT; -- متغير خرج (لن نستخدمه)

        DECLARE course_cursor CURSOR LOCAL FAST_FORWARD FOR
            SELECT DISTINCT CourseID FROM @PassedCoursesIDs;

        OPEN course_cursor;
        FETCH NEXT FROM course_cursor INTO @CurrentCourseID;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- استدعاء إجراء الإدراج لكل مقرر مع IsPassed = 1
            EXEC SP_StudentCourses_Insert
                @StudentID = @StudentId,
                @CourseID = @CurrentCourseID,
                @IsPassed = 1,
                @EnrollmentID = @EnrollmentID OUTPUT;  -- يمكن تجاهل القيمة المُرجعة

            FETCH NEXT FROM course_cursor INTO @CurrentCourseID;
        END

        CLOSE course_cursor;
        DEALLOCATE course_cursor;

        -- نجاح العملية بالكامل
        SET @Result = 1;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- فشل في إدراج أحد المقررات
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @Result = 0;

        -- إعادة رمي الخطأ ليظهر للمُستدعي
        THROW;
    END CATCH
END
GO

Create OR Alter Procedure SP_GetStudentOpenCourses
@StudentID int
As
Begin 
    if not Exists(select 1 from Students where StudentID = @StudentID)
	Begin 
	   ;throw 50303, 'Student Dose Not Exist', 1;
	End

	Begin try

	Declare @StudentMajorID int;

	select @StudentMajorID = s.MajorID from Students s where StudentID = @StudentID;

     Declare @CompletedHours int;

	 select @CompletedHours = CompletedHours from Students where StudentID = @StudentID;

	   -- CTE للحصول على جميع التخصصات الأم بالإضافة إلى تخصص الطالب
        WITH MajorHierarchy AS (
            -- نقطة البداية: تخصص الطالب نفسه
            SELECT MajorID, ParentMajorID
            FROM Majors
            WHERE MajorID = @StudentMajorID

            UNION ALL

            -- الصعود إلى الأب
            SELECT m.MajorID, m.ParentMajorID
            FROM Majors m
            INNER JOIN MajorHierarchy mh ON m.MajorID = mh.ParentMajorID
        )


	-- ***** Make sure if he ended 4 subjects of متطلبات الكلية then don't return the others and 2 subjects of متطلبات الجامعة too (Fares)

	select Co.* from
	(
	   select c.* from Courses c
	   where (c.CourseID not in (select CourseID from StudentCourses where StudentID = @StudentID) 
	   AND c.CourseID IN (
               SELECT mc.CourseID
               FROM MajorCourses mc
               WHERE mc.MajorID IN (SELECT MajorID FROM MajorHierarchy)
       ))
	   And c.NeededHours <= @CompletedHours
	) As Co
	where Co.CourseID not in (select CourseID from CoursePrerequisites) or Co.CourseID not in
	(
	   select CourseID from CoursePrerequisites cp
	   where PrerequisiteCourseID not in(select CourseID from StudentCourses where StudentID = @StudentID)
	)

	End TRy
	Begin Catch
	  throw;
	End Catch
End
go

