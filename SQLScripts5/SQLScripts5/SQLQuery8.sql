
go
create function dbo.fn_TopProductBySuppliers2(@supplierid int,@productname nvarchar(50))
returns table -- Table-valued Functions
as
return
select top(3) productid, productname, unitprice, supplierid
from Production.Products
where supplierid = @supplierid or productname like  '%' + @productname
order by unitprice desc
go

select * from dbo.fn_TopProductBySuppliers2(29,'w')
