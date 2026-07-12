USE UniPlan;
GO

CREATE OR ALTER PROCEDURE SP_Lectures_Validate
    @LectureType int,
    @DurationValue int,
    @CourseID int,
    @LectureID int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @LectureType IS NULL OR @LectureType <= 0
        RETURN 51401;

    IF @DurationValue IS NULL OR @DurationValue <= 0
        RETURN 51401;

    IF NOT EXISTS (SELECT 1 FROM [dbo].[Courses] WHERE CourseID = @CourseID)
        RETURN 50903;

    IF @LectureID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [dbo].[Lectures] WHERE LectureID = @LectureID)
        RETURN 51403;

    RETURN 0;
END;
GO

CREATE OR ALTER PROCEDURE SP_Lectures_Insert
    @LectureType int,
    @DurationValue int,
    @CourseID int,
    @LectureID int OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ErrCode int;

    EXEC @ErrCode = SP_Lectures_Validate @LectureType, @DurationValue, @CourseID, NULL;

    IF @ErrCode != 0
        THROW @ErrCode, '', 1;

    BEGIN TRY
        INSERT INTO [dbo].[Lectures] ([LectureType], [DurationValue], [CourseID])
        VALUES (@LectureType, @DurationValue, @CourseID);

        SET @LectureID = SCOPE_IDENTITY();
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_Lectures_Update
    @LectureID int,
    @LectureType int,
    @DurationValue int,
    @CourseID int,
    @Result bit OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SET @Result = 0;

    DECLARE @ErrCode int;

    EXEC @ErrCode = SP_Lectures_Validate @LectureType, @DurationValue, @CourseID, @LectureID;

    IF @ErrCode != 0
        THROW @ErrCode, '', 1;

    BEGIN TRY
        UPDATE [dbo].[Lectures]
        SET [LectureType] = @LectureType,
            [DurationValue] = @DurationValue,
            [CourseID] = @CourseID
        WHERE LectureID = @LectureID;

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

CREATE OR ALTER PROCEDURE SP_Lectures_Delete
    @LectureID int,
    @Result bit OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SET @Result = 0;

    IF NOT EXISTS (SELECT 1 FROM [dbo].[Lectures] WHERE LectureID = @LectureID)
        THROW 51403, '', 1;

    IF EXISTS (SELECT 1 FROM [dbo].[CourseOfferings] WHERE LectureID = @LectureID)
        THROW 51404, '', 1;

    BEGIN TRY
        DELETE FROM [dbo].[Lectures]
        WHERE LectureID = @LectureID;

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

CREATE OR ALTER VIEW Lectures_view
AS
SELECT C.*,
L.LectureID, L.DurationValue, L.LectureType
FROM Lectures L
INNER JOIN Courses C ON L.CourseID = C.CourseID
GO

CREATE OR ALTER PROCEDURE SP_Lectures_GetAll
    @PageNumber int = 1,
    @PageSize int = 10
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF @PageNumber IS NULL OR @PageNumber < 1
            SET @PageNumber = 1;

        IF @PageSize IS NULL OR @PageSize < 1
            SET @PageSize = 10;

        SELECT * FROM Lectures_view
        ORDER BY [LectureID]
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_Lectures_GetById
    @LectureID int
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT * FROM Lectures_view
        WHERE LectureID = @LectureID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO