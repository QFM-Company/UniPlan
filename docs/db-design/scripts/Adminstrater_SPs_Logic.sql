USE [UniPlan];
GO



Create Function ValidatAccountInfo (@AccountName nvarchar(50) , @Password nvarchar(255) , @Email nvarchar(255))
returns bit
Begin

IF @AccountName IS NULL OR @Email IS NULL OR @Password IS NULL
BEGIN
    RETURN 0;
END

-- Check for duplicate email/account name
IF EXISTS (SELECT 1 FROM Accounts WHERE Email = @Email)
BEGIN
    RETURN 0;
END

return 1;
End;
go






Create Function ValidatAdministratorInfo (@PersonID int)
returns bit
Begin


IF @PersonID IS NULL OR @PersonID <= 0 
BEGIN
    RETURN 0;
END



IF NOT EXISTS (SELECT 1 FROM People WHERE PersonID = @PersonID)
BEGIN
    RETURN 0;
END


return 1;
End;
go












CREATE PROCEDURE SP_Admin_Profile_Insert 

 @IsActive bit , @PersonID int , @AdministratorID int out,

 @AccountName nvarchar(50) , @Password nvarchar(255) , @Email nvarchar(255) , @AccountID int out

 As
 Begin
     SET NOCOUNT ON;

	 IF @IsActive IS NULL 
Begin
    set @IsActive = 1;
end


        IF dbo.ValidatAccountInfo(@AccountName, @Password, @Email) = 0
        BEGIN
          RAISERROR('Account validation failed', 16, 1);
	    END

        -- Validate Person information
        IF dbo.ValidatAdministrator(@PersonID) = 0
        BEGIN
             RAISERROR('Administrator validation failed', 16, 1);
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

