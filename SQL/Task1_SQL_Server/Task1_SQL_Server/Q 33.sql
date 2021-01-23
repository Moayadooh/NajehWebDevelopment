USE HealthMinister
GO

DROP VIEW IF EXISTS vw_eventshow
GO

CREATE VIEW vw_eventshow AS
SELECT Events_Name, Events_Loc, Events_Detils
FROM dbo.Events
WHERE Events_Name LIKE 'c%'
GO

SELECT * FROM vw_eventshow
