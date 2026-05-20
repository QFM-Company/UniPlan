USE [UniPlan];
GO

CREATE OR ALTER PROCEDURE SP_TimeSlots_Insert
    @Days nvarchar(50),
    @SlotID int out
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@Days)), '') IS NULL
        THROW 50011, 'TimeSlot validation failed', 1; 

    BEGIN TRY
        INSERT INTO [dbo].[TimeSlots] ([Days])
        VALUES (@Days)
        
        SET @SlotID = CONVERT(int, SCOPE_IDENTITY());
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_TimeSlots_Update
    @Days nvarchar(50),
    @SlotID int,
    @Result bit out 
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@Days)), '') IS NULL OR @SlotID < 0
        THROW 50011, 'TimeSlot validation failed', 1; 

    BEGIN TRY
        UPDATE [dbo].[TimeSlots] 
        SET [Days] = @Days
        WHERE [SlotID] = @SlotID;

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

CREATE OR ALTER PROCEDURE SP_TimeSlots_Delete
   @SlotID INT, 
   @Result BIT OUT 
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DELETE FROM [dbo].[TimeSlots]
        WHERE SlotID = @SlotID;
        
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

CREATE OR ALTER PROCEDURE SP_TimeSlots_GetAll 
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

        SELECT * FROM TimeSlots
        ORDER BY [SlotID]
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO

-- (GetById)
CREATE OR ALTER PROCEDURE SP_TimeSlots_GetById 
    @SlotID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT * FROM TimeSlots
        WHERE SlotID = @SlotID;
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO
