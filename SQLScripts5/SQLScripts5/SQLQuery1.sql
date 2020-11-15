-- show any customer who placed an order
select c.custid, c.companyname
from sales.Customers as c
where Exists(
select * from sales.Orders as o
where c.custid = o.custid
)

-- show any customer who has not placed an order
select c.custid, c.companyname
from sales.Customers as c
where not Exists(
select * from sales.Orders as o
where c.custid = o.custid
)
