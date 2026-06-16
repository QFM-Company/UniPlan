USE [UniPlan];
GO

CREATE OR ALTER PROCEDURE SP_Courses_Insert
    @CourseName NVARCHAR(100),
    @CreditHours INT,
    @MajorID INT,
    @CourseID INT OUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@CourseName)), '') IS NULL
        OR @CreditHours <= 0
        OR @MajorID <= 0
    BEGIN
        ;THROW 50801, 'Course validation failed', 1;
    END

    BEGIN TRY
        INSERT INTO [dbo].[Courses]
        (
            [CourseName],
            [CreditHours],
            [MajorID]
        )
        VALUES
        (
            @CourseName,
            @CreditHours,
            @MajorID
        );

        SET @CourseID = CONVERT(INT, SCOPE_IDENTITY());
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO


CREATE OR ALTER PROCEDURE SP_Courses_Update
    @CourseID INT,
    @CourseName NVARCHAR(100),
    @CreditHours INT,
    @MajorID INT,
    @Result BIT OUT
AS
BEGIN
    SET NOCOUNT ON;

    IF @CourseID <= 0
        OR NULLIF(LTRIM(RTRIM(@CourseName)), '') IS NULL
        OR @CreditHours <= 0
        OR @MajorID <= 0
    BEGIN
        ;THROW 50801, 'Course validation failed', 1;
    END

    BEGIN TRY
        UPDATE [dbo].[Courses]
        SET
            [CourseName] = @CourseName,
            [CreditHours] = @CreditHours,
            [MajorID] = @MajorID
        WHERE [CourseID] = @CourseID;

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


CREATE OR ALTER PROCEDURE SP_Courses_Delete
    @CourseID INT,
    @Result BIT OUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DELETE FROM [dbo].[Courses]
        WHERE [CourseID] = @CourseID;

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


CREATE OR ALTER PROCEDURE SP_Courses_GetAll
    @PageNumber INT = 1,
    @PageSize INT = 10
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF @PageNumber IS NULL OR @PageNumber < 1
            SET @PageNumber = 1;

        IF @PageSize IS NULL OR @PageSize < 1
            SET @PageSize = 10;

        SELECT
            C.CourseID,
            C.CourseName,
            C.CreditHours,
            C.MajorID ,
			Majors.MajorName
        FROM [dbo].[Courses] C  inner join Majors on C.MajorID = Majors.MajorID
        ORDER BY C.CourseID
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO




CREATE OR ALTER PROCEDURE SP_Courses_GetById
    @CourseID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT
            CourseID,
            CourseName,
            CreditHours,
            Courses.MajorID ,
			Majors.MajorName
        FROM [dbo].[Courses] inner join Majors on Courses.MajorID = Majors.MajorID
        WHERE CourseID = @CourseID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO