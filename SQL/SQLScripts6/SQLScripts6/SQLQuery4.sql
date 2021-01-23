CREATE PROCEDURE sp_GetCustomers
AS
BEGIN
	SELECT * from Sales.Customers
END
GO

EXEC dbo.sp_getCustomers
