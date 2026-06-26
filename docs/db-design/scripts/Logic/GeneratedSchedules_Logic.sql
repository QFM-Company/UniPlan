USE [UniPlan];
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

CREATE OR ALTER PROCEDURE SP_GeneratedSchedules_Insert
    @WishListID int,
    @OfferingIDs IdListType READONLY,
    @ScheduleID int OUTPUT,
    @Result bit OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION
            INSERT INTO [dbo].[GeneratedSchedules] ([WishListID])
            VALUES (@WishListID);
            
            SET @ScheduleID = CONVERT(int, SCOPE_IDENTITY());

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


CREATE OR ALTER VIEW GeneratedSchedules_view
AS
    SELECT G.ScheduleID, W.*
    FROM GeneratedSchedules G
    JOIN WishLists_view W ON G.WishListID = W.WishListID
GO


CREATE OR ALTER PROCEDURE SP_GeneratedSchedules_GetByWishListID
    @WishListID int
AS
BEGIN
    SET NOCOUNT ON
    
    DECLARE @ScheduleID INT;

    BEGIN TRY
        SELECT @ScheduleID = ScheduleID FROM GeneratedSchedules
        WHERE WishListID = @WishListID;

        SELECT * FROM GeneratedSchedules_view G
        WHERE ScheduleID = @ScheduleID;

        SELECT C.* FROM ScheduleDetails S
        JOIN CourseOfferings_view C ON C.OfferingID = S.OfferingID
        WHERE S.ScheduleID = @ScheduleID;
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH

END;
GO

