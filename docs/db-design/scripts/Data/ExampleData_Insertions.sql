-- Add Data For Trying

use [UniPlan];
go



-- اضافة الفصل العام للبرنامج
if not Exists(select 1 from AcademicTerms where TermType = 2 And TermYear = '2026')
begin
insert into AcademicTerms(TermType , TermYear)
values (2 , '2026');
End

-- مادة قواعد 2
-- اولا يجب اضافة الشعب و الفئات

insert into CourseOfferings(SectionNumber , TermID , LectureID , CourseID)
Values 
(
1 , 
(select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
(select LectureID from Lectures where LectureType = 1 And CourseID = (select CourseID from Courses where CourseName = 'قواعد معطيات (2)')),
(select CourseID from Courses where CourseName = 'قواعد معطيات (2)')
)
,
(
2 , 
(select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
(select LectureID from Lectures where LectureType = 1 And CourseID = (select CourseID from Courses where CourseName = 'قواعد معطيات (2)')),
(select CourseID from Courses where CourseName = 'قواعد معطيات (2)')
)
,
(
1 , 
(select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
(select LectureID from Lectures where LectureType = 2 And CourseID = (select CourseID from Courses where CourseName = 'قواعد معطيات (2)')),
(select CourseID from Courses where CourseName = 'قواعد معطيات (2)')
)
,
(
2 , 
(select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
(select LectureID from Lectures where LectureType = 2 And CourseID = (select CourseID from Courses where CourseName = 'قواعد معطيات (2)')),
(select CourseID from Courses where CourseName = 'قواعد معطيات (2)')
)
,
(
3 , 
(select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
(select LectureID from Lectures where LectureType = 2 And CourseID = (select CourseID from Courses where CourseName = 'قواعد معطيات (2)')),
(select CourseID from Courses where CourseName = 'قواعد معطيات (2)')
)
,
(
4 , 
(select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
(select LectureID from Lectures where LectureType = 2 And CourseID = (select CourseID from Courses where CourseName = 'قواعد معطيات (2)')),
(select CourseID from Courses where CourseName = 'قواعد معطيات (2)')
)



go





-- مادة نظم التشغيل
-- الشعب و الفئات اولا

insert into CourseOfferings(SectionNumber , TermID , LectureID , CourseID)
Values 
(
 1,
 (select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
 (select LectureID from Lectures where LectureType = 1 And CourseID = (select CourseID from Courses where CourseName = 'نظم التشغيل')),
 (select CourseID from Courses where CourseName = 'نظم التشغيل')
)
,
(
 1,
 (select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
 (select LectureID from Lectures where LectureType = 2 And CourseID = (select CourseID from Courses where CourseName = 'نظم التشغيل')),
 (select CourseID from Courses where CourseName = 'نظم التشغيل')
)
,
(
 2,
 (select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
 (select LectureID from Lectures where LectureType = 2 And CourseID = (select CourseID from Courses where CourseName = 'نظم التشغيل')),
 (select CourseID from Courses where CourseName = 'نظم التشغيل')
)

,
(
 3,
 (select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
 (select LectureID from Lectures where LectureType = 2 And CourseID = (select CourseID from Courses where CourseName = 'نظم التشغيل')),
 (select CourseID from Courses where CourseName = 'نظم التشغيل')
)
,
(
 4,
 (select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
 (select LectureID from Lectures where LectureType = 2 And CourseID = (select CourseID from Courses where CourseName = 'نظم التشغيل')),
 (select CourseID from Courses where CourseName = 'نظم التشغيل')
)



go





-- مادة نظم ادارية
-- الشعب و الفئات اولا

insert into CourseOfferings(SectionNumber , TermID , LectureID , CourseID)
Values 
(
 1,
 (select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
 (select LectureID from Lectures where LectureType = 1 And CourseID = (select CourseID from Courses where CourseName = 'نظم المعلومات الإدارية')),
 (select CourseID from Courses where CourseName = 'نظم المعلومات الإدارية')
)
,
(
 2,
 (select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
 (select LectureID from Lectures where LectureType = 1 And CourseID = (select CourseID from Courses where CourseName = 'نظم المعلومات الإدارية')),
 (select CourseID from Courses where CourseName = 'نظم المعلومات الإدارية')
)
,
(
 1,
 (select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
 (select LectureID from Lectures where LectureType = 2 And CourseID = (select CourseID from Courses where CourseName = 'نظم المعلومات الإدارية')),
 (select CourseID from Courses where CourseName = 'نظم المعلومات الإدارية')
)
,
(
 2,
 (select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
 (select LectureID from Lectures where LectureType = 2 And CourseID = (select CourseID from Courses where CourseName = 'نظم المعلومات الإدارية')),
 (select CourseID from Courses where CourseName = 'نظم المعلومات الإدارية')
)
,
(
 3,
 (select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
 (select LectureID from Lectures where LectureType = 2 And CourseID = (select CourseID from Courses where CourseName = 'نظم المعلومات الإدارية')),
 (select CourseID from Courses where CourseName = 'نظم المعلومات الإدارية')
)
,
(
 4,
 (select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
 (select LectureID from Lectures where LectureType = 2 And CourseID = (select CourseID from Courses where CourseName = 'نظم المعلومات الإدارية')),
 (select CourseID from Courses where CourseName = 'نظم المعلومات الإدارية')
)

go





-- مادة نظرية الحوسبة
-- الشعب و اولا

insert into CourseOfferings(SectionNumber , TermID , LectureID , CourseID)
Values 
(
 1,
 (select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
 (select LectureID from Lectures where LectureType = 1 And CourseID = (select CourseID from Courses where CourseName = 'نظرية الحوسبة')),
 (select CourseID from Courses where CourseName = 'نظرية الحوسبة')
)
,
(
 2,
 (select TermID from AcademicTerms where TermYear = 2026 And TermType = 2),
 (select LectureID from Lectures where LectureType = 1 And CourseID = (select CourseID from Courses where CourseName = 'نظرية الحوسبة')),
 (select CourseID from Courses where CourseName = 'نظرية الحوسبة')
)



GO

select * from CourseOfferings