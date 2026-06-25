USE [UniPlan]
GO

CREATE OR ALTER PROCEDURE SP_WishLists_Insert
    @RegistrationID int,
    @WishListID int OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO [dbo].[WishLists] ([RegistrationID])
        VALUES (@RegistrationID);
        
        SET @WishListID = CONVERT(int, SCOPE_IDENTITY());
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_WishLists_Delete
    @WishListID int,
    @Result bit OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        DECLARE @ScheduleID INT;

        BEGIN TRANSACTION;
            DELETE FROM [dbo].[WishListItems]
            WHERE WishListID = @WishListID;

            SELECT @ScheduleID = ScheduleID FROM GeneratedSchedules
            WHERE WishListID = @WishListID;

            DELETE FROM [dbo].[ScheduleDetails]
            WHERE ScheduleID = @ScheduleID;
            
            DELETE FROM [dbo].[GeneratedSchedules]
            WHERE ScheduleID = @ScheduleID;

            DELETE FROM [dbo].[WishLists]
            WHERE WishListID = @WishListID;
        COMMIT;
        SET @Result = 1;
    END TRY
    BEGIN CATCH
        SET @Result = 0;
        ROLLBACK;
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH


END;
GO

CREATE OR ALTER VIEW WishLists_view
AS
    SELECT W.WishListID, ST.RegistrationID
    , SP.*, A.*
    FROM WishLists W
    JOIN StudentTerms ST ON ST.RegistrationID = W.RegistrationID
    JOIN StudentProfiles_view SP ON SP.StudentID = ST.StudentID
    JOIN AcademicTerms A ON A.TermID = ST.TermID;
GO

CREATE OR ALTER PROCEDURE SP_WishLists_GetByRegistrationID
    @RegistrationID int
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        
        SELECT * FROM WishLists_view
        WHERE RegistrationID = @RegistrationID;

    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_WishLists_GetById
    @WishListID int
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY

        SELECT * FROM WishLists_view
        WHERE WishListID = @WishListID;

    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO