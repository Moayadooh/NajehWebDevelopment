USE HealthMinister
GO

DROP FUNCTION IF EXISTS dbo.fn_Login
GO

CREATE FUNCTION fn_Login(@email NVARCHAR(30),@password NVARCHAR(30))
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM dbo.Users WHERE Email = @email AND User_Password = @password
)
GO

DROP PROCEDURE IF EXISTS dbo.sp_Login
GO

CREATE PROCEDURE dbo.sp_Login
	@email NVARCHAR(30) = NULL,
	@password NVARCHAR(30) = NULL
AS
BEGIN
	SELECT * FROM dbo.fn_Login(@email,@password)
END
GO

EXEC dbo.sp_Login @email = 'moayad@email.com', @password = '123'
