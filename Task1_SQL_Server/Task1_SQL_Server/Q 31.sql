USE HealthMinister
GO

DROP PROCEDURE IF EXISTS dbo.sp_SumCoins
GO

CREATE PROCEDURE dbo.sp_SumCoins
AS
BEGIN
	SELECT SecID, SUM(Coin) AS SumCoins FROM dbo.BasicGeneralFacilities GROUP BY SecID
END
GO

EXEC dbo.sp_SumCoins
