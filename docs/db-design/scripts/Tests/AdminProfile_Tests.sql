use UniPlan;
go




SET NOCOUNT ON;
PRINT '--- STARTING INSERT TEST ---';

BEGIN TRY
    -- 1. Create an isolated transaction sandbox
    BEGIN TRANSACTION; 

    -- Arrange: Generate unique data to prevent collision
    DECLARE @UniqueSuffix nvarchar(50) = LEFT(CAST(NEWID() AS nvarchar(50)), 8);
    DECLARE @TestEmail nvarchar(255) = 'test_' + @UniqueSuffix + '@gmail.com';
    DECLARE @TestAccount nvarchar(50) = 'acc_' + @UniqueSuffix;
    
    INSERT INTO People (FirstName, MiddleName, LastName)
    VALUES ('TestFirst', NULL, 'TestLast');
    
    DECLARE @PersonID int = SCOPE_IDENTITY();
    DECLARE @AdminID int;
    DECLARE @AccountID int;

    -- Act
    EXEC dbo.SP_AdminProfile_Insert 
        @IsActive = 1, 
        @PersonID = @PersonID, 
        @AdministratorID = @AdminID OUT, 
        @AccountName = @TestAccount, 
        @Password = 'securepass', 
        @Email = @TestEmail, 
        @AccountID = @AccountID OUT;

    -- Assert
    IF (EXISTS(SELECT 1 FROM People WHERE PersonID = @PersonID) 
        AND EXISTS(SELECT 1 FROM Accounts WHERE AccountID = @AccountID) 
        AND EXISTS(SELECT 1 FROM Administrators WHERE AdminID = @AdminID))
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

    -- Arrange: Generate unique data to prevent collision
    DECLARE @UniqueSuffix nvarchar(50) = LEFT(CAST(NEWID() AS nvarchar(50)), 8);
    DECLARE @TestEmail nvarchar(255) = 'test_' + @UniqueSuffix + '@gmail.com';
    DECLARE @TestAccount nvarchar(50) = 'acc_' + @UniqueSuffix;

    INSERT INTO People (FirstName, MiddleName, LastName)
    VALUES ('TestFirst', NULL, 'TestLast');

    DECLARE @PersonID int = CONVERT(int, SCOPE_IDENTITY());

    INSERT INTO Accounts (AccountName, Password, Email)
    VALUES (@TestAccount, 'securepass', @TestEmail);

    DECLARE @AccountID int = CONVERT(int, SCOPE_IDENTITY());

    INSERT INTO Administrators (IsActive, PersonID, AccountID)
    VALUES (1, @PersonID, @AccountID);

    DECLARE @AdminID int = CONVERT(int, SCOPE_IDENTITY());
	    DECLARE @Result bit;


    -- Act
    EXEC dbo.SP_AdminProfile_Delete
        @AdministratorID = @AdminID ,
		@Result = @Result out;


    -- Assert
    IF (
        not EXISTS(SELECT 1 FROM Administrators WHERE AdminID = @AdminID And IsActive = 1)
        AND EXISTS (SELECT 1 FROM People WHERE PersonID = @PersonID)
        AND EXISTS (SELECT 1 FROM Accounts WHERE AccountID = @AccountID)
		And @Result = 1
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

    -- Arrange: Generate unique data to prevent collision
    DECLARE @UniqueSuffix nvarchar(50) = LEFT(CAST(NEWID() AS nvarchar(50)), 8);

    DECLARE @OldEmail nvarchar(255) = 'old_' + @UniqueSuffix + '@gmail.com';
    DECLARE @OldAccount nvarchar(50) = 'old_acc_' + @UniqueSuffix;

    DECLARE @NewEmail nvarchar(255) = 'new_' + @UniqueSuffix + '@gmail.com';
    DECLARE @NewAccount nvarchar(50) = 'new_acc_' + @UniqueSuffix;

    INSERT INTO People (FirstName, MiddleName, LastName)
    VALUES ('OldFirst', NULL, 'OldLast');

    DECLARE @PersonID int = CONVERT(int, SCOPE_IDENTITY());

    INSERT INTO Accounts (AccountName, Password, Email)
    VALUES (@OldAccount, 'oldpass', @OldEmail);

    DECLARE @AccountID int = CONVERT(int, SCOPE_IDENTITY());

    INSERT INTO Administrators (IsActive, PersonID, AccountID)
    VALUES (1, @PersonID, @AccountID);

    DECLARE @AdminID int = CONVERT(int, SCOPE_IDENTITY());

    DECLARE @Result bit;

    -- Act
    EXEC dbo.SP_AdminProfile_Update
        @IsActive = 0,
        @AdministratorID = @AdminID,
        @AccountName = @NewAccount,
        @Password = 'newsecurepass',
        @Email = @NewEmail,
        @FirstName = 'NewFirst',
        @MiddleName = 'NewMiddle',
        @LastName = 'NewLast' , 
		@Result = @Result out;

    -- Assert
    IF (
        EXISTS (
            SELECT 1
            FROM Accounts
            WHERE AccountID = @AccountID
              AND AccountName = @NewAccount
              AND Password = 'newsecurepass'
              AND Email = @NewEmail
        )
        AND EXISTS (
            SELECT 1
            FROM Administrators
            WHERE AdminID = @AdminID
              AND PersonID = @PersonID
              AND AccountID = @AccountID
              AND IsActive = 0
        )
        AND EXISTS (
            SELECT 1
            FROM People
            WHERE PersonID = @PersonID
              AND FirstName = 'NewFirst'
              AND MiddleName = 'NewMiddle'
              AND LastName = 'NewLast'
        ) And @Result = 1
    )
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