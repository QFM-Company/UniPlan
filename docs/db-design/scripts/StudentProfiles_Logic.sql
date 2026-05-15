USE [UniPlan];
GO

CREATE PROCEDURE SP_People_Insert
    @FirstName NVARCHAR(50),@MiddleName NVARCHAR(50),@LastName NVARCHAR(50),@PersonID INT OUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO [dbo].[People] ([FirstName],[MiddleName],[LastName])
        VALUES ( @FirstName, @MiddleName, @LastName )
        
        SET @PersonID = SCOPE_IDENTITY();

    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

CREATE PROCEDURE SP_StudentProfile_Insert
    @FirstName NVARCHAR(50),@MiddleName NVARCHAR(50),@LastName NVARCHAR(50),@PersonID INT OUT,
    @AccountName NVARCHAR(50),@Password NVARCHAR(255),@Email NVARCHAR(255),@AccountID INT OUT,
    @StudentID INT,@MajorID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [dbo].[People] ([FirstName],[MiddleName],[LastName])
        VALUES ( @FirstName, @MiddleName, @LastName )
        
        SET @PersonID = SCOPE_IDENTITY();

        INSERT INTO [dbo].[Accounts] ([AccountName],[Password],[Email])
        VALUES (@AccountName, @Password, @Email)

        SET @AccountID = SCOPE_IDENTITY();

        INSERT INTO [dbo].[Students] ([StudentID],[PersonID],[AccountID],[MajorID])
        VALUES ( @StudentID, @PersonID, @AccountID, @MajorID);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO


CREATE PROCEDURE SP_StudentProfile_Update
    @FirstName NVARCHAR(50),@MiddleName NVARCHAR(50),@LastName NVARCHAR(50),
    @AccountName NVARCHAR(50),@Email NVARCHAR(255),@StudentID INT
    ,@MajorID INT,@Result BIT OUT 
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DECLARE @RowsAffected INT = 0 ,@PersonID INT = 0 ,@AccountID INT = 0;
        
        SELECT @PersonID = PersonID,@AccountID = AccountID FROM Students
        WHERE StudentID = @StudentID;

        BEGIN TRANSACTION;

        UPDATE [dbo].[People] SET [FirstName] = @FirstName , [MiddleName] = @MiddleName 
        ,[LastName] = @LastName
        WHERE [PersonID] = @PersonID;

        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        UPDATE [dbo].[Accounts] SET [AccountName] = @AccountName 
        ,[Email] = @Email
        WHERE [AccountID] = @AccountID;

        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        UPDATE [dbo].[Students] SET [MajorID] = @MajorID
        WHERE [StudentID] = @StudentID;

        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;
        
        IF @RowsAffected > 2
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

        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

CREATE PROCEDURE SP_StudentProfile_Delete
   @StudentID INT ,@Result BIT OUT 
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DECLARE @RowsAffected INT = 0 ,@PersonID INT = 0 ,@AccountID INT = 0;
        
        SELECT @PersonID = PersonID,@AccountID = AccountID FROM Students
        WHERE StudentID = @StudentID;

        BEGIN TRANSACTION;

        DELETE FROM [dbo].[Students]
        WHERE StudentID = @StudentID;

        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        DELETE FROM [dbo].[Accounts]
        WHERE AccountID = @AccountID;

        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

        DELETE FROM [dbo].[People]
        WHERE PersonID = @PersonID;

        SET @RowsAffected = @RowsAffected + @@ROWCOUNT;
        
        IF @RowsAffected > 2
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

        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

CREATE VIEW StudentProfiles_view
AS
SELECT S.StudentID , P.PersonID , FullName = P.FirstName + ' ' + P.MiddleName + ' ' + P.LastName ,
A.AccountName , A.Email , M.MajorName FROM Students S
INNER JOIN People P ON S.PersonID = P.PersonID
INNER JOIN Accounts A ON S.AccountID = A.AccountID
INNER JOIN Majors M ON S.MajorID = M.MajorID;
GO

CREATE PROCEDURE SP_StudentProfile_GetAll 
    @PageNumber INT = 1, @PageSize INT = 10
AS
BEGIN

    BEGIN TRY
       
        SELECT * FROM StudentProfiles_view
        ORDER BY [StudentID]
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;

    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

CREATE PROCEDURE SP_StudentProfile_GetById 
    @StudentID INT
AS
BEGIN

    BEGIN TRY
       
        SELECT * FROM StudentProfiles_view
        WHERE StudentID = @StudentID;

    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO
