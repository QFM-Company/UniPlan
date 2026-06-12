USE UniPlan;
GO

CREATE OR ALTER PROCEDURE SP_AcademicTerms_Insert
    @TermType int,
    @TermYear int,
    @TermID int OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO [dbo].[AcademicTerms] ([TermType],[TermYear])
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
    @PageNumber int,
    @PageSize int
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

        SELECT * FROM AcademicTerms
        ORDER BY [TermID]
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
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
        SELECT * FROM AcademicTerms
        WHERE TermID = @TermID;
    END TRY
    BEGIN CATCH
        -- CHANGED: THROW keeps the original error details.
        THROW;
    END CATCH

END;
GO
