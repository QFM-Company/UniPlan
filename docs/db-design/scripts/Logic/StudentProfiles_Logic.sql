USE [UniPlan];
GO

CREATE OR ALTER PROCEDURE SP_People_Insert
    @FirstName NVARCHAR(50), 
    @MiddleName NVARCHAR(50), 
    @LastName NVARCHAR(50), 
    @PersonID INT OUT
AS
BEGIN
    SET NOCOUNT ON;

    -- CHANGED: THROW stops execution immediately.
    IF dbo.ValidatPerson(@FirstName, @MiddleName, @LastName) = 0
        THROW 50101, 'Person validation failed', 1;
    BEGIN TRY
        INSERT INTO [dbo].[People] ([FirstName], [MiddleName], [LastName])
        VALUES (@FirstName, @MiddleName, @LastName);
        
        SET @PersonID = CONVERT(int, SCOPE_IDENTITY());
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_StudentProfile_Insert
    @FirstName NVARCHAR(50), @MiddleName NVARCHAR(50), @LastName NVARCHAR(50), @PersonID INT OUT,
    @AccountName NVARCHAR(50), @Password NVARCHAR(255), @Email NVARCHAR(255), @AccountID INT OUT,
    @StudentID INT, @MajorID INT , @Result BIT OUT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @RowsAffected INT = 0;

    -- CHANGED: THROW stops the procedure immediately.
    -- RAISERROR in your original code raised the error but the procedure could continue.
    IF dbo.Validat_New_AccountInfo(@AccountName, @Password, @Email) = 0
        THROW 50401, 'Account validation failed', 1;

    -- CHANGED: THROW stops execution immediately.
    IF dbo.ValidatPerson(@FirstName, @MiddleName, @LastName) = 0
        THROW 50101, 'Person validation failed', 1;   
    
    IF EXISTS (SELECT 1 FROM Students WHERE StudentID = @StudentID)
        THROW 50302, 'The StudentID already exists in the system.', 1;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [dbo].[People] ([FirstName], [MiddleName], [LastName])
        VALUES (@FirstName, @MiddleName, @LastName);
         SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        SET @PersonID = CONVERT(int, SCOPE_IDENTITY());

        INSERT INTO [dbo].[Accounts] ([AccountName], [Password], [Email])
        VALUES (@AccountName, @Password, @Email);
         SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        SET @AccountID = CONVERT(int, SCOPE_IDENTITY());

        INSERT INTO [dbo].[Students] ([StudentID], [PersonID], [AccountID], [MajorID])
        VALUES (@StudentID, @PersonID, @AccountID, @MajorID);
         SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        IF @RowsAffected >= 3
        BEGIN
            COMMIT TRANSACTION;
            SET @Result = 1;
        END
        ELSE
        BEGIN
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            SET @Result = 0;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_StudentProfile_Update
    @FirstName NVARCHAR(50), @MiddleName NVARCHAR(50), @LastName NVARCHAR(50),
    @AccountName NVARCHAR(50), @Email NVARCHAR(255), @StudentID INT,
    @MajorID INT, @Result BIT OUT 
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DECLARE @RowsAffected INT = 0, @PersonID INT = 0, @AccountID INT = 0;
        
        SELECT @PersonID = PersonID, @AccountID = AccountID 
        FROM Students
        WHERE StudentID = @StudentID;

        IF @StudentID IS NULL OR @PersonID = 0 OR @AccountID = 0
            THROW 50303, 'Student profile not found.', 1;

        -- CHANGED: Uses @AccountID to detect duplicate email/account name correctly.
        IF dbo.ValidatAccountInfo(@AccountName, NULL, @Email, @AccountID) = 0
            THROW 50401, 'Account validation failed', 1;

        -- CHANGED: THROW stops execution immediately.
        IF dbo.ValidatPerson(@FirstName, @MiddleName, @LastName) = 0
            THROW 50101, 'Person validation failed', 1;


        BEGIN TRANSACTION;

        UPDATE [dbo].[People] 
        SET [FirstName] = @FirstName, [MiddleName] = @MiddleName, [LastName] = @LastName
        WHERE [PersonID] = @PersonID;
        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        UPDATE [dbo].[Accounts] 
        SET [AccountName] = @AccountName, [Email] = @Email
        WHERE [AccountID] = @AccountID;
        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        UPDATE [dbo].[Students] 
        SET [MajorID] = @MajorID
        WHERE [StudentID] = @StudentID;
        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;
        
        IF @RowsAffected >= 3
        BEGIN
            COMMIT TRANSACTION;
            SET @Result = 1;
        END
        ELSE
        BEGIN
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            SET @Result = 0;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_StudentProfile_Delete
   @StudentID INT, @Result BIT OUT 
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DECLARE @RowsAffected INT = 0, @PersonID INT = 0, @AccountID INT = 0;
        
        SELECT @PersonID = PersonID, @AccountID = AccountID 
        FROM Students
        WHERE StudentID = @StudentID;

        BEGIN TRANSACTION;

        DELETE FROM [dbo].[Students] WHERE StudentID = @StudentID;
        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        DELETE FROM [dbo].[Accounts] WHERE AccountID = @AccountID;
        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        DELETE FROM [dbo].[People] WHERE PersonID = @PersonID;
        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;
        
        IF @RowsAffected >= 3
        BEGIN
            COMMIT TRANSACTION;
            SET @Result = 1;
        END
        ELSE
        BEGIN
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            SET @Result = 0;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER VIEW StudentProfiles_view
AS
SELECT 
    S.StudentID, P.PersonID, P.FirstName, P.MiddleName, P.LastName,
    A.AccountName, A.Email, M.MajorName 
FROM Students S
INNER JOIN People P ON S.PersonID = P.PersonID
INNER JOIN Accounts A ON S.AccountID = A.AccountID
INNER JOIN Majors M ON S.MajorID = M.MajorID;
GO

CREATE OR ALTER PROCEDURE SP_StudentProfile_GetAll 
    @PageNumber INT = 1, 
    @PageSize INT = 10
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- CHANGED: Prevent invalid pagination values.
        IF @PageNumber IS NULL OR @PageNumber < 1
            SET @PageNumber = 1;

        -- CHANGED: Prevent invalid page size.
        IF @PageSize IS NULL OR @PageSize < 1
            SET @PageSize = 10;

        SELECT * FROM StudentProfiles_view
        ORDER BY [StudentID]
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_StudentProfile_GetById 
    @StudentID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT * FROM StudentProfiles_view
        WHERE StudentID = @StudentID;
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO