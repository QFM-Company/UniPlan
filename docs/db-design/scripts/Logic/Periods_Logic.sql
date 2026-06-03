
USE [UniPlan];
GO



CREATE OR ALTER FUNCTION ValidatePeriod
(
    @StartTime time,
    @EndTime time
)
RETURNS bit
AS
BEGIN
    IF @StartTime IS NULL OR @EndTime IS NULL
        RETURN 0;

    IF @StartTime >= @EndTime
        RETURN 0;

    RETURN 1;
END;
GO


CREATE OR ALTER PROCEDURE SP_Period_Insert
    @StartTime time,
    @EndTime time,
    @PeriodID int OUT
AS
BEGIN
    SET NOCOUNT ON;

    IF dbo.ValidatePeriod(@StartTime, @EndTime) = 0
        THROW 50601, 'Period validation failed', 1;

    IF EXISTS
    (
        SELECT 1
        FROM Periods
        WHERE StartTime = @StartTime
          AND EndTime = @EndTime
    )
        THROW 50602, 'Period already exists', 1;

    BEGIN TRY
        INSERT INTO Periods(StartTime, EndTime)
        VALUES (@StartTime, @EndTime);

        SET @PeriodID = CONVERT(int, SCOPE_IDENTITY());
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO


CREATE OR ALTER PROCEDURE SP_Period_Delete
    @PeriodID int,
	@Result bit out

AS
BEGIN
    SET NOCOUNT ON;

    IF @PeriodID IS NULL OR @PeriodID <= 0
        THROW 50601, 'Period validation failed', 1;

    IF NOT EXISTS
    (
        SELECT 1
        FROM Periods
        WHERE PeriodID = @PeriodID
    )
        THROW 50603, 'Period does not exist', 1;

    IF EXISTS
    (
        SELECT 1
        FROM TimeSlots
        WHERE PeriodID = @PeriodID
    )
        THROW 50604, 'Cannot delete period because it is used by time slots', 1;

    BEGIN TRY
        DELETE FROM Periods
        WHERE PeriodID = @PeriodID;

		IF @@ROWCOUNT > 0
        BEGIN
            SET @Result = 1;
        END
		else 
		begin
		   set @Result = 0;
		end
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO


CREATE OR ALTER PROCEDURE SP_Period_GetAll
  @PageNumber INT = 1, 
    @PageSize INT = 10
AS
BEGIN
    SET NOCOUNT ON;
	
        IF @PageNumber IS NULL OR @PageNumber < 1
            SET @PageNumber = 1;

        IF @PageSize IS NULL OR @PageSize < 1
            SET @PageSize = 10;

    SELECT * 
    FROM Periods
    ORDER BY PeriodID
	 OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;
END;
GO


CREATE OR ALTER PROCEDURE SP_Period_GetById
    @PeriodID int
AS
BEGIN
    SET NOCOUNT ON;

    IF @PeriodID IS NULL OR @PeriodID <= 0
        THROW 50601, 'Invalid PeriodID', 1;

    SELECT *
    FROM Periods
    WHERE PeriodID = @PeriodID;
END;
GO

