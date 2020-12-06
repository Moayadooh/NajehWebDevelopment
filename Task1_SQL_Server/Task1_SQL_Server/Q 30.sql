USE HealthMinister
GO

DROP PROCEDURE IF EXISTS dbo.sp_RoleName
GO

CREATE PROCEDURE dbo.sp_RoleName
	@num INT = NULL
AS
BEGIN
	DECLARE @name NVARCHAR(30)
	IF(@num = 1)
		SET @name = 'Admin'
	ELSE IF(@num = 2)
		SET @name = 'Superviser'
	ELSE IF(@num = 3)
		SET @name = 'User'
	ELSE
		SET @name = 'None'
	SELECT @name AS RoleName
END
GO

DECLARE @groupID AS INT = (SELECT GroupID FROM dbo.Users WHERE ID = 3)
EXEC dbo.sp_RoleName @num = @groupID
