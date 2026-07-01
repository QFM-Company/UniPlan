USE [UniPlan];
GO

CREATE OR ALTER PROCEDURE SP_Courses_Insert
    @CourseName NVARCHAR(100),
    @CreditHours INT,
    @CourseID INT OUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@CourseName)), '') IS NULL
        OR @CreditHours <= 0
    BEGIN
        ;THROW 50901, 'Course validation failed', 1;
    END

    BEGIN TRY
        INSERT INTO [dbo].[Courses]
        (
            [CourseName],
            [CreditHours]
        )
        VALUES
        (
            @CourseName,
            @CreditHours
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
    @Result BIT OUT
AS
BEGIN
    SET NOCOUNT ON;

    IF @CourseID <= 0
        OR NULLIF(LTRIM(RTRIM(@CourseName)), '') IS NULL
        OR @CreditHours <= 0
    BEGIN
        ;THROW 50901, 'Course validation failed', 1;
    END

    BEGIN TRY
        UPDATE [dbo].[Courses]
        SET
            [CourseName] = @CourseName,
            [CreditHours] = @CreditHours
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


Create Or Alter View VW_Courses
AS
select * from Courses;
go


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

        SELECT * from VW_Courses
		order by CourseID
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
        SELECT * from VW_Courses
        WHERE CourseID = @CourseID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO