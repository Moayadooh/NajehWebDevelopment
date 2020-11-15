-- Show numbers of orders for customers
select c.custid, c.companyname, COUNT(o.custid) as NumOrders 
from Sales.Customers c join Sales.Orders o 
on c.custid = o.custid 
group by c.custid, c.companyname, o.custid

-- Show number of order details per product id
select p.productid, p.productname, COUNT(od.productid) as NumOrders 
from Production.Products p join Sales.OrderDetails od 
on p.productid = od.productid 
group by p.productid, p.productname, od.productid
