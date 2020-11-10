--ANSI SQL-89
select c.companyname, o.orderdate 
from Sales.Customers as c, Sales.orders as o 
where c.custid = o.cust.id

--ANSI SQL-92
select c.companyname, o.orderdate 
from Sales.Customers as c inner join Sales.orders as o 
ON c.custid = o.cust.id
----------------------------------------------------------------
select c.categoryid, c.categoryname, p.productid, p.productname 
from Production.Categories as c 
inner join 
Production.Products as p 
on c.categoryid = p.categoryid
----------------------------------------------------------------
select c.custid, c.companyname, o.orderid, o.orderdate 
from sales.Customers as c 
left outer join  --or left join
sales.orders as o 
on c.custid = o.custid
----------------------------------------------------------------
select c.custid, c.companyname, o.orderid, o.orderdate 
from sales.Customers as c 
right outer join --or right join
sales.orders as o 
on c.custid = o.custid 
--where c.custid is null
----------------------------------------------------------------
select e1.firstname, e2.lastname from 
HR.Employees as e1 cross join hr.Employees as e2
----------------------------------------------------------------
select c.custid, c.companyname, o.orderid, o.orderdate 
from sales.Customers as c 
full outer join --or full join
sales.orders as o 
on c.custid = o.custid 
