USE [UniPlan];
GO



Create Function ValidatPerson ( @FirstName nvarchar(255) , @MiddleName nvarchar(255) , @LastName nvarchar(255))
returns bit
Begin

IF @FirstName IS NULL OR @LastName IS NULL
BEGIN
    RETURN 0;
END

return 1;
End;
go






Create Function Validat_New_AccountInfo (@AccountName nvarchar(50) , @Password nvarchar(255) , @Email nvarchar(255))
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







Create Function ValidatAccountInfo (@AccountName nvarchar(50) , @Password nvarchar(255) , @Email nvarchar(255) , @OldEmail nvarchar(255))
returns bit
Begin

IF @AccountName IS NULL OR @Email IS NULL OR @Password IS NULL
BEGIN
    RETURN 0;
END

-- Check for duplicate email/account name
IF  (@Email != @OldEmail) And EXISTS(SELECT 1 FROM Accounts WHERE Email = @Email)
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


        IF dbo.Validat_New_AccountInfo(@AccountName, @Password, @Email) = 0
        BEGIN
          RAISERROR('Account validation failed', 16, 1);
	    END

        -- Validate Person information
        IF dbo.ValidatAdministratorInfo(@PersonID) = 0
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






CREATE PROCEDURE SP_Admin_Profile_Update

 @IsActive bit , @PersonID int , @AdministratorID int,

 @AccountName nvarchar(50) , @Password nvarchar(255) , @Email nvarchar(255) , @AccountID int,

 @FirstName nvarchar(255) , @MiddleName nvarchar(255) , @LastName nvarchar(255)

 As
 Begin
     SET NOCOUNT ON;

	 IF @IsActive IS NULL 
Begin
    set @IsActive = 1;
end

        Declare @OldEmail NVARchar(255);
		select @OldEmail = Accounts.Email from Accounts where AccountID = @AccountID;

        IF dbo.ValidatAccountInfo(@AccountName, @Password, @Email , @OldEmail) = 0
        BEGIN
          RAISERROR('Account validation failed', 16, 1);
	    END

        -- Validate Person information
        IF dbo.ValidatAdministratorInfo(@PersonID) = 0
        BEGIN
             RAISERROR('Administrator validation failed', 16, 1);
        END


		IF dbo.ValidatPerson(@FirstName ,@MiddleName , @LastName) = 0
		BEGIN
             RAISERROR('Person validation failed', 16, 1);
        END


	 Begin Try
	    Begin Transaction;

		Update Accounts
		set Accounts.AccountName = @AccountName , Accounts.Email = @Email , Accounts.Password = @Password
		where Accounts.AccountID = @AccountID;
		

		Update Administrators
		set Administrators.AccountID = @AccountID , Administrators.IsActive = @IsActive , Administrators.PersonID = @PersonID
		where AdminID = @AdministratorID;

		Update People
		set people.FirstName = @FirstName , MiddleName = @MiddleName , LastName = @LastName 
		where People.PersonID = @PersonID;

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






CREATE PROCEDURE SP_Admin_Profile_Delete

 @PersonID int , @AdministratorID int, @AccountID int



 As
 Begin
     SET NOCOUNT ON;

        Declare @OldEmail NVARchar(255);
		select @OldEmail = Accounts.Email from Accounts where AccountID = @AccountID;



	 Begin Try
	    Begin Transaction;

		Delete Accounts
		where Accounts.AccountID = @AccountID;
		

		Delete Administrators
		where AdminID = @AdministratorID;

		Delete People
		where People.PersonID = @PersonID;


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





Create View AdminProfiles_view As
Select Administrators.AdminID , Accounts.AccountID , People.PersonID , Accounts.AccountName ,
Accounts.Password , Accounts.Email , People.FirstName , People.MiddleName , People.LastName , Administrators.IsActive 

from People inner join Administrators on People.PersonID = Administrators.PersonID
inner join Accounts on Administrators.AccountID = Accounts.AccountID;


go


CREATE PROCEDURE SP_AdminProfile_GetAll 
    @PageNumber INT = 1, @PageSize INT = 10
AS
BEGIN

    BEGIN TRY
       
        SELECT * FROM AdminProfiles_view
        ORDER BY [AdminID]
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



CREATE PROCEDURE SP_AdminProfile_GetById 
    @AdminID INT
AS
BEGIN

    BEGIN TRY
       
        SELECT * FROM AdminProfiles_view
        WHERE AdminID = @AdminID;

    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO
