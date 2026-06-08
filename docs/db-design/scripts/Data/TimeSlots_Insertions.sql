USE [UniPlan];
GO

-- Using a CTE to define our specific days (Friday to Tuesday)
WITH TargetDays AS (
    SELECT 5 AS DayNum UNION ALL -- Friday
    SELECT 6 UNION ALL            -- Saturday
    SELECT 7 UNION ALL            -- Sunday
    SELECT 1 UNION ALL            -- Monday
    SELECT 2                      -- Tuesday
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
        WHEN 1 THEN 'Monday'
        WHEN 2 THEN 'Tuesday'
        WHEN 3 THEN 'Wednesday'
        WHEN 4 THEN 'Thursday'
        WHEN 5 THEN 'Friday'
        WHEN 6 THEN 'Saturday'
        WHEN 7 THEN 'Sunday'
    END AS DayName,
    ts.[DayNum],
    p.[StartTime],
    p.[EndTime]
FROM [dbo].[TimeSlots] ts
INNER JOIN [dbo].[Periods] p ON ts.[PeriodID] = p.[PeriodID]
ORDER BY 
    -- Custom sorting order to show Friday first down to Tuesday
    CASE ts.[DayNum]
        WHEN 5 THEN 1 -- Friday
        WHEN 6 THEN 2 -- Saturday
        WHEN 7 THEN 3 -- Sunday
        WHEN 1 THEN 4 -- Monday
        WHEN 2 THEN 5 -- Tuesday
    END, 
    p.[StartTime];
GO