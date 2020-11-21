
DROP PROCEDURE IF EXISTS dbo.sp_Name
GO

CREATE PROCEDURE dbo.sp_Name
	@var INT = NULL
AS
BEGIN
	SELECT ...
END
GO

EXEC dbo.sp_Name @var = 0
