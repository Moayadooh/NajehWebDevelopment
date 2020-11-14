select max(orderid) as lastorder
from sales.Orders

-- find order details in sales.orderdetails for most recent order
select orderid,productid, unitprice, qty 
from sales.OrderDetails
where orderid =(select max(orderid) as lastorder
from sales.Orders)
----------------------------------------------------------------
select orderid,productid, unitprice, qty 
from sales.OrderDetails
where orderid =(select orderid as lastorder
from sales.Orders
where orderid = 10248
)
-- You can return single value from another table in subquery
----------------------------------------------
select od.orderid,productid, unitprice, qty 
from sales.OrderDetails as od
join sales.Orders as o
on od.orderid = o.orderid
where empid =2
---------------------------------------------------------
-- Note: you can't return from another field in Subquery returned more than 1 value
-------------------------------------------------------------------------
-- return order info for customers in GErmany

select custid, orderid 
from sales.Orders
where custid in 
(select custid from sales.Customers 
where country = 'Germany' and contactname='Poland, Carole')
--------------------------------------------------------------------------
select c.custid, o.orderid, c.contactname
from sales.Customers as c
join Sales.Orders as o
on c.custid = o.custid
where c.country = 'Germany' and contactname = 'Poland, Carole'
---------------------------------------------------------------------------
-- return most recent order per customer
select custid, orderid, orderdate
from Sales.orders as outerorders
where orderdate = 
(select max(orderdate) from
 Sales.Orders as innerorders
 where outerorders.custid = innerorders.custid
)
