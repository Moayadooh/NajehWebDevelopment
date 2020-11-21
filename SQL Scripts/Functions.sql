
-- Table-valued Functions
DROP FUNCTION IF EXISTS fn_Name
GO

CREATE FUNCTION fn_Name(@id INT)
RETURNS TABLE
AS
RETURN
(
	SELECT ...
)
GO

SELECT * FROM dbo.fn_Name(3)


-- Scalar-valued Functions
DROP FUNCTION IF EXISTS fn_Name
GO

CREATE FUNCTION fn_Name(@id INT)
RETURNS MONEY
AS
BEGIN
	DECLARE @var INT = 0
	SET @var  =  (SELECT ...)
	RETURN @var
END
GO

SELECT dbo.fn_Name(2) AS ColumnName
