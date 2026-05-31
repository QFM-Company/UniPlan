use UniPlan;
go



SET NOCOUNT ON;
PRINT '--- STARTING INSERT TEST ---';

BEGIN TRY
    -- 1. Create an isolated transaction sandbox
    BEGIN TRANSACTION; 

    Declare @MajorName nvarchar(50) = LEFT(CAST(NEWID() AS nvarchar(50)), 8);
    DECLARE @MajorID int;

    -- Act
    EXEC dbo.SP_Majors_Insert
        @MajorName = @MajorName ,
		@MajorID = @MajorID out;

    -- Assert
    IF (EXISTS(SELECT 1 FROM Majors WHERE MajorID = @MajorID And MajorName = @MajorName))
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

    Declare @MajorName nvarchar(50) = LEFT(CAST(NEWID() AS nvarchar(50)), 8);
    DECLARE @MajorID int;
	Declare @Result bit;

    INSERT INTO Majors(MajorName)
    VALUES (@MajorName);

	set @MajorID = CONVERT(int , SCOPE_IDENTITY());


    -- Act
    EXEC dbo.SP_Majors_Delete
        @MajorID = @MajorID ,
		@Result = @Result out;

    -- Assert
    IF (
        not EXISTS(SELECT 1 FROM Majors WHERE MajorID = @MajorID)
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
	
    Declare @MajorName nvarchar(50) = LEFT(CAST(NEWID() AS nvarchar(50)), 8);
    DECLARE @MajorID int;
	Declare @Result bit;
	Declare @NewMajorName nvarchar(50) = LEFT(CAST(NEWID() AS nvarchar(50)), 8);

    INSERT INTO Majors(MajorName)
    VALUES (@MajorName);

	set @MajorID = CONVERT(int , SCOPE_IDENTITY());

    -- Act
    EXEC dbo.SP_Majors_Update
	      @MajorName = @NewMajorName ,
          @MajorID = @MajorID ,
		  @Result = @Result out;

    -- Assert
    IF (
           Exists(select 1 from Majors where MajorID = @MajorID And MajorName = @NewMajorName)
		   And 
		   Not Exists(select 1 from Majors where MajorID = @MajorID And MajorName = @MajorName)
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