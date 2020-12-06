USE HealthMinister
GO

-- Question number 9
DROP VIEW IF EXISTS vw_List_Info
GO
CREATE VIEW vw_List_Info AS
SELECT TOP(100) * FROM dbo.Events
ORDER BY Sys_Date DESC
GO
-------------------------------------
ALTER VIEW vw_List_Info AS
SELECT TOP(100) 
CASE YEAR(Sys_Date)
WHEN 2017 THEN 'TOO OLD'
WHEN 2018 THEN 'OLD'
ELSE 'FRESH'
END AS Sys_Date,
Year FROM dbo.Events
ORDER BY Sys_Date DESC
GO

SELECT * FROM vw_List_Info
