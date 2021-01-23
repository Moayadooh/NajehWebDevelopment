create View vw_CategoryQtYear
as
select c.categoryname as category,
od.qty as quantity,
Year(o.orderdate) as yearorder
from Production.Categories as c
inner join Production.Products as p on c.categoryid = p.categoryid
inner join Sales.OrderDetails as od on p.productid = od.productid
inner join sales.Orders as o on od.orderid = o.orderid
go
select * from vw_CategoryQtYear

-- [] Square bracket convert to column name in result select
select Category, [2006], [2007], [2008]
from (select category, quantity,yearorder from dbo.vw_CategoryQtYear) as d
pivot (sum(quantity) for yearorder in ([2006],[2007],[2008])) as pvt
--order by category
------------------------------------------------------------------------------------
create table sales.pivotedcategorysales
(
[Category] nvarchar(20) not null,
[2006] int null,
[2007] int null,
[2008] int null,
)
Go
------------------------------------------------------------------------------------
insert into sales.pivotedcategorysales
(Category,[2006],[2007],[2008])
select Category, [2006], [2007], [2008]
from (select category, quantity,yearorder from dbo.vw_CategoryQtYear) as d
pivot (sum(quantity) for yearorder in ([2006],[2007],[2008])) as pvt
--order by category
------------------------------------------------------------------------------------
select * from dbo.vw_CategoryQtYear
select * from Sales.pivotedcategorysales

select category, quantity, yearorder
from Sales.pivotedcategorysales
unpivot(quantity for yearorder in( [2006],[2007],[2008])) as unpvt
