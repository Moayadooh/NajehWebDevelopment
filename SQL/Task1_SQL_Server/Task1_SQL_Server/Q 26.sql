USE HealthMinister
GO

DROP FUNCTION IF EXISTS fn_GetRow
GO

CREATE FUNCTION fn_GetRow(@id INT)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM dbo.Sectors WHERE ID = @id
)
GO

SELECT * FROM dbo.fn_GetRow(3)