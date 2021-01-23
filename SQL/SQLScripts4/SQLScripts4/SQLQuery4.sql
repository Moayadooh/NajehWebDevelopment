-- show number orders per employee from orders table

select empid , count(*) as countorders
from sales.orders
group by empid
order by countorders desc
--------------------------------------------------------------
-- Show Total number of Customers for employee has id 3 per year

select empid, custid, year(orderdate) as orderyear,
count(*) as countall
from sales.orders
where empid=3
group by empid, custid,year(orderdate) 
--------------------------------------------------------------------
select empid , count(*) as countorders
from sales.orders
where custid <> 3
group by empid
order by countorders desc
------------------------------------------
-- show the max quantity of order details per product.

select productid,max(qty) as largest_order
from sales.OrderDetails
group by productid;
-----------------------------------------
-- show total of orders for cutomers if the orders greater than 10
select custid, count(*) as count_orders
from sales.Orders
group by custid
having count(*) >=10
--------------------------------------
select custid, count(*) as count_orders
from sales.Orders
group by custid
having count_orders >=10 -- count_orders as alias name 
--------------------------------------------------------
declare @count_orders int
set @count_orders =  (select count(*) from sales.Orders)
select custid, count(*) as count_orders
from sales.Orders
group by custid
having @count_orders >=10
-------------------------------------------------------------