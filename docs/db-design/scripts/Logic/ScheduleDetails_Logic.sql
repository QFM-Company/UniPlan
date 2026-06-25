USE [UniPlan]
GO

IF EXISTS (SELECT * FROM sys.types WHERE name = 'IdListType')
BEGIN
    DROP TYPE IdListType;
END
GO

CREATE TYPE IdListType AS TABLE
(
    OfferingID INT
)
GO

CREATE OR ALTER PROCEDURE SP_ScheduleDetails_Insert
    @ScheduleID int,
    @OfferingIDs IdListType READONLY,
    @Result bit OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION
            
            INSERT INTO [dbo].[ScheduleDetails] ([ScheduleID] ,[OfferingID])
            SELECT DISTINCT @ScheduleID, OfferingID FROM @OfferingIDs;
            
        COMMIT;
        SET @Result = 1;
            
     END TRY
     BEGIN CATCH
        ROLLBACK;
        SET @Result = 0;
        -- CHANGED: THROW keeps the original error details.
        THROW;
     END CATCH

END;
GO
