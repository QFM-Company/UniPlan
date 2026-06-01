USE [UniPlan];
GO

BEGIN TRANSACTION;

DECLARE @TestMajorID INT;
SELECT TOP 1 @TestMajorID = MajorID FROM Majors;

IF @TestMajorID IS NULL
BEGIN
    INSERT INTO Majors (MajorName) VALUES (N'Computer Science');
    SELECT @TestMajorID = SCOPE_IDENTITY();
END

PRINT '--- 1. Testing SP_StudentProfile_Insert (Success Case) ---';
DECLARE @OutPersonID INT, @OutAccountID INT, @InsertResult BIT;

BEGIN TRY
    EXEC SP_StudentProfile_Insert
        @FirstName = N'John', @MiddleName = N'Robert', @LastName = N'Doe',
        @StudentID = 2026001, @MajorID = @TestMajorID,           
        @AccountName = N'johndoe', @Password = N'SecurePass123', @Email = N'john.doe@university.edu',
        @PersonID = @OutPersonID OUTPUT, @AccountID = @OutAccountID OUTPUT, @Result = @InsertResult OUTPUT;

    PRINT 'Insert Success. Result: ' + CAST(@InsertResult AS VARCHAR(5));
END TRY
BEGIN CATCH
    PRINT 'Insert Failed: ' + ERROR_MESSAGE();
END CATCH;

PRINT '--- 2. Testing SP_StudentProfile_Insert (Duplicate ID Error Case) ---';
BEGIN TRY
    EXEC SP_StudentProfile_Insert
        @FirstName = N'Jane', @MiddleName = N'Mary', @LastName = N'Smith',
        @StudentID = 2026001, @MajorID = @TestMajorID,
        @AccountName = N'janesmith', @Password = N'Password321', @Email = N'jane.smith@university.edu',
        @PersonID = @OutPersonID OUTPUT, @AccountID = @OutAccountID OUTPUT, @Result = @InsertResult OUTPUT;
END TRY
BEGIN CATCH
    PRINT 'Expected Error Caught: ' + ERROR_MESSAGE() + ' (Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + ')';
END CATCH;

PRINT '--- 3. Testing SP_StudentProfile_Update ---';
DECLARE @UpdateResult BIT;
BEGIN TRY
    EXEC SP_StudentProfile_Update
        @StudentID = 2026001, @FirstName = N'Johnathon', @MiddleName = N'Robert', @LastName = N'Doe',
        @AccountName = N'johndoe_new', @Email = N'john.new@university.edu', @MajorID = @TestMajorID,
        @Result = @UpdateResult OUTPUT;

    PRINT 'Update Success. Result: ' + CAST(@UpdateResult AS VARCHAR(5));
END TRY
BEGIN CATCH
    PRINT 'Update Failed: ' + ERROR_MESSAGE();
END CATCH;

PRINT '--- 4. Testing SP_StudentProfile_Delete ---';
DECLARE @DeleteResult BIT;
BEGIN TRY
    EXEC SP_StudentProfile_Delete @StudentID = 2026001, @Result = @DeleteResult OUTPUT;
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
