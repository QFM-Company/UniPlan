USE [UniPlan];
GO

/* =========================================================
   2. جدول مؤقت يحتوي على البيانات لمطابقة هيكلية الجدول تماماً
========================================================= */
IF OBJECT_ID('tempdb..#SourceCourses') IS NOT NULL DROP TABLE #SourceCourses;
CREATE TABLE #SourceCourses (
    [CourseCode] nvarchar(20),
    [CourseName] nvarchar(150),
    [Credits] int,
    [MajorID] int
);

INSERT INTO #SourceCourses ([CourseCode], [CourseName], [Credits], [MajorID])
VALUES 
(N'RQU101', N'اللغة الإنكليزية (1)', 3, NULL),
(N'RQU102', N'اللغة العربية (1)', 2, NULL),
(N'RQU103', N'مهارات الحاسوب', 3, NULL),
(N'RQU207', N'اللغة الإنكليزية (2)', 3, NULL),
(N'RQU211', N'ثقافة عامة (وطنية، قومية)', 2, NULL),
(N'RQUE1', N'علم الإدارة', 2, NULL),
(N'RQUE2', N'علم الاجتماع', 2, NULL),
(N'RQUE3', N'المنطق العلمي', 2, NULL),
(N'RQUE4', N'اللغة العربية (2)', 2, NULL),
(N'RQUE5', N'علم النفس', 2, NULL),
(N'RQUE6', N'الاقتصاد السوري', 2, NULL),
(N'RQF104', N'رياضيات 1', 3, NULL),
(N'RQF105', N'الميكانيك الهندسي', 3, NULL),
(N'RQF106', N'مدخل إلى البرمجة', 4, NULL),
(N'RQF208', N'رياضيات 2', 3, NULL),
(N'RQF209', N'الجودة والوثوقية', 2, NULL),
(N'RQF210', N'أسس الهندسة الكهربائية', 5, NULL),
(N'RQF212', N'الكيمياء', 3, NULL),
(N'RQF313', N'رياضيات 3', 3, NULL),
(N'RQF314', N'فيزياء', 3, NULL),
(N'RQF315', N'الرسم الهندسي', 3, NULL),
(N'RQF417', N'تطبيقات في الاحصاء الهندسي', 3, NULL),
(N'RQFE1', N'مدخل إلى الخوارزميات', 2, NULL),
(N'RQFE2', N'نمذجة ومحاكاة', 2, NULL),
(N'RQFE3', N'مقدمة إلى شبكات الاتصالات', 2, NULL),
(N'RQFE4', N'تقييم مشاريع والجدوى الاقتصادية', 2, NULL),
(N'RQFE5', N'مهارات في اللغة الانكليزية للتطبيقات الهندسية', 2, NULL),
(N'RQFE6', N'إدارة الجودة الشاملة', 2, NULL),
(N'RQFE7', N'قواعد البيانات', 2, NULL),
(N'RQFE8', N'مهارات التواصل', 2, NULL),
(N'RQFE9', N'طرائق البحث', 2, NULL),
(N'RQITC316', N'رياضيات متقطعة', 3, NULL),
(N'RQITC418', N'تحليل عددي', 3, NULL),
(N'RQITC419', N'دارات منطقية', 4, NULL),
(N'RQITC420', N'مدخل إلى علوم الحاسوب', 2, NULL),
(N'RQITC521', N'الخوارزميات وبنى المعطيات', 3, NULL),
(N'RQITC522', N'برمجة غرضية التوجه', 3, NULL),
(N'RQITC523', N'تنظيم الحواسيب ولغة التجميع', 3, NULL),
(N'RQITC524', N'مدخل إلى الذكاء الصنعي', 4, NULL),
(N'RQITC625', N'قواعد معطيات (1)', 3, NULL),
(N'RQITC626', N'تقانات الإنترنت & برمجة الوب', 3, NULL),
(N'RQITC627', N'تنظيم وبنيان الحواسيب', 3, NULL),
(N'RQITC628', N'تراسل المعطيات & شبكات الحواسيب (1)', 4, NULL),
(N'RQITC629', N'برمجة النظم', 3, NULL),
(N'RQITC730', N'بحوث عمليات', 3, NULL),
(N'RQITC731', N'هندسة برمجيات (1)', 3, NULL),
(N'RQITC732', N'قواعد معطيات (2)', 3, NULL),
(N'RQITC733', N'نظم التشغيل', 4, NULL),
(N'RQITC734', N'نظرية الحوسبة', 3, NULL),
(N'RQITC835', N'أمن نظم المعلومات', 4, NULL),
(N'RQITC836', N'تراسل المعطيات & شبكات الحواسيب (2)', 3, NULL),
(N'RQITC837', N'تصميم المترجمات', 4, NULL),
(N'RQITC838', N'تطوير التطبيقات', 3, NULL),
(N'RQITC839', N'مشروع فصلي', 2, NULL),
(N'RQITC940', N'نظم المعلومات الموزعة', 3, NULL),
(N'RQITC941', N'نظم المعلومات الإدارية', 3, NULL),
(N'RQITC942', N'مشروع تخرج', 4, NULL),
(N'RQITC043', N'أنظمة الوسائط المتعددة', 3, NULL),
(N'RQITE946', N'برمجة تفرعية', 3, NULL),
(N'RQITE947', N'بناء مترجمات', 3, NULL),
(N'RQITE051', N'نظم استرجاع البيانات', 4, NULL),
(N'RQITE049', N'قواعد معطيات متقدمة', 3, NULL),
(N'RQITE948', N'هندسة برمجيات (2)', 4, NULL),
(N'RQITE050', N'الحوسبة النقالة', 3, NULL),
(N'RQITE953', N'أمن شبكات حاسوبية', 4, NULL),
(N'RQITE055', N'تصميم شبكات', 4, NULL),
(N'RQITE952', N'إدارة شبكات', 3, NULL),
(N'RQITE054', N'الشبكات اللاسلكية', 3, NULL),
(N'RQITE956', N'الرجل الآلي والنظم الخبيرة', 4, NULL),
(N'RQITE058', N'التعلم الآلي والشبكات العصبونية', 3, NULL),
(N'RQITE059', N'الرؤية الحاسوبية', 3, NULL),
(N'RQITE957', N'النمذجة والمحاكاة', 3, NULL);

/* =========================================================
   3. إدخال البيانات في جدول [dbo].[Courses] بناءً على الهيكلية الأصلية
========================================================= */
INSERT INTO [dbo].[Courses] ([CourseCode], [CourseName], [CreditHours], [MajorID])
SELECT 
    sc.[CourseCode], 
    sc.[CourseName], 
    sc.[Credits], 
    sc.[MajorID]
FROM #SourceCourses sc
WHERE NOT EXISTS (
    SELECT 1 
    FROM [dbo].[Courses] c
    WHERE c.[CourseCode] = sc.[CourseCode]
);

-- تنظيف الجدول المؤقت
DROP TABLE #SourceCourses;
GO

/* =========================================================
   4. استعراض البيانات المدخلة للتأكد
========================================================= */
SELECT * FROM [dbo].[Courses] ORDER BY [CourseCode];
GO
