USe Tsql
Go
-----------------------------------------------------------------------------
select empid, Year(TSQL.Sales.Orders.orderdate) as OrderYear,
count(*) as numberOforders
from Sales.Orders
where custid = 71
group by empid,YEAR(Orders.orderdate)
order by empid,OrderYear
-----------------------------------------------------------------------------
select [productid],[productname],([unitprice] * 2) as [unit Price]
from Production.Products
-----------------------------------------------------------------------------
select orderid,productid,unitprice , qty ,(unitprice * qty) as Result
from sales.OrderDetails
-----------------------------------------------------------------------------
select distinct custid, shipcity, shipcountry
from Sales.Orders 
----------------------------------------------------------
select so.orderid , so.orderdate , so.empid
from Sales.Orders as so
----------------------------------------------------------
select productid,productname,unitprice,
CASE discontinued
 WHEN 0 THEN 'ACTIVE'
 WHEN 1 THEN 'NONACTIVE'
 END AS Status
from Production.Products
-----------------------------------------------------------
select orderid,custid,orderdate,
case empid
when 1 then 'ammar'
when 2 then 'Mouyyad'
when 3 then 'loay'
when 4 then 'Mohammad'
when 5 then 'balqees'
when 6 then 'fatima'
when 7 then 'ayat'
when 8 then 'iman'
else 'Uknown'
end as salesperson
from sales.orders
