USE [UniPlan];
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
        ;THROW 50801, 'StudentCourse validation failed', 1;
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
        ;THROW 50801, 'StudentCourse validation failed', 1;
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












