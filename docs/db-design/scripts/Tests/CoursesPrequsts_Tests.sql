
USE UniPlan;
GO

-- ==========================================
-- 1. STARTING COURSE PREREQUISITES INSERT TEST
-- ==========================================
SET NOCOUNT ON;
PRINT '--- STARTING COURSE PREREQUISITES INSERT TEST ---';

BEGIN TRY
    BEGIN TRANSACTION;

    -- إنشاء تخصص ومادتين لربطهما كمتطلب سابق
    DECLARE @MajorName NVARCHAR(50) = LEFT(CAST(NEWID() AS NVARCHAR(50)), 8);
    DECLARE @MajorID INT;
    
    INSERT INTO Majors(MajorName) VALUES(@MajorName);
    SET @MajorID = CONVERT(INT, SCOPE_IDENTITY());

    DECLARE @CourseID1 INT, @CourseID2 INT;
    
    INSERT INTO Courses(CourseName, CreditHours, MajorID) VALUES('CourseA_' + LEFT(CAST(NEWID() AS NVARCHAR(50)), 8), 3, @MajorID);
    SET @CourseID1 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO Courses(CourseName, CreditHours, MajorID) VALUES('CourseB_' + LEFT(CAST(NEWID() AS NVARCHAR(50)), 8), 3, @MajorID);
    SET @CourseID2 = CONVERT(INT, SCOPE_IDENTITY());

    -- متغيرات الفحص للمتطلب السابق
    DECLARE @PrerequisiteID INT;

    -- تنفيذ الإجراء المراد فدسه
    EXEC dbo.SP_CoursePrerequisites_Insert
        @CourseID = @CourseID1,
        @PrerequisiteCourseID = @CourseID2,
        @PrerequisiteID = @PrerequisiteID OUT;

    -- التأكيد (Assert)
    IF EXISTS
    (
        SELECT 1
        FROM CoursePrerequisites
        WHERE PrerequisiteID = @PrerequisiteID
          AND CourseID = @CourseID1
          AND PrerequisiteCourseID = @CourseID2
    )
    BEGIN
        PRINT '{ Insert Procedure IS Working }';
    END
    ELSE
    BEGIN
        PRINT '{ *** Insert Procedure IS * Not * Working *** }';
    END

    ROLLBACK TRANSACTION;
    PRINT '--- TEST COMPLETE (Data Rolled Back) ---';

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    PRINT 'TEST FAILED WITH ENGINE ERROR:';
    PRINT ERROR_MESSAGE();
END CATCH;
GO



-- ==========================================
-- 2. STARTING COURSE PREREQUISITES DELETE TEST
-- ==========================================
SET NOCOUNT ON;
PRINT '--- STARTING COURSE PREREQUISITES DELETE TEST ---';

BEGIN TRY
    BEGIN TRANSACTION;

    -- إنشاء تخصص ومادتين لعملية الحذف
    DECLARE @MajorName NVARCHAR(50) = LEFT(CAST(NEWID() AS NVARCHAR(50)), 8);
    DECLARE @MajorID INT;
    
    INSERT INTO Majors(MajorName) VALUES(@MajorName);
    SET @MajorID = CONVERT(INT, SCOPE_IDENTITY());

    DECLARE @CourseID1 INT, @CourseID2 INT;
    
    INSERT INTO Courses(CourseName, CreditHours, MajorID) VALUES('CourseA_' + LEFT(CAST(NEWID() AS NVARCHAR(50)), 8), 3, @MajorID);
    SET @CourseID1 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO Courses(CourseName, CreditHours, MajorID) VALUES('CourseB_' + LEFT(CAST(NEWID() AS NVARCHAR(50)), 8), 3, @MajorID);
    SET @CourseID2 = CONVERT(INT, SCOPE_IDENTITY());

    -- إدراج سجل المتطلب المراد حذفه
    DECLARE @PrerequisiteID INT;
    DECLARE @Result BIT;

    INSERT INTO CoursePrerequisites(CourseID, PrerequisiteCourseID) VALUES(@CourseID1, @CourseID2);
    SET @PrerequisiteID = CONVERT(INT, SCOPE_IDENTITY());

    -- تنفيذ الإجراء المراد فدسه
    EXEC dbo.SP_CoursePrerequisites_Delete
        @PrerequisiteID = @PrerequisiteID,
        @Result = @Result OUT;

    -- التأكيد (Assert)
    IF (
        NOT EXISTS
        (
            SELECT 1
            FROM CoursePrerequisites
            WHERE PrerequisiteID = @PrerequisiteID
        )
    ) AND @Result = 1
    BEGIN
        PRINT '{ Delete Procedure IS Working }';
    END
    ELSE
    BEGIN
        PRINT '{ *** Delete Procedure IS * Not * Working *** }';
    END

    ROLLBACK TRANSACTION;
    PRINT '--- TEST COMPLETE (Data Rolled Back) ---';

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    PRINT 'TEST FAILED WITH ENGINE ERROR:';
    PRINT ERROR_MESSAGE();
END CATCH;
GO
