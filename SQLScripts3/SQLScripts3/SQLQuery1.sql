Use Tsql
Go

select distinct e.city,e.country
from sales.Customers as c
join hr.Employees as e
on e.city = c.city and e.country = c.country
-------------------------------------------------------------------
select hiredate,firstname,lastname 
from hr.Employees
order by hiredate desc, lastname desc 
-------------------------------------------------------------------










