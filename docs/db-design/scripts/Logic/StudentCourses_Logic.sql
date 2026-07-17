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

    BEGIN TRY
        UPDATE [dbo].[StudentCourses]
        SET
            IsPassed = @IsPassed
        WHERE EnrollmentID = @EnrollmentID;

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

    BEGIN TRY
        DELETE FROM [dbo].[StudentCourses]
        WHERE EnrollmentID = @EnrollmentID;

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




Create OR Alter Procedure SP_SyncPassedCourses
@PassedCoursesIDs CourseIdListType readonly ,
@StudentId int,
@Result bit out
As
Begin 
    SET NOCOUNT ON;

	if not Exists(select 1 from Students 
	where StudentID = @StudentId)
	Begin
        ;throw 50303, 'Student Dose Not Exist', 1;
	End

	IF EXISTS (
    SELECT 1 
    FROM @PassedCoursesIDs p
    LEFT JOIN dbo.Courses c ON p.CourseID = c.CourseID -- Replace c.CourseID with your actual primary key column name
    WHERE c.CourseID IS NULL)
    BEGIN
        ;THROW 50903, 'One or more provided Course IDs do not exist.', 1;
    END


	Begin Try
	    
		delete from StudentCourses 
		where StudentID = @StudentId;

		insert into StudentCourses (StudentID , CourseID , IsPassed)
		select distinct @StudentId , CourseID , 1 from @PassedCoursesIDs;

		set @Result = 1;
	End Try
	Begin Catch
	    set @Result = 0;
	    throw;
	End Catch
END

go


Create OR Alter Procedure SP_GetStudentOpenCourses
@StudentID int
As
Begin 
    if not Exists(select 1 from Students where StudentID = @StudentID)
	Begin 
	   ;throw 50303, 'Student Dose Not Exist', 1;
	End

	Begin try

	select Co.* from
	(
	   select c.* from Courses c
	   where c.CourseID not in (select CourseID from StudentCourses where StudentID = 1)
	) As Co
	where Co.CourseID not in (select CourseID from CoursePrerequisites) or Co.CourseID not in
	(
	   select CourseID from CoursePrerequisites cp
	   where PrerequisiteCourseID not in(select CourseID from StudentCourses where StudentID = 1)
	)

	End TRy
	Begin Catch
	  throw;
	End Catch
End
