
-- Casting
select 1 + '2'
CAST(1 as varchar(10))
CAST(SYSDATETIME() as date)

-- Convering
CONVERT(date,SYSDATETIME())
CONVERT(CHAR(12), CURRENT_TIMESTAMP,111) --ansi STYLE
--Date and time styles:
--https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql?view=sql-server-ver15

-- Parse
parse('11/24/2020' as smalldatetime using 'en-US')
parse('23/11/2020' as date using 'en-GB')
TRY_PARSE('ammar yaser' as datetime) --return null or 

-- Concatenation
select firstname + ' ' + lastname as fullname from HR.Employees
CONCAT('ammar' ,' ','yaser')

select lastname from HR.Employees where lastname Collate Latin1_General_CS_AS = N'Funk' 

-- Strings
select SUBSTRING('Microsoft SQL Server',11,3)
select LEFT('Microsoft SQL Server',3)
select right('Microsoft SQL Server',3)
select LEN('Microsoft SQL Server        ')
select DataLength('Microsoft SQL Server        ')
select UPPER('microsoft sql server')
select lower('MICROSOFT SQL SERVER')
select CHARINDEX('sql','microsoft sql server')
select REPLACE('microsoft sql server','server','SERVER2019')
