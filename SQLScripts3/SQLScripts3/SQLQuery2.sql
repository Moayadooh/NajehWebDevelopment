select orderid,custid,year(orderdate) as orderyear
from sales.Orders
where Year(orderdate) = '2006'
---------------------------------------------------------
select companyname,contactname,country
from sales.Customers
where country = N'Spain'
---------------------------------------------------------
select orderid,orderdate
from sales.Orders
where orderdate > '20070101'
--------------------------------------------------------
select companyname,contactname,country
from sales.Customers
where country = N'Spain' or country=N'GErmany'
-----------------------------------------------
select companyname,contactname,country
from sales.Customers
where country in  (N'Spain',N'Germany',N'UK')
-------------------------------------------------------
select orderid,orderdate
from sales.Orders
where orderdate > '20070101' and orderdate <= '20071231'
----------------------------------------------------------
select companyname,contactname,country
from sales.Customers
where country not in  (N'Spain',N'Germany',N'UK')
------------------------------------------------------------------------
select orderid,orderdate
from sales.Orders
where orderdate between '20070101' and '20071231'
-----------------------------------------------------------------------







