select top(5) productid,productname,unitprice,
RANK() over(order by unitprice Desc) as rankbyprice
from Production.Products
--order by rankbyprice
---------------------------------------
select count(*) as numorders , sum(unitprice) as totalsales
from sales.OrderDetails;

select DB_NAME() as currentdb 
