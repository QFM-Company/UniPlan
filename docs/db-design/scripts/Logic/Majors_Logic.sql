USE [UniPlan];
GO


CREATE OR ALTER PROCEDURE SP_Majors_Insert
    @MajorName nvarchar(50),
    @MajorID int out
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@MajorName)), '') IS NULL
    THROW 50501, 'Major validation failed', 1;
 

    BEGIN TRY
        INSERT INTO [dbo].[Majors] ([MajorName])
        VALUES (@MajorName)
        
        SET @MajorID = CONVERT(int, SCOPE_IDENTITY());
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_Majors_Update
    @MajorName nvarchar(50),
    @MajorID int,
    @Result bit out 
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@MajorName)), '') IS NULL OR @MajorID < 0
        THROW 50501, 'Major validation failed', 1; 

    BEGIN TRY
        UPDATE [dbo].[Majors] 
        SET [MajorName] = @MajorName
        WHERE MajorID = @MajorID;

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

CREATE OR ALTER PROCEDURE SP_Majors_Delete
   @MajorID INT, 
   @Result BIT OUT 
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DELETE FROM [dbo].[Majors]
        WHERE MajorID = @MajorID;
        
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

CREATE OR ALTER PROCEDURE SP_Majors_GetAll 
    @PageNumber INT = 1, 
    @PageSize INT = 10
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF @PageNumber IS NULL OR @PageNumber < 1
            SET @PageNumber = 1;

        IF @PageSize IS NULL OR @PageSize < 1
            SET @PageSize = 10;

        SELECT * FROM Majors
        ORDER BY [MajorID]
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_Majors_GetById 
    @MajorID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT * FROM Majors
        WHERE MajorID = @MajorID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO
