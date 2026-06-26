USE [UniPlan];
GO


CREATE OR ALTER PROCEDURE SP_Accounts_Login
    @AccountName nvarchar(50),
    @Password nvarchar(255),
    @AccountID int OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT @AccountID = A.AccountID  FROM Accounts A
        WHERE A.Password = @Password AND A.AccountName = @AccountName;
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_Accounts_UpdatePassword
    @AccountID int,
    @NewPassword nvarchar(255),
    @OLdPassword nvarchar(255),
    @Result bit OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        UPDATE Accounts SET [Password] = @NewPassword
        WHERE [AccountID] = @AccountID AND [Password] = @OLdPassword;

        IF @@ROWCOUNT > 0
        BEGIN
            SET @Result = 1;
        END
        ELSE
        BEGIN
            SET @Result = 0;
        END
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_Accounts_GetById 
    @AccountID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT * FROM Accounts
        WHERE AccountID = @AccountID;
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH
END;
GO


