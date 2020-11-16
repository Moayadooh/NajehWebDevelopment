create view Sales.CategorySales
as
select c.categoryname as category, 
o.empid as emp, 
o.custid as cust, 
od.qty, year(o.orderdate)
as orderyear from Production.Categories as c 
inner join Production.Products as p on c.categoryid = p.categoryid
inner join Sales.OrderDetails as od on p.productid = od.productid
inner join Sales.Orders as o on od.orderid = o.orderid
where (c.categoryid in(1,2,3)) and (o.custid between 1 and 5)
GO

select category,null as cust,sum(qty) as TotalQty
from sales.CategorySales
group by Category
union --all 
select null , Cust,sum(qty) as TotalQty
from sales.CategorySales
group by Cust
union --all
select null, null, sum(qty) as TotalQty
from sales.CategorySales
------------------------------------------------------------------------
select category, cust, sum(qty) as TotalQty
from sales.CategorySales
group by 
Grouping sets((category),(cust),())
--Grouping sets((),(cust),(category))
order by category,cust
-----------------------------------------------------------------
select category, cust, sum(qty) as TotalQty
from sales.CategorySales
group by CUBE (Category,Cust)
order by category,cust
--------------------------------------------------------------------
select category, cust, sum(qty) as TotalQty
from sales.CategorySales
group by ROLLUP (Category,Cust)
order by category,cust
