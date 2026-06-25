USE [UniPlan];
GO

CREATE OR ALTER PROCEDURE SP_GeneratedSchedules_Insert
    @WishListID int,
    @ScheduleID int OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO [dbo].[GeneratedSchedules] ([WishListID])
        VALUES (@WishListID);
        
        SET @ScheduleID = CONVERT(int, SCOPE_IDENTITY());
    END TRY
    BEGIN CATCH
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

