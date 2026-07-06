use [UniPlan];
go

-- إضافة الفصل العام للبرنامج (إن لم يكن موجوداً)
if not exists (select 1 from AcademicTerms where TermType = 2 and TermYear = '2026')
begin
    insert into AcademicTerms (TermType, TermYear)
    values (2, '2026');
end
go

-- ==================== قواعد معطيات (2) ====================
-- نظري - شعبة 1
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    1,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 1 and CourseID = (select CourseID from Courses where CourseName = N'قواعد معطيات (2)')),
    (select CourseID from Courses where CourseName = N'قواعد معطيات (2)')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(), (select HallID from Halls where HallName = 'القاعة 3'));

-- نظري - شعبة 2
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    2,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 1 and CourseID = (select CourseID from Courses where CourseName = N'قواعد معطيات (2)')),
    (select CourseID from Courses where CourseName = N'قواعد معطيات (2)')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(),  (select HallID from Halls where HallName = 'القاعة 1'));

-- عملي - شعبة 1
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    1,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 2 and CourseID = (select CourseID from Courses where CourseName = N'قواعد معطيات (2)')),
    (select CourseID from Courses where CourseName = N'قواعد معطيات (2)')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(),  (select HallID from Halls where HallName = 'القاعة 15'));

-- عملي - شعبة 2
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    2,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 2 and CourseID = (select CourseID from Courses where CourseName = N'قواعد معطيات (2)')),
    (select CourseID from Courses where CourseName = N'قواعد معطيات (2)')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(), (select HallID from Halls where HallName = 'مخبر 2'));

-- عملي - شعبة 3
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    3,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 2 and CourseID = (select CourseID from Courses where CourseName = N'قواعد معطيات (2)')),
    (select CourseID from Courses where CourseName = N'قواعد معطيات (2)')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(),  (select HallID from Halls where HallName = 'القاعة 15'));

-- عملي - شعبة 4
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    4,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 2 and CourseID = (select CourseID from Courses where CourseName = N'قواعد معطيات (2)')),
    (select CourseID from Courses where CourseName = N'قواعد معطيات (2)')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(),  (select HallID from Halls where HallName = 'مخبر 2'));
go


-- ==================== نظم التشغيل ====================
-- نظري - شعبة 1
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    1,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 1 and CourseID = (select CourseID from Courses where CourseName = N'نظم التشغيل')),
    (select CourseID from Courses where CourseName = N'نظم التشغيل')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(),  (select HallID from Halls where HallName = 'القاعة 401'));

-- عملي - شعبة 1
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    1,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 2 and CourseID = (select CourseID from Courses where CourseName = N'نظم التشغيل')),
    (select CourseID from Courses where CourseName = N'نظم التشغيل')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(),  (select HallID from Halls where HallName = 'القاعة 10'));

-- عملي - شعبة 2
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    2,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 2 and CourseID = (select CourseID from Courses where CourseName = N'نظم التشغيل')),
    (select CourseID from Courses where CourseName = N'نظم التشغيل')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(), (select HallID from Halls where HallName = 'القاعة 10'));

-- عملي - شعبة 3
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    3,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 2 and CourseID = (select CourseID from Courses where CourseName = N'نظم التشغيل')),
    (select CourseID from Courses where CourseName = N'نظم التشغيل')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(), (select HallID from Halls where HallName = 'القاعة 10'));

-- عملي - شعبة 4
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    4,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 2 and CourseID = (select CourseID from Courses where CourseName = N'نظم التشغيل')),
    (select CourseID from Courses where CourseName = N'نظم التشغيل')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(), (select HallID from Halls where HallName = 'القاعة 10'));
go


-- ==================== نظم المعلومات الإدارية ====================
-- نظري - شعبة 1
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    1,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 1 and CourseID = (select CourseID from Courses where CourseName = N'نظم المعلومات الإدارية')),
    (select CourseID from Courses where CourseName = N'نظم المعلومات الإدارية')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(), (select HallID from Halls where HallName = 'القاعة 402'));

-- نظري - شعبة 2
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    2,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 1 and CourseID = (select CourseID from Courses where CourseName = N'نظم المعلومات الإدارية')),
    (select CourseID from Courses where CourseName = N'نظم المعلومات الإدارية')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(), (select HallID from Halls where HallName = 'القاعة 18'));

-- عملي - شعبة 1
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    1,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 2 and CourseID = (select CourseID from Courses where CourseName = N'نظم المعلومات الإدارية')),
    (select CourseID from Courses where CourseName = N'نظم المعلومات الإدارية')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(), (select HallID from Halls where HallName = 'مخبر 4'));

-- عملي - شعبة 2
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    2,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 2 and CourseID = (select CourseID from Courses where CourseName = N'نظم المعلومات الإدارية')),
    (select CourseID from Courses where CourseName = N'نظم المعلومات الإدارية')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(), (select HallID from Halls where HallName = 'مخبر 2'));

-- عملي - شعبة 3
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    3,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 2 and CourseID = (select CourseID from Courses where CourseName = N'نظم المعلومات الإدارية')),
    (select CourseID from Courses where CourseName = N'نظم المعلومات الإدارية')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(), (select HallID from Halls where HallName = 'مخبر 2'));

-- عملي - شعبة 4
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    4,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 2 and CourseID = (select CourseID from Courses where CourseName = N'نظم المعلومات الإدارية')),
    (select CourseID from Courses where CourseName = N'نظم المعلومات الإدارية')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(), (select HallID from Halls where HallName = 'مخبر 2'));
go


-- ==================== نظرية الحوسبة ====================
-- نظري - شعبة 1
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    1,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 1 and CourseID = (select CourseID from Courses where CourseName = N'نظرية الحوسبة')),
    (select CourseID from Courses where CourseName = N'نظرية الحوسبة')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(), (select HallID from Halls where HallName = 'القاعة 2'));

-- نظري - شعبة 2
insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (
    2,
    (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2),
    (select LectureID from Lectures where LectureType = 1 and CourseID = (select CourseID from Courses where CourseName = N'نظرية الحوسبة')),
    (select CourseID from Courses where CourseName = N'نظرية الحوسبة')
);
insert into CourseSessions (OfferingID, HallID) values (SCOPE_IDENTITY(), (select HallID from Halls where HallName = 'القاعة 2'));
go




select * from CourseOfferings;
select * from CourseSessions;