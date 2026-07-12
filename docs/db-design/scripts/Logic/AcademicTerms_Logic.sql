USE UniPlan;
GO

CREATE OR ALTER PROCEDURE SP_Terms_Validate
    @TermType int,
    @TermYear int
AS
BEGIN
    SET NOCOUNT ON;

    IF @TermType NOT IN (1, 2, 3)
        RETURN 51101;

    IF @TermYear < 2026 OR @TermYear > 2100
        RETURN 51101;

    IF EXISTS (
        SELECT 1
        FROM [dbo].[AcademicTerms]
        WHERE TermType = @TermType AND TermYear = @TermYear
    )
        RETURN 51102;

    RETURN 0;
END;
GO

CREATE OR ALTER PROCEDURE SP_AcademicTerms_Insert
    @TermType int,
    @TermYear int,
    @TermID int OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ErrCode int;
    EXEC @ErrCode = SP_Terms_Validate @TermType, @TermYear;

    IF @ErrCode != 0
        THROW @ErrCode, '', 1;

    BEGIN TRY
        INSERT INTO [dbo].[AcademicTerms] ([TermType], [TermYear])
        VALUES (@TermType, @TermYear);

        SET @TermID = SCOPE_IDENTITY();
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_AcademicTerms_Delete
    @TermID int,
    @Result bit OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SET @Result = 0;

    IF NOT EXISTS (SELECT 1 FROM [dbo].[AcademicTerms] WHERE TermID = @TermID)
        THROW 51103, '', 1;

    IF EXISTS (SELECT 1 FROM [dbo].[StudentTerms] WHERE TermID = @TermID)
        THROW 51104, '', 1;

    IF EXISTS (SELECT 1 FROM [dbo].[CourseOfferings] WHERE TermID = @TermID)
        THROW 51104, '', 1;

    BEGIN TRY
        DELETE FROM [dbo].[AcademicTerms]
        WHERE TermID = @TermID;

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

CREATE OR ALTER PROCEDURE SP_AcademicTerms_GetAll
    @PageNumber int = 1,
    @PageSize int = 10
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF @PageNumber IS NULL OR @PageNumber < 1
            SET @PageNumber = 1;

        IF @PageSize IS NULL OR @PageSize < 1
            SET @PageSize = 10;

        SELECT * FROM [dbo].[AcademicTerms]
        ORDER BY [TermID]
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_AcademicTerms_GetById
    @TermID int
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT * FROM [dbo].[AcademicTerms]
        WHERE TermID = @TermID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO