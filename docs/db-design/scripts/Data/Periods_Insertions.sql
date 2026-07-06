USE [UniPlan];
GO

-- Using a recursive CTE to generate 30-minute intervals
WITH PeriodGenerator AS (
    -- Start Anchor: The first period begins at 08:00 AM
    SELECT 
        CAST('08:00:00' AS time(7)) AS StartTime,
        CAST('09:00:00' AS time(7)) AS EndTime
    
    UNION ALL
    
    -- Recursive Member: Add 30 minutes to the previous period's times
    SELECT 
        DATEADD(minute, 60, StartTime) AS StartTime,
        DATEADD(minute, 60, EndTime) AS EndTime
    FROM PeriodGenerator
    -- Stop Condition: Do not let the next period's EndTime exceed 16:00
    WHERE DATEADD(minute, 60, EndTime) <= CAST('16:00:00' AS time(7))
)
INSERT INTO [dbo].[Periods] ([StartTime], [EndTime])
SELECT StartTime, EndTime 
FROM PeriodGenerator
-- Ensures we don't violate the unique constraint if you run this script twice
WHERE NOT EXISTS (
    SELECT 1 FROM [dbo].[Periods] p 
    WHERE p.StartTime = PeriodGenerator.StartTime 
      AND p.EndTime = PeriodGenerator.EndTime
);
GO

-- Verify the inserted periods
SELECT [PeriodID], [StartTime], [EndTime] 
FROM [dbo].[Periods]
ORDER BY [StartTime];
GO