USE HealthMinister
GO

DROP FUNCTION IF EXISTS fn_GetCoin
GO

CREATE FUNCTION fn_GetCoin(@id INT)
RETURNS MONEY
AS
BEGIN
	DECLARE @coin MONEY = 0
	SET @coin  =  (SELECT Coin FROM dbo.BasicGeneralFacilities WHERE ID = @id)
	RETURN @coin
END
GO

SELECT dbo.fn_GetCoin(2) AS Coin
