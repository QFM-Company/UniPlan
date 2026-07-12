USE [UniPlan];
GO

CREATE OR ALTER PROCEDURE SP_Majors_Validate
    @MajorName nvarchar(100),
    @ParentMajorID int = NULL,
    @MajorID int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@MajorName)), N'') IS NULL
        RETURN 50501;

    IF @ParentMajorID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [dbo].[Majors] WHERE MajorID = @ParentMajorID)
        RETURN 50503;

    IF @MajorID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [dbo].[Majors] WHERE MajorID = @MajorID)
        RETURN 50503;

    IF EXISTS (
        SELECT 1
        FROM [dbo].[Majors]
        WHERE MajorName = @MajorName
          AND (@MajorID IS NULL OR MajorID != @MajorID)
    )
        RETURN 50502;

    RETURN 0;
END;
GO

CREATE OR ALTER PROCEDURE SP_Majors_Insert
    @MajorName nvarchar(100),
    @ParentMajorID int = NULL,
    @MajorID int OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ErrCode int;

    EXEC @ErrCode = SP_Majors_Validate @MajorName, @ParentMajorID, NULL;

    IF @ErrCode != 0
        THROW @ErrCode, '', 1;

    BEGIN TRY
        INSERT INTO [dbo].[Majors] ([MajorName], [ParentMajorID])
        VALUES (@MajorName, @ParentMajorID);

        SET @MajorID = SCOPE_IDENTITY();
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_Majors_Update
    @MajorID int,
    @MajorName nvarchar(100),
    @ParentMajorID int = NULL,
    @Result bit OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SET @Result = 0;

    DECLARE @ErrCode int;

    EXEC @ErrCode = SP_Majors_Validate @MajorName, @ParentMajorID, @MajorID;

    IF @ErrCode != 0
        THROW @ErrCode, '', 1;

    BEGIN TRY
        UPDATE [dbo].[Majors]
        SET [MajorName] = @MajorName,
            [ParentMajorID] = @ParentMajorID
        WHERE MajorID = @MajorID;

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

CREATE OR ALTER PROCEDURE SP_Majors_Delete
    @MajorID int,
    @Result bit OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SET @Result = 0;

    IF NOT EXISTS (SELECT 1 FROM [dbo].[Majors] WHERE MajorID = @MajorID)
        THROW 50503, '', 1;

    IF EXISTS (SELECT 1 FROM [dbo].[Students] WHERE MajorID = @MajorID)
        THROW 50504, '', 1;

    IF EXISTS (SELECT 1 FROM [dbo].[MajorCourses] WHERE MajorID = @MajorID)
        THROW 50504, '', 1;

    BEGIN TRY
        DELETE FROM [dbo].[Majors]
        WHERE MajorID = @MajorID;

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

CREATE OR ALTER PROCEDURE SP_Majors_GetAll
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

        SELECT MajorID, MajorName, ParentMajorID
        FROM [dbo].[Majors]
        ORDER BY [MajorID]
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_Majors_GetById
    @MajorID int
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT MajorID, MajorName, ParentMajorID
        FROM [dbo].[Majors]
        WHERE MajorID = @MajorID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO