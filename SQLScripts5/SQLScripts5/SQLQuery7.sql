select * from dbo.GetNums(15,20)

GO
CREATE FUNCTION sales.fn_LineTotal(@orderid int)
RETURNS TABLE -- Table-valued Functions
AS
RETURN 
(
-- (qty * unitprice - (qty * unitprice * discount) 
	SELECT orderid, productid,unitprice,qty,discount,
	  cast(qty * unitprice * (1 - discount) as decimal(8,2)) as lineTotal
	  from sales.OrderDetails
	  where orderid = @orderid
)
GO

select * from Sales.fn_LineTotal(10260)

GO
create function dbo.fn_TopProductBySuppliers2(@supplierid int,@productname nvarchar(50))
returns table -- Table-valued Functions
as
return
select top(3) productid, productname, unitprice, supplierid
from Production.Products
where supplierid = @supplierid or productname like  '%' + @productname
order by unitprice desc
GO

select * from dbo.fn_TopProductBySuppliers2(29,'w')
