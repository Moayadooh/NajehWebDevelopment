USE HealthMinister
GO

DROP PROCEDURE IF EXISTS dbo.sp_SharedEvents
GO

CREATE PROCEDURE dbo.sp_SharedEvents
AS
BEGIN
	SELECT * FROM vw_eventshow
	INTERSECT
	SELECT Events_Name, Events_Loc, Events_Detils FROM Events
END
GO

EXEC dbo.sp_SharedEvents
