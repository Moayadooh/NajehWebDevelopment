-- Show Total number of Customers per employee per year
select empid, COUNT(distinct custid) as [Number of Customers], 
COUNT(custid) as [Number of Orders], year(orderdate) [Year]
from Sales.Orders 
group by empid, year(orderdate)