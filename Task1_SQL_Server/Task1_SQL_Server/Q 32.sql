USE HealthMinister
GO

DROP PROCEDURE IF EXISTS dbo.SumCoinsPerGov
GO

CREATE PROCEDURE dbo.SumCoinsPerGov
	@govName NVARCHAR(30) = NULL
AS
BEGIN
	WITH CTE AS
	(
		SELECT b.SecID AS SecID, g.Gov_Name AS Gov_Name, b.Coin AS Coin
		FROM dbo.BasicGeneralFacilities AS b
		INNER JOIN dbo.Governorates AS g
		ON b.GovID = g.ID
	)
	SELECT Gov_Name, SecID, SUM(Coin) AS Coins FROM CTE
	WHERE Gov_Name LIKE @govName
	GROUP BY CUBE (Gov_Name,SecID)
	ORDER BY Gov_Name, SecID
END
GO

EXEC dbo.SumCoinsPerGov @govName = '%'
