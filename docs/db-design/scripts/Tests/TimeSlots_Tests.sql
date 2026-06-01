use UniPlan;
go




SET NOCOUNT ON;
PRINT '--- STARTING INSERT TEST ---';

BEGIN TRY
    -- 1. Create an isolated transaction sandbox
    BEGIN TRANSACTION; 

    Declare @DayNum int = 2;
	Declare @PeriodID int;
    DECLARE @SlotID int;
    Declare @StartTime Time = '23:00:00';
	Declare @EndTime Time = '23:30:00';

    INSERT INTO Periods(StartTime , EndTime)
    VALUES (@StartTime , @EndTime);

	set @PeriodID = CONVERT(int, SCOPE_IDENTITY());

    -- Act
    EXEC dbo.SP_TimeSlots_Insert
        @Day = @DayNum,
		@PeriodID = @PeriodID ,
		@SlotID = @SlotID out;

    -- Assert
    IF (EXISTS(SELECT 1 FROM TimeSlots WHERE SlotID = @SlotID And DayNum = @DayNum And PeriodID = @PeriodID))
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

	
    Declare @DayNum int = 2;
    DECLARE @SlotID int;

    INSERT INTO Periods(StartTime , EndTime)
    VALUES (@StartTime , @EndTime);

    DECLARE @PeriodID int = CONVERT(int, SCOPE_IDENTITY());

	insert into TimeSlots(DayNum , PeriodID)
	Values (@DayNum , @PeriodID);

	set @SlotID = Convert(int , SCOPE_IDENTITY());

	Declare @Result bit;

    -- Act
    EXEC dbo.SP_TimeSlots_Delete
        @SlotID = @SlotID ,
		@Result = @Result out;

    -- Assert
    IF (
        not EXISTS(SELECT 1 FROM TimeSlots WHERE SlotID = @SlotID)
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




SET NOCOUNT ON;
PRINT '--- STARTING UPDATE TEST ---';

BEGIN TRY
    -- 1. Create an isolated transaction sandbox
    BEGIN TRANSACTION;
	
	Declare @StartTime Time = '23:00:00';
	Declare @EndTime Time = '23:30:00';

	
    Declare @DayNum int = 2;
    DECLARE @SlotID int;
	Declare @NewDayNum int = 4;

    INSERT INTO Periods(StartTime , EndTime)
    VALUES (@StartTime , @EndTime);

    DECLARE @PeriodID int = CONVERT(int, SCOPE_IDENTITY());

	insert into TimeSlots(DayNum , PeriodID)
	Values (@DayNum , @PeriodID);

	set @SlotID = Convert(int , SCOPE_IDENTITY());
	Declare @Result bit;

    -- Act
    EXEC dbo.SP_TimeSlots_Update 
	      @Day = @NewDayNum , 
		  @PeriodID = @PeriodID ,
		  @SlotID = @SlotID ,
		  @Result = @Result out;

    -- Assert
    IF (
           Exists(select 1 from TimeSlots where SlotID = @SlotID And DayNum = @NewDayNum)
		   And 
		   Not Exists(select 1 from TimeSlots where SlotID = @SlotID And DayNum = @DayNum)
       ) And @Result = 1
    BEGIN
        PRINT '{ Update Procedure IS Working }';
    END
    ELSE
    BEGIN
        PRINT '{ *** Update Procedure IS * Not * Working *** }';
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

