-- Show total of order details average of quantity per product category 

select count(*) as countall , avg(qty) as avgqty
from Production.Products as p
join
Sales.OrderDetails as od
on p.productid = od.productid
where od.qty > 30
group by p.productid
----------------------------------------------------------
select productname, count(*) as countallorders , avg(qty) as avgqty
from Production.Products as p
join
Sales.OrderDetails as od
on p.productid = od.productid
group by p.productid, productname
having avg(qty) > 30
