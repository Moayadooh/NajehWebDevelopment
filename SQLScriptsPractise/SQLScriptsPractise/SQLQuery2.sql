-- Show Total number of Customers per employee per year
select empid, COUNT(distinct custid) as [Number of Customers], 
COUNT(custid) as [Number of Orders], year(orderdate) [Year]
from Sales.Orders 
group by empid, year(orderdate)

-- Show number of orders per employee from orders table
select empid, count(*) as [Number of Orders] from Sales.Orders 
group by empid

-- Show Total number of Customers for employee has id 3 per year
select empid, COUNT(distinct custid) as [Number of Customers], 
YEAR(orderdate) as [Order Date] from Sales.Orders 
where empid = 3 group by empid, YEAR(orderdate)

-- Show the max quantity of order details per product.
select productid, MAX(qty) from Sales.OrderDetails as [Max Quantity] 
group by productid

-- Show total of orders for cutomers if the orders greater than 10
select custid, COUNT(orderid) as NumOfOrders from Sales.Orders 
group by custid having COUNT(orderid) > 10

-- Show total of order details average of quantity per product category 
