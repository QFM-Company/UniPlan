USE UniPlan;
GO

CREATE OR ALTER PROCEDURE SP_Lectures_Insert
    @LectureType int,
    @DurationValue int,
    @CourseID int,
    @LectureID int OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN  TRY

        INSERT INTO [dbo].[Lectures] ([LectureType],[DurationValue],[CourseID])
        VALUES (@LectureType, @DurationValue, @CourseID);

        SET @LectureID = CONVERT(int, SCOPE_IDENTITY());
    END TRY

    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_Lectures_Update
    @LectureID int,
    @LectureType int,
    @DurationValue int,
    @CourseID int,
    @Result bit OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN  TRY

        UPDATE [dbo].[Lectures]
            SET [LectureType] = @LectureType,[DurationValue] = @DurationValue,[CourseID] = @CourseID
        WHERE LectureID = @LectureID;

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

CREATE OR ALTER PROCEDURE SP_Lectures_Delete
    @LectureID int,
    @Result bit OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN  TRY
        DELETE FROM Lectures
        WHERE LectureID = @LectureID;
    
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

CREATE OR ALTER VIEW Lectures_view
AS
SELECT C.*
,L.LectureID, L.DurationValue, L.LectureType
FROM Lectures L
INNER JOIN Courses C ON L.CourseID = C.CourseID
GO

CREATE OR ALTER PROCEDURE SP_Lectures_GetAll
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

        SELECT * FROM Lectures_view
        ORDER BY [LectureID]
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;  
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_Lectures_GetById
    @LectureID int
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN  TRY
        SELECT * FROM Lectures_view
        WHERE LectureID = @LectureID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO