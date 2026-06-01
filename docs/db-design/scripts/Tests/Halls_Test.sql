USE [UniPlan];
GO

BEGIN TRANSACTION;

DECLARE @TestAdminID INT;
SELECT TOP 1 @TestAdminID = AdminID FROM Administrators;

IF @TestAdminID IS NULL
BEGIN
    DECLARE @NewPersonID INT, @NewAccountID INT;
    INSERT INTO People (FirstName, MiddleName, LastName) VALUES (N'Admin', N'System', N'User');
    SET @NewPersonID = SCOPE_IDENTITY();
    INSERT INTO Accounts (AccountName, Password, Email) VALUES (N'admin_test', N'Pass123', N'admin@uniplan.com');
    SET @NewAccountID = SCOPE_IDENTITY();
    INSERT INTO Administrators (IsActive, PersonID, AccountID) VALUES (1, @NewPersonID, @NewAccountID);
    SET @TestAdminID = SCOPE_IDENTITY();
END

PRINT '--- 1. Testing SP_Halls_Insert (Success Case) ---';
DECLARE @NewHallID INT;
BEGIN TRY
    EXEC SP_Halls_Insert
        @HallName = N'Hall A', @Building = N'Engineering Building', @Floor = 2,
        @CreatedByAdminID = @TestAdminID, @HallID = @NewHallID OUTPUT;

    PRINT 'Insert Success. ID: ' + CAST(@NewHallID AS VARCHAR(10));
END TRY
BEGIN CATCH
    PRINT 'Insert Failed: ' + ERROR_MESSAGE();
END CATCH;

PRINT '--- 2. Testing SP_Halls_Insert (Validation Error Case) ---';
BEGIN TRY
    EXEC SP_Halls_Insert
        @HallName = N'   ', @Building = N'Science Building', @Floor = 1,
        @CreatedByAdminID = @TestAdminID, @HallID = @NewHallID OUTPUT;
END TRY
BEGIN CATCH
    PRINT 'Expected Error Caught: ' + ERROR_MESSAGE() + ' (Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + ')';
END CATCH;

PRINT '--- 3. Testing SP_Halls_Update ---';
DECLARE @UpdateResult BIT;
BEGIN TRY
    EXEC SP_Halls_Update
        @HallID = @NewHallID, @HallName = N'Updated Hall A', @Building = N'Main Building', @Floor = 3,
        @Result = @UpdateResult OUTPUT;

    PRINT 'Update Success. Result: ' + CAST(@UpdateResult AS VARCHAR(5));
END TRY
BEGIN CATCH
    PRINT 'Update Failed: ' + ERROR_MESSAGE();
END CATCH;

PRINT '--- 4. Testing SP_Halls_Delete ---';
DECLARE @DeleteResult BIT;
BEGIN TRY
    EXEC SP_Halls_Delete @HallID = @NewHallID, @Result = @DeleteResult OUTPUT;
    PRINT 'Delete Success. Result: ' + CAST(@DeleteResult AS VARCHAR(5));
END TRY
BEGIN CATCH
    PRINT 'Delete Failed: ' + ERROR_MESSAGE();
END CATCH;

IF @@TRANCOUNT > 0
BEGIN
    ROLLBACK TRANSACTION;
    PRINT '--- Database Rollbacked Cleanly ---';
END
ELSE
BEGIN
    PRINT '--- Database Already Rollbacked by Internal SP ---';
END
GO
