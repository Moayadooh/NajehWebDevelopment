USE HealthMinister
GO

SELECT * FROM dbo.FacilityType AS ft
WHERE EXISTS
(
	SELECT * FROM dbo.BasicGeneralFacilities AS bgf
	WHERE ft.ID = bgf.FacID
)
