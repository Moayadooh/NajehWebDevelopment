USE HealthMinister
GO

-- Number of differences months between current date and first date in 2018
SELECT DATEDIFF(MONTH,
(SELECT MIN(Sys_Date) FROM dbo.Events WHERE YEAR(Sys_Date) = '2018'),
SYSDATETIME()) AS NumOfMonths

-- Expected date after 3 months from now
SELECT DATEADD(MONTH,3,SYSDATETIME()) AS DateAfter3Month
