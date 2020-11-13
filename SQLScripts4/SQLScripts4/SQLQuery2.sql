-- Show Total number of Customers per employee per year
select empid, Year(orderdate) as orderyear,
count(custid) as allcust,
count(distinct custid) as unique_custs
from sales.Orders
group by empid, year(orderdate)
------------------------------------------------------------------------
-- to verify employee empid=5
select * from sales.Orders where empid=5 and year(orderdate) = 2006
-- check custid : 87
-------------------------------------------------------------------------



