USE [UniPlan];
GO

CREATE OR ALTER PROCEDURE SP_TimeSlots_Insert
    @Days nvarchar(50),
    @PeriodID int,
    @SlotID int out
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@Days)), '') IS NULL OR @PeriodID IS NULL OR @PeriodID <= 0
        THROW 50700, 'TimeSlot validation failed', 1; 

    BEGIN TRY
        INSERT INTO [dbo].[TimeSlots] ([DayNum], [PeriodID])
        VALUES (@Days, @PeriodID)
        
        SET @SlotID = CONVERT(int, SCOPE_IDENTITY());
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_TimeSlots_Update
    @Days nvarchar(50),
    @PeriodID int,
    @SlotID int,
    @Result bit out 
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@Days)), '') IS NULL OR @PeriodID IS NULL OR @PeriodID <= 0 OR @SlotID < 0
        THROW 50011, 'TimeSlot validation failed', 1; 

    BEGIN TRY
        UPDATE [dbo].[TimeSlots] 
        SET [DayNum] = @Days,
            [PeriodID] = @PeriodID
        WHERE [SlotID] = @SlotID;

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

CREATE OR ALTER PROCEDURE SP_TimeSlots_Delete
   @SlotID INT, 
   @Result BIT OUT 
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DELETE FROM [dbo].[TimeSlots]
        WHERE [SlotID] = @SlotID;
        
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

CREATE OR ALTER PROCEDURE SP_TimeSlots_GetAll 
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

        SELECT [SlotID], [DayNum], [PeriodID] 
        FROM [dbo].[TimeSlots]
        ORDER BY [SlotID]
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_TimeSlots_GetById 
    @SlotID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT [SlotID], [DayNum], [PeriodID] 
        FROM [dbo].[TimeSlots]
        WHERE [SlotID] = @SlotID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO
