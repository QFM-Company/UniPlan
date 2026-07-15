USE [UniPlan];
GO

-- Using a CTE to define our specific days (Friday to Tuesday)
WITH TargetDays AS (
    SELECT 5 AS DayNum UNION ALL 
    SELECT 6 UNION ALL            
    SELECT 0 UNION ALL            
    SELECT 1 UNION ALL            
    SELECT 2                      
)
INSERT INTO [dbo].[TimeSlots] ([DayNum], [PeriodID])
SELECT 
    d.DayNum, 
    p.PeriodID
FROM TargetDays d
CROSS JOIN [dbo].[Periods] p
-- Ensures we don't violate the unique constraint if run multiple times
WHERE NOT EXISTS (
    SELECT 1 
    FROM [dbo].[TimeSlots] ts
    WHERE ts.DayNum = d.DayNum 
      AND ts.PeriodID = p.PeriodID
);
GO

-- Verify the inserted Time Slots with their corresponding times
SELECT 
    ts.[SlotID],
    CASE ts.[DayNum]
        WHEN 0 THEN 'Monday'
        WHEN 1 THEN 'Tuesday'
        WHEN 2 THEN 'Wednesday'
        WHEN 3 THEN 'Thursday'
        WHEN 4 THEN 'Friday'
        WHEN 5 THEN 'Saturday'
        WHEN 6 THEN 'Sunday'
    END AS DayName,
    ts.[DayNum],
    p.[StartTime],
    p.[EndTime]
FROM [dbo].[TimeSlots] ts
INNER JOIN [dbo].[Periods] p ON ts.[PeriodID] = p.[PeriodID]
GO