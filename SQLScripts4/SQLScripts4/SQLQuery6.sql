-- show numbers of orders for customers
select contactname, c.custid, count(*) as countorders
from Sales.Customers  as c
join sales.orders  as o
on c.custid  = o.custid
group by c.custid,contactname
order by countorders desc
----------------------------------------------
select contactname, c.custid, count(*) as countorders
from Sales.Customers  as c
join sales.orders  as o
on c.custid  = o.custid
group by c.custid,contactname
having count(*) > 15
order by countorders desc
-------------------------------------------------
-- Show number of order details per product id
select p.productid , COUNT(*) as [count order details]
from Production.Products as p
join Sales.OrderDetails as od
on p.productid  = od.productid
group by p.productid
having count(*) < 10
order by  [count order details] desc
---------------------------------------------------











