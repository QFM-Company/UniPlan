USE UniPlan;
GO

SET NOCOUNT ON;
PRINT '--- STARTING COURSE INSERT TEST ---';

BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @MajorName NVARCHAR(50) = LEFT(CAST(NEWID() AS NVARCHAR(50)), 8);
    DECLARE @MajorID INT;
    DECLARE @CourseID INT;

    INSERT INTO Majors(MajorName)
    VALUES(@MajorName);

    SET @MajorID = CONVERT(INT, SCOPE_IDENTITY());

    DECLARE @CourseName NVARCHAR(100) = 'Course_' + LEFT(CAST(NEWID() AS NVARCHAR(50)), 8);
    DECLARE @CreditHours INT = 3;

    EXEC dbo.SP_Courses_Insert
        @CourseName = @CourseName,
        @CreditHours = @CreditHours,
        @MajorID = @MajorID,
        @CourseID = @CourseID OUT;

    IF EXISTS
    (
        SELECT 1
        FROM Courses
        WHERE CourseID = @CourseID
          AND CourseName = @CourseName
          AND CreditHours = @CreditHours
          AND MajorID = @MajorID
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



SET NOCOUNT ON;
PRINT '--- STARTING DELETE TEST ---';

BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @MajorName NVARCHAR(50) = LEFT(CAST(NEWID() AS NVARCHAR(50)), 8);
    DECLARE @MajorID INT;

    INSERT INTO Majors(MajorName)
    VALUES (@MajorName);

    SET @MajorID = CONVERT(INT, SCOPE_IDENTITY());

    DECLARE @CourseName NVARCHAR(100) = 'Course_' + LEFT(CAST(NEWID() AS NVARCHAR(50)), 8);
    DECLARE @CourseID INT;
    DECLARE @Result BIT;

    INSERT INTO Courses(CourseName, CreditHours, MajorID)
    VALUES (@CourseName, 3, @MajorID);

    SET @CourseID = CONVERT(INT, SCOPE_IDENTITY());

    -- Act
    EXEC dbo.SP_Courses_Delete
        @CourseID = @CourseID,
        @Result = @Result OUT;

    -- Assert
    IF (
        NOT EXISTS
        (
            SELECT 1
            FROM Courses
            WHERE CourseID = @CourseID
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



SET NOCOUNT ON;
PRINT '--- STARTING UPDATE TEST ---';

BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @MajorName NVARCHAR(50) = LEFT(CAST(NEWID() AS NVARCHAR(50)), 8);
    DECLARE @MajorID INT;

    INSERT INTO Majors(MajorName)
    VALUES (@MajorName);

    SET @MajorID = CONVERT(INT, SCOPE_IDENTITY());

    DECLARE @CourseName NVARCHAR(100) = 'Course_' + LEFT(CAST(NEWID() AS NVARCHAR(50)), 8);
    DECLARE @CourseID INT;
    DECLARE @Result BIT;

    INSERT INTO Courses(CourseName, CreditHours, MajorID)
    VALUES (@CourseName, 3, @MajorID);

    SET @CourseID = CONVERT(INT, SCOPE_IDENTITY());

    DECLARE @NewCourseName NVARCHAR(100) = 'Course_' + LEFT(CAST(NEWID() AS NVARCHAR(50)), 8);
    DECLARE @NewCreditHours INT = 4;

    -- Act
    EXEC dbo.SP_Courses_Update
        @CourseID = @CourseID,
        @CourseName = @NewCourseName,
        @CreditHours = @NewCreditHours,
        @MajorID = @MajorID,
        @Result = @Result OUT;

    -- Assert
    IF (
           EXISTS
           (
               SELECT 1
               FROM Courses
               WHERE CourseID = @CourseID
                 AND CourseName = @NewCourseName
                 AND CreditHours = @NewCreditHours
                 AND MajorID = @MajorID
           )
           AND
           NOT EXISTS
           (
               SELECT 1
               FROM Courses
               WHERE CourseID = @CourseID
                 AND CourseName = @CourseName
           )
       )
       AND @Result = 1
    BEGIN
        PRINT '{ Update Procedure IS Working }';
    END
    ELSE
    BEGIN
        PRINT '{ *** Update Procedure IS * Not * Working *** }';
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