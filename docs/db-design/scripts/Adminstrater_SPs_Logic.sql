USE [UniPlan];
GO

CREATE PROCEDURE SP_Admin_Profile_Insert 

 @IsActive bit , @PersonID int , @AdministratorID int out,

 @AccountName nvarchar(255) , @Password nvarchar(255) , @Email nvarchar(255) , @AccountID int out

 As
 Begin
     SET NOCOUNT ON;

IF @PersonID IS NULL OR @PersonID <= 0 
BEGIN
    RAISERROR('Invalid Person provided', 16, 1);
    RETURN;
END

IF @IsActive IS NULL 
Begin
    set @IsActive = 1;
end

IF @AccountName IS NULL OR @Email IS NULL OR @Password IS NULL
BEGIN
    RAISERROR('AccountName, Email, and Password cannot be NULL', 16, 1);
    RETURN;
END

IF NOT EXISTS (SELECT 1 FROM People WHERE PersonID = @PersonID)
BEGIN
    RAISERROR('PersonID %d does not exist', 16, 1, @PersonID);
    RETURN;
END

-- Check for duplicate email/account name
IF EXISTS (SELECT 1 FROM Accounts WHERE Email = @Email)
BEGIN
    RAISERROR('Email already exists', 16, 1);
    RETURN;
END

	 Begin Try
	    Begin Transaction;

		INsert into Accounts(AccountName , Password , Email) values (@AccountName , @Password , @Email);
		set @AccountID = SCOPE_IDENTITY();

		insert into Administrators(IsActive , PersonID , AccountID) values (@IsActive , @PersonID , @AccountID);

		set @AdministratorID = SCOPE_IDENTITY();

		commit Transaction;
	 End Try
	 Begin Catch
	     IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
End;
Go




