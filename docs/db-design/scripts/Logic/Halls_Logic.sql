USE [UniPlan];
GO

CREATE OR ALTER PROCEDURE SP_Halls_Insert
    @HallName nvarchar(50),
    @Building nvarchar(50),
    @Floor int,
    @CreatedByAdminID int,
    @HallID int out
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NULLIF(LTRIM(RTRIM(@HallName)), '') IS NULL
        THROW 50801, 'Hall validation failed', 1; 

    BEGIN TRY
        INSERT INTO [dbo].[Halls] ([HallName], [Building], [Floor] ,[CreatedByAdminID])
        VALUES (@HallName, @Building, @Floor, @CreatedByAdminID)
        
        SET @HallID = CONVERT(int, SCOPE_IDENTITY());
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_Halls_Update
    @HallName nvarchar(50),
    @Building nvarchar(50),
    @Floor int,
    @HallID int,
    @Result bit out 
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@HallName)), '') IS NULL OR @HallID <= 0
        THROW 50801, 'Hall validation failed', 1; 

    BEGIN TRY
     
        UPDATE [dbo].[Halls] SET [HallName] = @HallName
        ,[Building] = @Building ,[Floor] = @Floor
        WHERE HallID = @HallID;

        IF @@ROWCOUNT > 0
        BEGIN
            SET @Result = 1;
        END
        ELSE
        BEGIN
            SET @Result = 0;
        END
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_Halls_Delete
   @HallID INT, @Result BIT OUT 
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DELETE FROM [dbo].[Halls]
        WHERE HallID = @HallID;
        
        IF @@ROWCOUNT > 0
        BEGIN
            SET @Result = 1;
        END
        ELSE
        BEGIN
            SET @Result = 0;
        END
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_Halls_GetAll 
    @PageNumber INT = 1, 
    @PageSize INT = 10
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- CHANGED: Prevent invalid pagination values.
        IF @PageNumber IS NULL OR @PageNumber < 1
            SET @PageNumber = 1;

        -- CHANGED: Prevent invalid page size.
        IF @PageSize IS NULL OR @PageSize < 1
            SET @PageSize = 10;

        SELECT * FROM Halls
        ORDER BY [HallID]
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_Halls_GetById 
    @HallID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT * FROM Halls
        WHERE HallID = @HallID;
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO
