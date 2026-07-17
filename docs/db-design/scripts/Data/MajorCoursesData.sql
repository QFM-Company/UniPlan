USE [UniPlan];
GO

delete MajorCourses;

Declare @MainMajor int;

select @MainMajor = Majors.MajorID from Majors where MajorName = 'هندسة المعلوماتية - اختصاص عام';


insert into MajorCourses(MajorID , CourseID)
(select @MainMajor , c.CourseID from Courses c);

select @MainMajor = Majors.MajorID from Majors where MajorName = 'هندسة برمجيات';

update MajorCourses 
set MajorID = @MainMajor
where CourseID in (select CourseID from Courses where CourseName in ('برمجة تفرعية' , 'بناء مترجمات' , 'نظم استرجاع البيانات' , 'قواعد معطيات متقدمة' , 'هندسة برمجيات (2)' , 'الحوسبة النقالة'));

select @MainMajor = Majors.MajorID from Majors where MajorName = 'هندسة شبكات';

update MajorCourses
set MajorID = @MainMajor
where CourseID in (select CourseID from Courses where CourseName in ('الشبكات اللاسلكية' , 'أمن شبكات حاسوبية' , 'إدارة شبكات' , 'تصميم شبكات'));

insert into MajorCourses(MajorID , CourseID)
values
   ( @MainMajor , (select Courses.CourseID from Courses where CourseName = 'برمجة تفرعية') ) ,
   ( @MainMajor , (select Courses.CourseID from Courses where CourseName = 'الحوسبة النقالة') );

select @MainMajor = MajorID from Majors where MajorName = 'هندسة ذكاء صنعي';


update MajorCourses
set MajorID = @MainMajor
where CourseID in (select CourseID from Courses where CourseName in ('التعلم الآلي والشبكات العصبونية' , 'الرؤية الحاسوبية' , 'النمذجة والمحاكاة' , 'الرجل الآلي والنظم الخبيرة'));


insert into MajorCourses(MajorID , CourseID)
values
   ( @MainMajor , (select Courses.CourseID from Courses where CourseName = 'برمجة تفرعية') ),
   ( @MainMajor , (select Courses.CourseID from Courses where CourseName = 'نظم استرجاع البيانات') );
go


select * from MajorCourses
