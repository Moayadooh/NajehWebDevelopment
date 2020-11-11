use TSQL
Go
-----------------------

select empid,lastname
from HR.Employees
where lastname Collate Latin1_General_CS_AS = N'Funk' 
-----------------------
select empid,lastname
from HR.Employees
where lastname Collate Latin1_General_CS_AS = N'funk' 
-------------------------------------------------------------------
select empid,lastname, firstname , firstname + ' ' + lastname as fullname
from HR.Employees
------------------------------------------------------------------
select SUBSTRING('Microsoft SQL Server',11,3)
select LEFT('Microsoft SQL Server',3)
select right('Microsoft SQL Server',3)
select LEN('Microsoft SQL Server        ')
select DataLength('Microsoft SQL Server        ')
select Concat('Microsoft',' SQL Server')
-----------------------------------------------------------------------
select UPPER('microsoft sql server')
select lower('MICROSOFT SQL SERVER')
select CHARINDEX('sql','microsoft sql server')
select CHARINDEX('XD','microsoft sql server')
---------------------------------------------------
declare @mysearch nvarchar(60);
set @mysearch =  (select REPLACE('microsoft sql server','server','SERVER2019'))
select @mysearch AS [FINAL RESULT]
UPDATE HR.Employees SET address= @mysearch WHERE empid=12
------------------------------------------------------------------------------
