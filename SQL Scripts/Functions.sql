
CREATE DATABASE dbName
SELECT DB_NAME()
USE dbName
GO

-- Variable Declaration
declare @mysearch nvarchar(60);
set @mysearch =  (select ('microsoft sql server'))
select @mysearch

Declare
  @v1 as int = NULL,
  @v2 as int = 50,
  @v3 as int = 100

-- OFFSET "start from 51"
select orderid,custid,empid,orderdate
from sales.orders
order by orderdate, orderid
OFFSET 50 rows FETCH FIRST 50 rows only

-- Merge
Merge into Production.Products as p
using Production.ProductsStaging as s
on p.Productid = s.Productid
when Matched then
update set p.discontinued = s.discontinued
when not matched then
insert ([productname],[supplierid],[categoryid],[unitprice],[discontinued])
values (s.productname,s.supplierid,s.categoryid,s.unitprice,s.discontinued);

-- RANK
select top(5) productid,productname,unitprice,
RANK() over(order by unitprice Desc) as rankbyprice
from Production.Products

-- SWITCH CASE
select productid,productname,unitprice,
CASE discontinued
 WHEN 0 THEN 'ACTIVE'
 WHEN 1 THEN 'NONACTIVE'
 END AS Status
from Production.Products

-- Create Alies Name
select so.orderid from Sales.Orders as so


ISNUMERIC('1E3')
IIF(num > 50,'high','low') -- return high if more than 50, otherwise return low
CHOOSE(3,'Beverages','condiments','confections') -- return 'confections'

Declare
  @v1 as int = NULL,
  @v2 as int = 50,
  @v3 as int = 100

  select isnull(@v1 , @v3)
  select COALESCE(@v1 , @v2 , @v3)
  
NullIF(col1,col2) -- if both are equal return null else return col2 value

where id <> 3 -- exclude number 3