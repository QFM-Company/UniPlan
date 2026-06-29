USE [UniPlan];
GO

/* =========================================================
   إدخال بيانات التخصصات (Majors)
========================================================= */

IF OBJECT_ID('tempdb..#SourceMajors') IS NOT NULL
    DROP TABLE #SourceMajors;

CREATE TABLE #SourceMajors
(
    MajorName NVARCHAR(100),
    ParentMajorName NVARCHAR(100) NULL
);

INSERT INTO #SourceMajors (MajorName, ParentMajorName)
VALUES
(N'هندسة المعلوماتية - اختصاص عام', NULL),
(N'هندسة برمجيات', N'هندسة المعلوماتية - اختصاص عام'),
(N'هندسة شبكات', N'هندسة المعلوماتية - اختصاص عام'),
(N'هندسة ذكاء صنعي', N'هندسة المعلوماتية - اختصاص عام');



/* =========================================================
   أولاً: إدخال التخصصات الرئيسية
========================================================= */
INSERT INTO dbo.Majors (MajorName, ParentMajorID)
SELECT s.MajorName, NULL
FROM #SourceMajors s
WHERE s.ParentMajorName IS NULL
AND NOT EXISTS
(
    SELECT 1
    FROM dbo.Majors m
    WHERE m.MajorName = s.MajorName
);



/* =========================================================
   ثانياً: إدخال التخصصات الفرعية
========================================================= */
INSERT INTO dbo.Majors (MajorName, ParentMajorID)
SELECT
    s.MajorName,
    p.MajorID
FROM #SourceMajors s
INNER JOIN dbo.Majors p
    ON p.MajorName = s.ParentMajorName
WHERE s.ParentMajorName IS NOT NULL
AND NOT EXISTS
(
    SELECT 1
    FROM dbo.Majors m
    WHERE m.MajorName = s.MajorName
);



DROP TABLE #SourceMajors;
GO

PRINT N'تم إدخال بيانات التخصصات بنجاح.';
GO