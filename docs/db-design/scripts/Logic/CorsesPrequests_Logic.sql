USE [UniPlan];
GO

-- ==========================================
-- 1. INSERT PROCEDURE
-- ==========================================
CREATE OR ALTER PROCEDURE SP_CoursePrerequisites_Insert
    @CourseID INT,
    @PrerequisiteCourseID INT,
    @PrerequisiteID INT OUT,
	@Result bit out
AS
BEGIN
    SET NOCOUNT ON;

    -- Validation logic mimicking the table's check constraint and basic ID checks
    IF @CourseID <= 0 
        OR @PrerequisiteCourseID <= 0 
        OR @CourseID = @PrerequisiteCourseID
    BEGIN
        ;THROW 50801, 'Course prerequisite validation failed', 1;
    END

    BEGIN TRY
        INSERT INTO [dbo].[CoursePrerequisites]
        (
            [CourseID],
            [PrerequisiteCourseID]
        )
        VALUES
        (
            @CourseID,
            @PrerequisiteCourseID
        );

        SET @PrerequisiteID = CONVERT(INT, SCOPE_IDENTITY());

		set @Result = 1;

    END TRY
    BEGIN CATCH
	set @Result = 0;
        THROW;
    END CATCH
END;
GO



-- ==========================================
-- 2. DELETE PROCEDURE
-- ==========================================
CREATE OR ALTER PROCEDURE SP_CoursePrerequisites_Delete
    @PrerequisiteID INT,
    @Result BIT OUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DELETE FROM [dbo].[CoursePrerequisites]
        WHERE [PrerequisiteID] = @PrerequisiteID;

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


create or Alter View VW_Main
As
select main.CourseID , main.CourseName , main.CreditHours 
from Courses as main;
GO


create or Alter View VW_Pre
AS
select pre.CourseID as CourseID2 , pre.CourseName as CourseName2 , pre.CreditHours as CreditHours2
from Courses as pre;
GO


Create Or Alter View VW_PrequistCourses
AS
SELECT
             m.CourseID , m.CourseName , m.CreditHours ,
			 p.CourseID2 , p.CourseName2 , p.CreditHours2 ,
			 CP.PrerequisiteID
        FROM [dbo].[VW_Main]as m inner join CoursePrerequisites As CP on  CP.CourseID = m.CourseID 
		inner Join VW_Pre as p on CP.PrerequisiteCourseID = p.CourseID2
go


-- ==========================================
-- 3. GET ALL (PAGED) PROCEDURE
-- ==========================================
CREATE OR ALTER PROCEDURE SP_CoursePrerequisites_GetAll
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


        SELECT * from VW_PrequistCourses
        ORDER BY PrerequisiteID
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;

    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO



-- ==========================================
-- 4. GET BY ID PROCEDURE
-- ==========================================
CREATE OR ALTER PROCEDURE SP_CoursePrerequisites_GetById
    @PrerequisiteID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT * from VW_PrequistCourses
            WHERE PrerequisiteID = @PrerequisiteID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO