USE [UniPlan];
GO




Create Or Alter Function ValidatePeriod(@StartTime time , @EndTime Time)
returns bit
begin 

IF NULLIF(LTRIM(RTRIM(@StartTime)), '') IS NULL
    or NULLIF(LTRIM(RTRIM(@EndTime)), '') IS NULL
	Begin 
	  return 0;
	End

	return 1;
End;
go








create or Alter Procedure SP_Period_Insert
@StartTime Time , @EndTime Time
As
Begin


select * from Periods;

End;
go