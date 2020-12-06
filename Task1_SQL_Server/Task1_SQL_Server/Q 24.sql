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
WITH CTE AS
(
	SELECT *, RANK() OVER(ORDER BY Sys_Date Desc) AS rankbydate FROM vw_List_Info
)
SELECT * FROM CTE
