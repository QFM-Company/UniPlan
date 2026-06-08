USE [UniPlan];
GO

/* =========================================================
   1. جلب معرف الأدمن الحالي لاستخدامه في حقل CreatedByAdminID
========================================================= */
DECLARE @CurrentAdminID int;
SELECT @CurrentAdminID = a.[AdminID] 
FROM [dbo].[Administrators] a
INNER JOIN [dbo].[Accounts] acc ON a.[AccountID] = acc.[AccountID]
WHERE acc.[AccountName] = N'admin_user';

/* =========================================================
   2. جدول مؤقت يحتوي على الأسماء المعدلة والمحدثة
========================================================= */
IF OBJECT_ID('tempdb..#SourceHallsUpdated') IS NOT NULL DROP TABLE #SourceHallsUpdated;
CREATE TABLE #SourceHallsUpdated ([HallName] nvarchar(50));

INSERT INTO #SourceHallsUpdated ([HallName])
VALUES 
(N'القاعة 401'), (N'القاعة 402'), (N'القاعة 1'), (N'القاعة 2'), (N'القاعة 3'), 
(N'القاعة 4'), (N'القاعة 5'), (N'القاعة 6'), (N'القاعة 7'), (N'القاعة 8'), 
(N'القاعة 9'), (N'القاعة 10'), (N'القاعة 13'), (N'القاعة 14'), (N'القاعة 15'), 
(N'القاعة 16'), (N'القاعة 18'), 
(N'مخبر 1'), (N'مخبر 2'), (N'مخبر 3'), (N'مخبر 4'), (N'مخبر 5'), (N'مخبر 6'), (N'مخبر 7'), 
(N'مخبر فيزياء'), (N'مخبر اسس 1'), (N'مخبر اسس 2');

/* =========================================================
   3. إدخال البيانات الجديدة مع تجنب التكرار
========================================================= */
INSERT INTO [dbo].[Halls] ([HallName], [Building], [Floor], [CreatedByAdminID])
SELECT 
    sh.[HallName], 
    N'بناء هندسة المعلوماتية' AS [Building], 
    NULL AS [Floor], 
    @CurrentAdminID AS [CreatedByAdminID]
FROM #SourceHallsUpdated sh
WHERE NOT EXISTS (
    SELECT 1 
    FROM [dbo].[Halls] h
    WHERE h.[HallName] = sh.[HallName] 
      AND h.[Building] = N'بناء هندسة المعلوماتية'
);

-- تنظيف الجدول المؤقت
DROP TABLE #SourceHallsUpdated;
GO

/* =========================================================
   4. استعراض النتيجة النهائية للتأكد
========================================================= */
SELECT 
    [HallID],
    [HallName],
    [Building],
    ISNULL(CAST([Floor] AS nvarchar), N'NULL') AS [Floor]
FROM [dbo].[Halls]
WHERE [Building] = N'بناء هندسة المعلوماتية'
ORDER BY 
    CASE 
        WHEN [HallName] LIKE N'القاعة%' THEN 1 
        ELSE 2 
    END, 
    [HallName];
GO