create proc Production.sp_GetbySuppliers
@supplierid as int,
@numrows as bigint
as
select top(@numrows) Productid, 
productname,
Categoryid,
unitprice,
discontinued
from Production.Products
where supplierid=@supplierid
order by productid
Go

Exec Production.sp_GetbySuppliers @supplierid=1, @numrows=2
