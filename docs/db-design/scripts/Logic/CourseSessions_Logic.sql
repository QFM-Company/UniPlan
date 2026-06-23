USE [UniPlan];
GO

/*=========================================================
INSERT
=========================================================*/
CREATE OR ALTER PROCEDURE SP_CourseSessions_Insert
@OfferingID INT,
@HallID INT,
@SlotID INT,
@CreatedByAdminID INT = NULL,
@SessionID INT OUT
AS
BEGIN
SET NOCOUNT ON;

IF @OfferingID <= 0
    OR @HallID <= 0
    OR @SlotID <= 0
BEGIN
   ; THROW 50801, 'Course session validation failed.', 1;
END;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.CourseOfferings
    WHERE OfferingID = @OfferingID
)
BEGIN
   ; THROW 50804, 'Course Offering not found.', 1;
END;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Halls
    WHERE HallID = @HallID
)
BEGIN
   ; THROW 50805, 'Hall not found.', 1;
END;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.TimeSlots
    WHERE SlotID = @SlotID
)
BEGIN
   ; THROW 50806, 'Time Slot not found.', 1;
END;


IF EXISTS
(
    SELECT 1
    FROM dbo.CourseSessions
    WHERE HallID = @HallID
      AND SlotID = @SlotID
)
BEGIN
    ;THROW 50802, 'This hall is already assigned to the selected time slot.', 1;
END;

IF EXISTS
(
    SELECT 1
    FROM dbo.CourseSessions
    WHERE OfferingID = @OfferingID
      AND SlotID = @SlotID
)
BEGIN
  ;  THROW 50803, 'This course offering is already assigned to the selected time slot.', 1;
END;

BEGIN TRY

    BEGIN TRANSACTION;

    INSERT INTO dbo.CourseSessions
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

    SET @SessionID = CONVERT(INT, SCOPE_IDENTITY());

    COMMIT TRANSACTION;

END TRY
BEGIN CATCH

    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    THROW;

END CATCH

END;
GO

/*=========================================================
UPDATE
=========================================================*/
CREATE OR ALTER PROCEDURE SP_CourseSessions_Update
@SessionID INT,
@OfferingID INT,
@HallID INT,
@SlotID INT,
@Result BIT OUT
AS
BEGIN
SET NOCOUNT ON;

IF @SessionID <= 0
    OR @OfferingID <= 0
    OR @HallID <= 0
    OR @SlotID <= 0
BEGIN
   ; THROW 50801, 'Course session validation failed.', 1;
END;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.CourseSessions
    WHERE SessionID = @SessionID
)
BEGIN
   ; THROW 50807, 'Course Session not found.', 1;
END;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.CourseOfferings
    WHERE OfferingID = @OfferingID
)
BEGIN
   ; THROW 50804, 'Course Offering not found.', 1;
END;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Halls
    WHERE HallID = @HallID
)
BEGIN
    ;THROW 50805, 'Hall not found.', 1;
END;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.TimeSlots
    WHERE SlotID = @SlotID
)
BEGIN
   ; THROW 50806, 'Time Slot not found.', 1;
END;


IF EXISTS
(
    SELECT 1
    FROM dbo.CourseSessions
    WHERE HallID = @HallID
      AND SlotID = @SlotID
      AND SessionID <> @SessionID
)
BEGIN
    ;THROW 50802, 'This hall is already assigned to the selected time slot.', 1;
END;

IF EXISTS
(
    SELECT 1
    FROM dbo.CourseSessions
    WHERE OfferingID = @OfferingID
      AND SlotID = @SlotID
      AND SessionID <> @SessionID
)
BEGIN
   ; THROW 50803, 'This course offering is already assigned to the selected time slot.', 1;
END;

BEGIN TRY

    BEGIN TRANSACTION;

    UPDATE dbo.CourseSessions
    SET
        OfferingID = @OfferingID,
        HallID = @HallID,
        SlotID = @SlotID
    WHERE SessionID = @SessionID;

    SET @Result =
        CASE
            WHEN @@ROWCOUNT > 0 THEN 1
            ELSE 0
        END;

    COMMIT TRANSACTION;

END TRY
BEGIN CATCH

    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    THROW;

END CATCH

END;
GO

/*=========================================================
DELETE
=========================================================*/
CREATE OR ALTER PROCEDURE SP_CourseSessions_Delete
@SessionID INT,
@Result BIT OUT
AS
BEGIN
SET NOCOUNT ON;

IF @SessionID <= 0
BEGIN
    ;THROW 50801, 'Course session validation failed.', 1;
END;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.CourseSessions
    WHERE SessionID = @SessionID
)
BEGIN
    SET @Result = 0;
    RETURN;
END;

BEGIN TRY

    BEGIN TRANSACTION;

    DELETE FROM dbo.CourseSessions
    WHERE SessionID = @SessionID;

    SET @Result =
        CASE
            WHEN @@ROWCOUNT > 0 THEN 1
            ELSE 0
        END;

    COMMIT TRANSACTION;

END TRY
BEGIN CATCH

    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    THROW;

END CATCH

END;
GO

/*=========================================================
GET ALL
=========================================================*/
CREATE OR ALTER PROCEDURE SP_CourseSessions_GetAll
@PageNumber INT = 1,
@PageSize INT = 10
AS
BEGIN
SET NOCOUNT ON;

IF @PageNumber < 1
    SET @PageNumber = 1;

IF @PageSize < 1
    SET @PageSize = 10;

BEGIN TRY

    SELECT COUNT(*) AS TotalRows
    FROM dbo.CourseSessions;

    SELECT
        CS.SessionID,
        CS.OfferingID,
        CO.SectionNumber,
        H.HallID,
        H.HallName,
        H.Building,
        H.Floor,
        TS.SlotID,
        TS.DayNum,
        P.StartTime,
        P.EndTime,
        CS.CreatedByAdminID
    FROM dbo.CourseSessions CS
    INNER JOIN dbo.CourseOfferings CO
        ON CS.OfferingID = CO.OfferingID
    INNER JOIN dbo.Halls H
        ON CS.HallID = H.HallID
    INNER JOIN dbo.TimeSlots TS
        ON CS.SlotID = TS.SlotID
    INNER JOIN dbo.Periods P
        ON TS.PeriodID = P.PeriodID
    ORDER BY CS.SessionID
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

END TRY
BEGIN CATCH
    THROW;
END CATCH


END;
GO

/*=========================================================
GET BY ID
=========================================================*/
CREATE OR ALTER PROCEDURE SP_CourseSessions_GetById
@SessionID INT
AS
BEGIN
SET NOCOUNT ON;

BEGIN TRY

    SELECT
        CS.SessionID,
        CS.OfferingID,
        CO.SectionNumber,
        H.HallID,
        H.HallName,
        H.Building,
        H.Floor,
        TS.SlotID,
        TS.DayNum,
        P.StartTime,
        P.EndTime,
        CS.CreatedByAdminID
    FROM dbo.CourseSessions CS
    INNER JOIN dbo.CourseOfferings CO
        ON CS.OfferingID = CO.OfferingID
    INNER JOIN dbo.Halls H
        ON CS.HallID = H.HallID
    INNER JOIN dbo.TimeSlots TS
        ON CS.SlotID = TS.SlotID
    INNER JOIN dbo.Periods P
        ON TS.PeriodID = P.PeriodID
    WHERE CS.SessionID = @SessionID;

END TRY
BEGIN CATCH
    THROW;
END CATCH

END;
GO
