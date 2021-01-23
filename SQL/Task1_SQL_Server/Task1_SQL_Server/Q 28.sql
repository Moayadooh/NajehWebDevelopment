USE HealthMinister
GO

DROP PROCEDURE IF EXISTS dbo.sp_Dynamic_Pagination
GO

CREATE PROCEDURE dbo.sp_Dynamic_Pagination
	@num INT = NULL
AS
BEGIN
	SELECT * FROM dbo.Governorates
	ORDER BY ID
	OFFSET @num ROWS FETCH FIRST 100 ROWS ONLY
END
GO

EXEC dbo.sp_Dynamic_Pagination @num = 0 -- 100, 200, 300 ...
