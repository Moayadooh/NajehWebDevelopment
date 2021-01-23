USE HealthMinister
GO

DROP VIEW IF EXISTS vw_Inner_Join
GO

CREATE VIEW vw_Inner_Join AS
SELECT b.Name, b.National_Num, b.Area, d.Dir_Name
FROM dbo.BasicGeneralFacilities AS b
INNER JOIN
dbo.Directorates AS d
ON b.WPlace = d.WPlace;
GO

SELECT * FROM vw_Inner_Join;
