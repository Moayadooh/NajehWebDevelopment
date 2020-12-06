USE HealthMinister
GO

DROP PROCEDURE IF EXISTS dbo.sp_NotSharedEvents
GO

CREATE PROCEDURE dbo.sp_NotSharedEvents
AS
BEGIN
	WITH CTE AS
	(
		SELECT Events_Name FROM Events
		EXCEPT
		SELECT Events_Name FROM vw_eventshow
	)
	SELECT * FROM CTE
END
GO

EXEC dbo.sp_NotSharedEvents
