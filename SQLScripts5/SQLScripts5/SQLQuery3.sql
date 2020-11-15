create view hr.empphoneList
as
select empid, lastname, firstname, phone
from hr.Employees
go
select empid,lastname from hr.empphoneList
go
-- Show How many order details per employee for each year
create view sales.OrdersByEmployeeYear
as
select emp.empid as employee,
      year(o.orderdate) as orderyear,
	  count(*) as totalsales
	  from hr.Employees as emp
	  join Sales.Orders as o on o.empid = emp.empid
	  join Sales.OrderDetails as od on od.orderid = o.orderid -- count(*) work based on last join statement
	  group by emp.empid, YEAR(o.orderdate) 
	  go

select * from sales.OrdersByEmployeeYear
go
create view sales.orderByemployeeYear2
as
SELECT emp.empid AS employee, YEAR(o.orderdate) AS orderyear, COUNT(*) AS totalsales
FROM     HR.Employees AS emp INNER JOIN
                  Sales.Orders AS o ON o.empid = emp.empid INNER JOIN
                  Sales.OrderDetails AS od ON od.orderid = o.orderid
where emp.address like 'a%'
GROUP BY emp.empid, YEAR(o.orderdate)
having (COUNT(*) > 10) OR
                  (COUNT(*) < 20)
go
Drop view Sales.orderByemployeeYear2
