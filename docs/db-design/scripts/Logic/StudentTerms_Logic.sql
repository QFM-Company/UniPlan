USE [UniPlan]
GO

CREATE OR ALTER VIEW VW_StudentTerms
AS
SELECT
    ST.RegistrationID,
    ST.StudentID,
    ST.TermID,
	T.TermType,
	T.TermYear

FROM dbo.StudentTerms ST
INNER JOIN dbo.AcademicTerms T
    ON ST.TermID = T.TermID;
GO


CREATE OR ALTER PROCEDURE SP_StudentTerms_Insert
    @StudentID INT,
    @TermID INT,
    @RegistrationID INT OUT
AS
BEGIN
    SET NOCOUNT ON;

    IF @StudentID <= 0
        OR @TermID <= 0
    BEGIN
        ;THROW 50801, 'StudentTerm validation failed', 1;
    END

    BEGIN TRY
        INSERT INTO dbo.StudentTerms
        (
            StudentID,
            TermID
        )
        VALUES
        (
            @StudentID,
            @TermID
        );

        SET @RegistrationID = CONVERT(INT, SCOPE_IDENTITY());
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO



CREATE OR ALTER PROCEDURE SP_StudentTerms_GetByStudentId
    @StudentID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM VW_StudentTerms
    WHERE StudentID = @StudentID
    ORDER BY RegistrationID;
END;
GO