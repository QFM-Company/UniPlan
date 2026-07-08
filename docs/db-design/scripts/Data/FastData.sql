USE [UniPlan];
Go

Declare @PersonID int;
Declare @AccountID int;

insert into People (FirstName , LastName)
Values('Fares' , 'Oyion');

select @PersonID = SCOPE_IDENTITY();

insert into Accounts (AccountName , Email , Password)
values('Fares' , 'fares.oyion123@gmail.com' , '1234')

select @AccountID = SCOPE_IDENTITY();

insert into Administrators (AccountID , IsActive , PersonID)
values (@AccountID , 1 , @PersonID);