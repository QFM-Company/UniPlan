use UniPlan;
go




SET NOCOUNT ON;
PRINT '--- STARTING INSERT TEST ---';

BEGIN TRY
    -- 1. Create an isolated transaction sandbox
    BEGIN TRANSACTION; 

    Declare @StartTime Time = '23:00:00';
	Declare @EndTime Time = '23:30:00';
    DECLARE @PeriodID int;

    -- Act
    EXEC dbo.SP_Period_Insert
        @StartTime = @StartTime ,
		@EndTime = @EndTime ,
		@PeriodID = @PeriodID out

    -- Assert
    IF (EXISTS(SELECT 1 FROM Periods WHERE PeriodID = @PeriodID And StartTime = @StartTime And EndTime = @EndTime))
    BEGIN
        PRINT '{ Insert Procedure IS Working }';
    END
    ELSE 
    BEGIN
        PRINT '{ *** Insert Procedure IS * Not * Working *** }';
    END

    -- Teardown: Unconditionally wipe the sandbox memory
    ROLLBACK TRANSACTION; 
    PRINT '--- TEST COMPLETE (Data Rolled Back) ---';

END TRY
BEGIN CATCH
    -- If any actual SQL error happens during the test, catch it safely
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;
        
    PRINT 'TEST FAILED WITH ENGINE ERROR:';
    PRINT ERROR_MESSAGE();
END CATCH;
GO










SET NOCOUNT ON;
PRINT '--- STARTING DELETE TEST ---';

BEGIN TRY
    -- 1. Create an isolated transaction sandbox
    BEGIN TRANSACTION;

	Declare @StartTime Time = '23:00:00';
	Declare @EndTime Time = '23:30:00';


    INSERT INTO Periods(StartTime , EndTime)
    VALUES (@StartTime , @EndTime);

    DECLARE @PeriodID int = CONVERT(int, SCOPE_IDENTITY());

    -- Act
    EXEC dbo.SP_Period_Delete
        @PeriodID = @PeriodID;

    -- Assert
    IF (
        not EXISTS(SELECT 1 FROM Periods WHERE PeriodID = @PeriodID)
       )
    BEGIN
        PRINT '{ Delete Procedure IS Working }';
    END
    ELSE
    BEGIN
        PRINT '{ *** Delete Procedure IS * Not * Working *** }';
    END

    -- Teardown: Unconditionally wipe the sandbox memory
    ROLLBACK TRANSACTION;
    PRINT '--- TEST COMPLETE (Data Rolled Back) ---';

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    PRINT 'TEST FAILED WITH ENGINE ERROR:';
    PRINT ERROR_MESSAGE();
END CATCH;
GO


