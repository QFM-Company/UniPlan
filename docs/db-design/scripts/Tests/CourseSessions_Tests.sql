USE UniPlan;
GO

SET NOCOUNT ON;
PRINT '--- STARTING COURSE SESSION INSERT TEST ---';

BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @MajorID INT;
    DECLARE @CourseID INT;
    DECLARE @LectureID INT;
    DECLARE @TermID INT;
    DECLARE @OfferingID INT;
    DECLARE @HallID INT;
    DECLARE @PeriodID INT;
    DECLARE @SlotID INT;
    DECLARE @SessionID INT;

    --------------------------------------------------
    -- Major
    --------------------------------------------------
    INSERT INTO Majors(MajorName)
    VALUES('Major_' + LEFT(CAST(NEWID() AS NVARCHAR(50)),8));

    SET @MajorID = SCOPE_IDENTITY();

    --------------------------------------------------
    -- Course
    --------------------------------------------------
    INSERT INTO Courses
    (
        CourseName,
        CreditHours,
        MajorID
    )
    VALUES
    (
        'Course_' + LEFT(CAST(NEWID() AS NVARCHAR(50)),8),
        3,
        @MajorID
    );

    SET @CourseID = SCOPE_IDENTITY();

    --------------------------------------------------
    -- Lecture
    --------------------------------------------------
    INSERT INTO Lectures
    (
        LectureType,
        DurationValue,
        CourseID
    )
    VALUES
    (
        1,
        2,
        @CourseID
    );

    SET @LectureID = SCOPE_IDENTITY();

    --------------------------------------------------
    -- Academic Term
    --------------------------------------------------
    INSERT INTO AcademicTerms
    (
        TermType,
        TermYear
    )
    VALUES
    (
        1,
        2030
    );

    SET @TermID = SCOPE_IDENTITY();

    --------------------------------------------------
    -- Course Offering
    --------------------------------------------------
    INSERT INTO CourseOfferings
    (
        SectionNumber,
        TermID,
        LectureID,
        CourseID
    )
    VALUES
    (
        1,
        @TermID,
        @LectureID,
        @CourseID
    );

    SET @OfferingID = SCOPE_IDENTITY();

    --------------------------------------------------
    -- Hall
    --------------------------------------------------
    INSERT INTO Halls
    (
        HallName,
        Building,
        Floor
    )
    VALUES
    (
        'Hall_' + LEFT(CAST(NEWID() AS NVARCHAR(50)),8),
        'A',
        1
    );

    SET @HallID = SCOPE_IDENTITY();

    --------------------------------------------------
    -- Period
    --------------------------------------------------
    INSERT INTO Periods
    (
        StartTime,
        EndTime
    )
    VALUES
    (
        '08:00',
        '09:00'
    );

    SET @PeriodID = SCOPE_IDENTITY();

    --------------------------------------------------
    -- Time Slot
    --------------------------------------------------
    INSERT INTO TimeSlots
    (
        DayNum,
        PeriodID
    )
    VALUES
    (
        1,
        @PeriodID
    );

    SET @SlotID = SCOPE_IDENTITY();

    --------------------------------------------------
    -- ACT
    --------------------------------------------------
    EXEC dbo.SP_CourseSessions_Insert
        @OfferingID = @OfferingID,
        @HallID = @HallID,
        @SlotID = @SlotID,
        @CreatedByAdminID = NULL,
        @SessionID = @SessionID OUT;

    --------------------------------------------------
    -- ASSERT
    --------------------------------------------------
    IF EXISTS
    (
        SELECT 1
        FROM CourseSessions
        WHERE SessionID = @SessionID
          AND OfferingID = @OfferingID
          AND HallID = @HallID
          AND SlotID = @SlotID
    )
    BEGIN
        PRINT '{ Insert Procedure IS Working }';
    END
    ELSE
    BEGIN
        PRINT '{ *** Insert Procedure IS * Not * Working *** }';
    END

    ROLLBACK TRANSACTION;

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    PRINT ERROR_MESSAGE();
END CATCH;
GO








USE UniPlan;
GO

SET NOCOUNT ON;
PRINT '--- STARTING COURSE SESSION UPDATE TEST ---';

BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @MajorID INT;
    DECLARE @CourseID INT;
    DECLARE @LectureID INT;
    DECLARE @TermID INT;
    DECLARE @OfferingID INT;

    DECLARE @HallID INT;
    DECLARE @PeriodID1 INT;
    DECLARE @PeriodID2 INT;

    DECLARE @SlotID1 INT;
    DECLARE @SlotID2 INT;

    DECLARE @SessionID INT;
    DECLARE @Result BIT;

    --------------------------------------------------
    -- Arrange
    --------------------------------------------------

    INSERT INTO Majors(MajorName)
    VALUES ('Major_' + LEFT(CAST(NEWID() AS NVARCHAR(50)),8));

    SET @MajorID = SCOPE_IDENTITY();

    INSERT INTO Courses
    (
        CourseName,
        CreditHours,
        MajorID
    )
    VALUES
    (
        'Course_' + LEFT(CAST(NEWID() AS NVARCHAR(50)),8),
        3,
        @MajorID
    );

    SET @CourseID = SCOPE_IDENTITY();

    INSERT INTO Lectures
    (
        LectureType,
        DurationValue,
        CourseID
    )
    VALUES
    (
        1,
        2,
        @CourseID
    );

    SET @LectureID = SCOPE_IDENTITY();

    INSERT INTO AcademicTerms
    (
        TermType,
        TermYear
    )
    VALUES
    (
        1,
        2030
    );

    SET @TermID = SCOPE_IDENTITY();

    INSERT INTO CourseOfferings
    (
        SectionNumber,
        TermID,
        LectureID,
        CourseID
    )
    VALUES
    (
        1,
        @TermID,
        @LectureID,
        @CourseID
    );

    SET @OfferingID = SCOPE_IDENTITY();

    INSERT INTO Halls
    (
        HallName,
        Building,
        Floor
    )
    VALUES
    (
        'Hall_' + LEFT(CAST(NEWID() AS NVARCHAR(50)),8),
        'A',
        1
    );

    SET @HallID = SCOPE_IDENTITY();

    INSERT INTO Periods(StartTime, EndTime)
    VALUES ('08:00', '09:00');

    SET @PeriodID1 = SCOPE_IDENTITY();

    INSERT INTO Periods(StartTime, EndTime)
    VALUES ('09:00', '10:00');

    SET @PeriodID2 = SCOPE_IDENTITY();

    INSERT INTO TimeSlots(DayNum, PeriodID)
    VALUES (1, @PeriodID1);

    SET @SlotID1 = SCOPE_IDENTITY();

    INSERT INTO TimeSlots(DayNum, PeriodID)
    VALUES (2, @PeriodID2);

    SET @SlotID2 = SCOPE_IDENTITY();

    INSERT INTO CourseSessions
    (
        OfferingID,
        HallID,
        SlotID
    )
    VALUES
    (
        @OfferingID,
        @HallID,
        @SlotID1
    );

    SET @SessionID = SCOPE_IDENTITY();

    --------------------------------------------------
    -- Act
    --------------------------------------------------

    EXEC dbo.SP_CourseSessions_Update
        @SessionID = @SessionID,
        @OfferingID = @OfferingID,
        @HallID = @HallID,
        @SlotID = @SlotID2,
        @Result = @Result OUT;

    --------------------------------------------------
    -- Assert
    --------------------------------------------------

    IF EXISTS
    (
        SELECT 1
        FROM CourseSessions
        WHERE SessionID = @SessionID
          AND SlotID = @SlotID2
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








USE UniPlan;
GO

SET NOCOUNT ON;
PRINT '--- STARTING COURSE SESSION DELETE TEST ---';

BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @MajorID INT;
    DECLARE @CourseID INT;
    DECLARE @LectureID INT;
    DECLARE @TermID INT;
    DECLARE @OfferingID INT;
    DECLARE @HallID INT;
    DECLARE @PeriodID INT;
    DECLARE @SlotID INT;
    DECLARE @SessionID INT;
    DECLARE @Result BIT;

    --------------------------------------------------
    -- Arrange
    --------------------------------------------------

    INSERT INTO Majors(MajorName)
    VALUES ('Major_' + LEFT(CAST(NEWID() AS NVARCHAR(50)),8));

    SET @MajorID = SCOPE_IDENTITY();

    INSERT INTO Courses
    (
        CourseName,
        CreditHours,
        MajorID
    )
    VALUES
    (
        'Course_' + LEFT(CAST(NEWID() AS NVARCHAR(50)),8),
        3,
        @MajorID
    );

    SET @CourseID = SCOPE_IDENTITY();

    INSERT INTO Lectures
    (
        LectureType,
        DurationValue,
        CourseID
    )
    VALUES
    (
        1,
        2,
        @CourseID
    );

    SET @LectureID = SCOPE_IDENTITY();

    INSERT INTO AcademicTerms
    (
        TermType,
        TermYear
    )
    VALUES
    (
        1,
        2030
    );

    SET @TermID = SCOPE_IDENTITY();

    INSERT INTO CourseOfferings
    (
        SectionNumber,
        TermID,
        LectureID,
        CourseID
    )
    VALUES
    (
        1,
        @TermID,
        @LectureID,
        @CourseID
    );

    SET @OfferingID = SCOPE_IDENTITY();

    INSERT INTO Halls
    (
        HallName,
        Building,
        Floor
    )
    VALUES
    (
        'Hall_' + LEFT(CAST(NEWID() AS NVARCHAR(50)),8),
        'A',
        1
    );

    SET @HallID = SCOPE_IDENTITY();

    INSERT INTO Periods
    (
        StartTime,
        EndTime
    )
    VALUES
    (
        '08:00',
        '09:00'
    );

    SET @PeriodID = SCOPE_IDENTITY();

    INSERT INTO TimeSlots
    (
        DayNum,
        PeriodID
    )
    VALUES
    (
        1,
        @PeriodID
    );

    SET @SlotID = SCOPE_IDENTITY();

    INSERT INTO CourseSessions
    (
        OfferingID,
        HallID,
        SlotID
    )
    VALUES
    (
        @OfferingID,
        @HallID,
        @SlotID
    );

    SET @SessionID = SCOPE_IDENTITY();

    --------------------------------------------------
    -- Act
    --------------------------------------------------

    EXEC dbo.SP_CourseSessions_Delete
        @SessionID = @SessionID,
        @Result = @Result OUT;

    --------------------------------------------------
    -- Assert
    --------------------------------------------------

    IF NOT EXISTS
    (
        SELECT 1
        FROM CourseSessions
        WHERE SessionID = @SessionID
    )
    AND @Result = 1
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