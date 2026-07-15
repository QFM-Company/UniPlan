use [UniPlan];
go


if not exists (select 1 from AcademicTerms where TermType = 2 and TermYear = '2026')
begin
    insert into AcademicTerms (TermType, TermYear)
    values (2, '2026');
end
go


declare @TermID int = (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2);
declare @OfferingID int;
declare @CurrentSessionID int;


insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (1, @TermID, 71, 53);
set @OfferingID = SCOPE_IDENTITY();
exec SP_CourseSessions_Insert @OfferingID, 3, 0, '10:00:00', '11:30:00', 1, @CurrentSessionID OUTPUT;


insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (1, @TermID, 72, 53);
set @OfferingID = SCOPE_IDENTITY();
exec SP_CourseSessions_Insert @OfferingID, 18, 0, '12:00:00', '13:30:00', 1, @CurrentSessionID OUTPUT;


insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (2, @TermID, 72, 53);
set @OfferingID = SCOPE_IDENTITY();
exec SP_CourseSessions_Insert @OfferingID, 19, 0, '10:00:00', '11:30:00', 2, @CurrentSessionID OUTPUT;
go


declare @TermID int = (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2);
declare @OfferingID int;
declare @CurrentSessionID int;


insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (1, @TermID, 69, 52);
set @OfferingID = SCOPE_IDENTITY();
exec SP_CourseSessions_Insert @OfferingID, 4, 0, '10:00:00', '13:00:00', 1, @CurrentSessionID OUTPUT;


insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (1, @TermID, 70, 52);
set @OfferingID = SCOPE_IDENTITY();
exec SP_CourseSessions_Insert @OfferingID, 20, 0, '12:00:00', '13:30:00', 1, @CurrentSessionID OUTPUT;


insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (2, @TermID, 70, 52);
set @OfferingID = SCOPE_IDENTITY();
exec SP_CourseSessions_Insert @OfferingID, 21, 0, '12:00:00', '13:30:00', 2, @CurrentSessionID OUTPUT;
go


declare @TermID int = (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2);
declare @OfferingID int;
declare @CurrentSessionID int;


insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (1, @TermID, 79, 58);
set @OfferingID = SCOPE_IDENTITY();
exec SP_CourseSessions_Insert @OfferingID, 5, 0, '10:00:00', '11:30:00', 5, @CurrentSessionID OUTPUT;


insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (1, @TermID, 80, 58);
set @OfferingID = SCOPE_IDENTITY();
exec SP_CourseSessions_Insert @OfferingID, 18, 0, '12:00:00', '13:30:00', 5, @CurrentSessionID OUTPUT;


insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (2, @TermID, 80, 58);
set @OfferingID = SCOPE_IDENTITY();
exec SP_CourseSessions_Insert @OfferingID, 19, 0, '10:00:00', '11:30:00', 6, @CurrentSessionID OUTPUT;
go


declare @TermID int = (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2);
declare @OfferingID int;
declare @CurrentSessionID int;


insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (1, @TermID, 53, 43);
set @OfferingID = SCOPE_IDENTITY();
exec SP_CourseSessions_Insert @OfferingID, 6, 0, '10:00:00', '13:00:00', 6, @CurrentSessionID OUTPUT;


insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (1, @TermID, 54, 43);
set @OfferingID = SCOPE_IDENTITY();
exec SP_CourseSessions_Insert @OfferingID, 20, 0, '14:00:00', '15:30:00', 6, @CurrentSessionID OUTPUT;


insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (2, @TermID, 54, 43);
set @OfferingID = SCOPE_IDENTITY();
exec SP_CourseSessions_Insert @OfferingID, 21, 0, '10:00:00', '11:30:00', 6, @CurrentSessionID OUTPUT;
go


declare @TermID int = (select TermID from AcademicTerms where TermYear = 2026 and TermType = 2);
declare @OfferingID int;
declare @CurrentSessionID int;


insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (1, @TermID, 65, 50);
set @OfferingID = SCOPE_IDENTITY();
exec SP_CourseSessions_Insert @OfferingID, 7, 0, '10:00:00', '13:00:00', 2, @CurrentSessionID OUTPUT;


insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (1, @TermID, 66, 50);
set @OfferingID = SCOPE_IDENTITY();
exec SP_CourseSessions_Insert @OfferingID, 18, 0, '14:00:00', '15:30:00', 2, @CurrentSessionID OUTPUT;


insert into CourseOfferings (SectionNumber, TermID, LectureID, CourseID)
values (2, @TermID, 66, 50);
set @OfferingID = SCOPE_IDENTITY();
exec SP_CourseSessions_Insert @OfferingID, 19, 0, '14:00:00', '15:30:00', 5, @CurrentSessionID OUTPUT;
go

select * from CourseOfferings;
select * from CourseSessions_view;