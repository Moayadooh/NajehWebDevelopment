USE HealthMinister
GO

DROP VIEW IF EXISTS vw_List_Info
GO

CREATE VIEW vw_List_Info AS
SELECT TOP(100) * FROM dbo.Events
ORDER BY Sys_Date DESC
GO

SELECT * FROM vw_List_Info


-- OR
--CREATE VIEW vw_List_Info AS
--SELECT *, ROW_NUMBER() OVER (ORDER BY Sys_Date DESC) AS Row_Number FROM dbo.Events
