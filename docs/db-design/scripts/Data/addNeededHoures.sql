


Alter Table Students
Add [CompletedHours] int not null default 0;


Alter Table Courses
Add	[NeededHours] int not null default 0;

update Courses
set NeededHours = 100
where CourseName = 'مشروع فصلي';


update Courses
set NeededHours = 125
where CourseName = 'مشروع تخرج';