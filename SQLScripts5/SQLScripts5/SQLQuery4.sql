Use TSQL
GO

select orderyear, count(distinct custid) as cust_count
from
	(select year(orderdate) as orderyear , custid
	from Sales.Orders) as derived_year
group by orderyear
GO
-------------------------------------------------------------------
declare @empid int  = 9
select orderyear , count(distinct custid) as cust_count 
from
	(select year(orderdate) as orderyear , custid
	from Sales.Orders
	where empid = @empid
	) as derived_year
group by orderyear
------------------------------------------------------------------------


select orderyear, cust_count 
from
	(select orderyear, count(distinct custid) as cust_count
	from(
		select year(orderdate) as orderyear , custid
		from Sales.Orders) as derived_year1
	group by orderyear) as derived_year2
where cust_count > 80
GO
-------------------------------------------------------
select orderyear, count(distinct custid) as cust_count
	from(
				select year(orderdate) as orderyear , custid
				from Sales.Orders) as derived_year1
	group by orderyear
	having COUNT(distinct custid) > 80
-----------------------------------------------------------

with cte_year as 
(
	select year(orderdate) as orderyear , custid
	from Sales.Orders
)
select orderyear,COUNT(distinct custid) as cust_count
from cte_year
















