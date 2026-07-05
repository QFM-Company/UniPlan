USE [UniPlan];
GO





Create Or Alter Function CheckUniqeCourseName(@CourseName nvarchar(100))
returns int
As
Begin
     if(Exists(select 1 from Courses where CourseName = @CourseName))
	     return 0;

     return 1;
End
go




Create Or Alter Function CheckUniqeCourseCode(@CourseCode nvarchar(8))
returns int
As
Begin
     
	 if @CourseCode is null return 1;

     if(Exists(select 1 from Courses where CourseCode = @CourseCode))
	     return 0;

     return 1;
End
go


CREATE OR ALTER PROCEDURE SP_Courses_Insert
    @CourseName NVARCHAR(100),
    @CreditHours INT,
    @CourseID INT OUT,
	@CourseCode nvarchar(8)
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@CourseName)), '') IS NULL
        OR @CreditHours <= 0
    BEGIN
        ;THROW 50901, 'Course validation failed', 1;
    END

	
	 IF NULLIF(LTRIM(RTRIM(@CourseCode)), '') IS NULL
	 Begin
	     set @CourseCode = null;
     End

	IF (dbo.CheckUniqeCourseName(@CourseName) = 0)
	Begin
	    ;THROW 50902, 'Course Name Already Exist', 1;
	END
	
	IF (dbo.CheckUniqeCourseCode(@CourseCode) = 0)
	Begin
	    ;THROW 50902, 'Course Code Already Exist', 1;
	END


    BEGIN TRY
        INSERT INTO [dbo].[Courses]
        (
            [CourseName],
            [CreditHours],
			[CourseCode]
        )
        VALUES
        (
            @CourseName,
            @CreditHours,
			@CourseCode
        );

        SET @CourseID = CONVERT(INT, SCOPE_IDENTITY());
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO


CREATE OR ALTER PROCEDURE SP_Courses_Update
    @CourseID INT,
    @CourseName NVARCHAR(100),
	@CourseCode NVARCHAR(8),
    @CreditHours INT,
    @Result BIT OUT
AS
BEGIN
    SET NOCOUNT ON;

    IF @CourseID <= 0
        OR NULLIF(LTRIM(RTRIM(@CourseName)), '') IS NULL
        OR @CreditHours <= 0
    BEGIN
        ;THROW 50901, 'Course validation failed', 1;
    END

	
	 IF NULLIF(LTRIM(RTRIM(@CourseCode)), '') IS NULL
	 Begin
	     set @CourseCode = null;
     End

	IF (dbo.CheckUniqeCourseName(@CourseName) = 0 And @CourseName <> (select Courses.CourseName from Courses where CourseID = @CourseID))
	Begin
	    ;THROW 50902, 'Course Name Already Exist', 1;
	END

	IF (dbo.CheckUniqeCourseCode(@CourseCode) = 0 And @CourseCode <> (select Courses.CourseCode from Courses where CourseID = @CourseID))
	Begin
	    ;THROW 50902, 'Course Code Already Exist', 1;
	END


    BEGIN TRY
        UPDATE [dbo].[Courses]
        SET
            [CourseName] = @CourseName,
            [CreditHours] = @CreditHours,
			[CourseCode] = @CourseCode
        WHERE [CourseID] = @CourseID;

        IF @@ROWCOUNT > 0
            SET @Result = 1;
        ELSE
            SET @Result = 0;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO


CREATE OR ALTER PROCEDURE SP_Courses_Delete
    @CourseID INT,
    @Result BIT OUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DELETE FROM [dbo].[Courses]
        WHERE [CourseID] = @CourseID;

        IF @@ROWCOUNT > 0
            SET @Result = 1;
        ELSE
            SET @Result = 0;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO


Create Or Alter View VW_Courses
AS
select * from Courses;
go


CREATE OR ALTER PROCEDURE SP_Courses_GetAll
    @PageNumber INT = 1,
    @PageSize INT = 10
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF @PageNumber IS NULL OR @PageNumber < 1
            SET @PageNumber = 1;

        IF @PageSize IS NULL OR @PageSize < 1
            SET @PageSize = 10;

        SELECT * from VW_Courses
		order by CourseID
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO




CREATE OR ALTER PROCEDURE SP_Courses_GetById
    @CourseID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT * from VW_Courses
        WHERE CourseID = @CourseID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO