USE [UniPlan];
GO

CREATE OR ALTER PROCEDURE SP_People_Validate
    @FirstName NVARCHAR(50),
    @MiddleName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @PersonID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@FirstName)), N'') IS NULL
        RETURN 50101;

    IF NULLIF(LTRIM(RTRIM(@LastName)), N'') IS NULL
        RETURN 50101;

    IF @MiddleName IS NOT NULL AND NULLIF(LTRIM(RTRIM(@MiddleName)), N'') IS NULL
        RETURN 50101;

    IF @PersonID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [dbo].[People] WHERE PersonID = @PersonID)
        RETURN 50103;

    RETURN 0;
END;
GO

CREATE OR ALTER PROCEDURE SP_People_Insert
    @FirstName NVARCHAR(50),
    @MiddleName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @PersonID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ErrCode INT;
    EXEC @ErrCode = SP_People_Validate @FirstName, @MiddleName, @LastName, NULL;

    IF @ErrCode != 0
        THROW @ErrCode, '', 1;

    BEGIN TRY
        INSERT INTO [dbo].[People] ([FirstName], [MiddleName], [LastName])
        VALUES (@FirstName, @MiddleName, @LastName);

        SET @PersonID = SCOPE_IDENTITY();
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_People_Update
    @PersonID INT,
    @FirstName NVARCHAR(50),
    @MiddleName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Result BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SET @Result = 0;

    DECLARE @ErrCode INT;
    EXEC @ErrCode = SP_People_Validate @FirstName, @MiddleName, @LastName, @PersonID;

    IF @ErrCode != 0
        THROW @ErrCode, '', 1;

    BEGIN TRY
        UPDATE [dbo].[People]
        SET [FirstName] = @FirstName,
            [MiddleName] = @MiddleName,
            [LastName] = @LastName
        WHERE PersonID = @PersonID;

        IF @@ROWCOUNT > 0
            SET @Result = 1;
        ELSE
            SET @Result = 0;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_People_Delete
    @PersonID INT,
    @Result BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SET @Result = 0;

    IF NOT EXISTS (SELECT 1 FROM [dbo].[People] WHERE PersonID = @PersonID)
        THROW 50103, '', 1;

    IF EXISTS (SELECT 1 FROM [dbo].[Administrators] WHERE PersonID = @PersonID)
        THROW 50104, '', 1;

    IF EXISTS (SELECT 1 FROM [dbo].[Students] WHERE PersonID = @PersonID)
        THROW 50104, '', 1;

    BEGIN TRY
        DELETE FROM [dbo].[People]
        WHERE PersonID = @PersonID;

        IF @@ROWCOUNT > 0
            SET @Result = 1;
        ELSE
            SET @Result = 0;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO