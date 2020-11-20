
-- Casting
SELECT 1 + '2'
CAST(1 AS VARCHAR(10))
CAST(SYSDATETIME() AS DATE)

-- Convering
CONVERT(DATE,SYSDATETIME())
CONVERT(CHAR(12), CURRENT_TIMESTAMP,111) --ansi STYLE
--Date & time styles:
--https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql?view=sql-server-ver15

-- Parse
PARSE('11/24/2020' AS smalldatetime USING 'en-US')
PARSE('23/11/2020' AS DATE USING 'en-GB')
TRY_PARSE('ammar yaser' AS DATETIME) --return null or 

-- Concatenation
SELECT firstname + ' ' + lastname AS fullname FROM HR.Employees
CONCAT('ammar' ,' ','yaser')

SELECT lastname FROM HR.Employees WHERE lastname COLLATE Latin1_General_CS_AS = N'Funk' 

-- Strings
SELECT SUBSTRING('Microsoft SQL Server',11,3)
SELECT LEFT('Microsoft SQL Server',3)
SELECT RIGHT('Microsoft SQL Server',3)
SELECT LEN('Microsoft SQL Server        ')
SELECT DATALENGTH('Microsoft SQL Server        ')
SELECT UPPER('microsoft sql server')
SELECT LOWER('MICROSOFT SQL SERVER')
SELECT CHARINDEX('sql','microsoft sql server')
SELECT REPLACE('microsoft sql server','server','SERVER2019')
