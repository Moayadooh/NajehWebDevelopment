USE HealthMinister
GO

DROP SYNONYM IF EXISTS dbo.sp_CoinsPerSector
GO

CREATE SYNONYM dbo.sp_CoinsPerSector FOR dbo.sp_SumCoins
GO

DECLARE @T TABLE (SecID INT, Coin MONEY)
INSERT @T EXEC dbo.sp_CoinsPerSector
SELECT * FROM @T
