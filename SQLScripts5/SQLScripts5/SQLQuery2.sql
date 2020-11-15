select e.empid , e.lastname
from hr.Employees as e
where exists (
select * from sales.Orders as o
where o.empid = e.empid
)

select empid, lastname 
from hr.Employees as e
where (select count(*) from sales.Orders as o
where o.empid = e.empid) > 0 



select e.empid , e.lastname
from hr.Employees as e
where not exists (
select * from sales.Orders as o
where o.empid = e.empid
)
---------------------------------------------------







