CREATE PROCEDURE sales.sp_GetCustPhone
	@custid int,
	@phone nvarchar(30) output
AS
BEGIN
select @phone = phone from Sales.Customers where custid = @custid
END
GO

declare @customerid int = 5, @phonenum nvarchar(30);
Exec sales.sp_GetCustPhone @custid = @customerid, @phone = @phonenum output;
select @phonenum as phone, @customerid as customerID 
