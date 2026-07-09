USE [UniPlan];
GO

CREATE OR ALTER PROCEDURE SP_Halls_Validate
    @HallName nvarchar(50),
    @Building nvarchar(50) = NULL,
    @Floor int = NULL,
    @CreatedByAdminID int = NULL,
    @HallID int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@HallName)), N'') IS NULL
    BEGIN
        RETURN 50801;
    END

    ELSE IF @Floor IS NOT NULL AND @Floor < 0
    BEGIN
        RETURN 50801;
    END

    ELSE IF @CreatedByAdminID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [dbo].[Administrators] WHERE AdminID = @CreatedByAdminID)
    BEGIN
        RETURN 50203;
    END

    ELSE IF EXISTS (
        SELECT 1
        FROM [dbo].[Halls]
        WHERE [HallName] = @HallName
          AND (([Building] = @Building) OR ([Building] IS NULL AND @Building IS NULL))
          AND (@HallID IS NULL OR [HallID] != @HallID)
    )
    BEGIN
         RETURN 50802;
    END

    RETURN 0;
END;
GO

CREATE OR ALTER PROCEDURE SP_Halls_Insert
    @HallName nvarchar(50),
    @Building nvarchar(50) = NULL,
    @Floor int = NULL,
    @CreatedByAdminID int = NULL,
    @HallID int OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ErrCode int;

    EXEC @ErrCode = SP_Halls_Validate  @HallName, @Building, @Floor, @CreatedByAdminID, NULL;

    IF @ErrCode != 0
        THROW @ErrCode, '', 1;

    BEGIN TRY
        INSERT INTO [dbo].[Halls] ([HallName], [Building], [Floor], [CreatedByAdminID])
        VALUES (@HallName, @Building, @Floor, @CreatedByAdminID);

        SET @HallID = SCOPE_IDENTITY();
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_Halls_Update
    @HallID int,
    @HallName nvarchar(50),
    @Building nvarchar(50) = NULL,
    @Floor int = NULL,
    @Result bit OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SET @Result = 0;

    DECLARE @ErrCode int;

    EXEC @ErrCode = SP_Halls_Validate  @HallName, @Building, @Floor, NULL, @HallID;

    IF @ErrCode != 0
        THROW @ErrCode, '', 1;

    BEGIN TRY
        UPDATE [dbo].[Halls]
        SET [HallName] = @HallName,
            [Building] = @Building,
            [Floor] = @Floor
        WHERE HallID = @HallID;

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

CREATE OR ALTER PROCEDURE SP_Halls_Delete
    @HallID int,
    @Result bit OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SET @Result = 0;

    BEGIN TRY
        DELETE FROM [dbo].[Halls]
        WHERE HallID = @HallID;

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

CREATE OR ALTER PROCEDURE SP_Halls_GetAll
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

        SELECT * FROM [dbo].[Halls]
        ORDER BY [HallID]
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_Halls_GetById
    @HallID int
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT * FROM [dbo].[Halls]
        WHERE HallID = @HallID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO