-- Cross Apply
-- Show 3 most recent order for customers with orderid and orderdate
-- Show customer has an orders
select c.custid, toporder.orderid , toporder.orderdate
from Sales.Customers as c
cross apply
(select top(3) o.orderid, o.orderdate 
from sales.Orders as o
where o.custid = c.custid
order by o.orderdate desc) as toporder
---------------------------------------
-- Show customers with no orders

select c.custid, toporder.orderid , toporder.orderdate
from Sales.Customers as c
outer apply
(select top(3) o.orderid, o.orderdate 
from sales.Orders as o
where o.custid = c.custid
order by o.orderdate desc, orderid desc) as toporder

-------------------------------
select  o.orderid, o.orderdate 
from sales.Orders as o
where o.custid = 1
order by orderdate desc


