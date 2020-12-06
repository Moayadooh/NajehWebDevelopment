USE HealthMinister
GO

DECLARE @i AS INT, @year VARCHAR(4)
SET @i=1
WHILE @i <= 10
BEGIN
UPDATE dbo.Events SET Year = YEAR(Sys_Date) WHERE ID = @i
SELECT @year = Year FROM dbo.Events WHERE ID = @i
SET @i += 1
END
GO

SELECT * FROM dbo.Events
