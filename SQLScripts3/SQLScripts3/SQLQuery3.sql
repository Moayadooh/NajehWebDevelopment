select orderid,custid,empid,orderdate
from sales.orders
order by orderdate, orderid
OFFSET 0 rows FETCH FIRST 50 rows only

-- start from 51
select orderid,custid,empid,orderdate
from sales.orders
order by orderdate, orderid
OFFSET 50 rows FETCH FIRST 50 rows only


