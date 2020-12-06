USE HealthMinister
GO

SELECT * FROM dbo.Events WHERE YEAR(Sys_Date) < '2020'
