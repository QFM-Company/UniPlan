USE UniPlan;
GO

CREATE OR ALTER PROCEDURE SP_CourseOfferings_Insert
    @SectionNumber int,
    @TermID int,
    @LectureID int,
    @CreatedByAdminID int,
    @CourseID int,
    @OfferingID int OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN  TRY
        INSERT INTO [dbo].[CourseOfferings]
           ([SectionNumber],[TermID],[LectureID],[CreatedByAdminID],[CourseID])
        VALUES
           (@SectionNumber, @TermID, @LectureID, @CreatedByAdminID, @CourseID);

        SET @OfferingID = CONVERT(int, SCOPE_IDENTITY());
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_CourseOfferings_Update
    @OfferingID int,
    @SectionNumber int,
    @TermID int,
    @LectureID int,
    @CourseID int,
    @Result bit OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN  TRY
        UPDATE [dbo].[CourseOfferings]
           SET [SectionNumber] = @SectionNumber, [TermID] = @TermID, [LectureID] = @LectureID
        WHERE CourseID = @CourseID;

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
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_CourseOfferings_Delete
    @OfferingID int,
    @Result bit OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN  TRY
        DELETE FROM CourseOfferings
        WHERE OfferingID = @OfferingID;

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
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER VIEW CourseOfferings_view
AS
SELECT L.*, T.TermID, T.TermYear
,T.TermType, O.OfferingID, O.CreatedByAdminID, O.SectionNumber
FROM CourseOfferings O
INNER JOIN Lectures_view L ON O.LectureID = L.LectureID
INNER JOIN AcademicTerms T ON O.TermID = T.TermID;
GO

CREATE OR ALTER PROCEDURE SP_CourseOfferings_GetById
    @OfferingID int
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN  TRY
        SELECT * FROM CourseOfferings_view
        WHERE OfferingID = @OfferingID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_CourseOfferings_GetAll
    @PageNumber int,
    @PageSize int
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN  TRY
         -- CHANGED: Prevent invalid pagination values.
        IF @PageNumber IS NULL OR @PageNumber < 1
            SET @PageNumber = 1;

        -- CHANGED: Prevent invalid page size.
        IF @PageSize IS NULL OR @PageSize < 1
            SET @PageSize = 10;

        SELECT * FROM CourseOfferings_view
        ORDER BY [OfferingID]
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO
