use TSQL
Go

select country, city,region from hr.Employees
union all -- shwoing all rows data above each other
select country, city,region from sales.Customers
-------------------------------------------------------
select country, city,region from hr.Employees
union  -- showing distinct rows
select country, city,region from sales.Customers
-------------------------------------------------------
select country, city,region from hr.Employees
intersect -- showing shared rows values
select country, city,region from sales.Customers
-------------------------------------------------------
select country, city,region from hr.Employees
except -- showing excepted rows values
select country, city,region from sales.Customers
-------------------------------------------------------
select country, city,region from Sales.Customers
except -- showing excepted rows values
select country, city,region from hr.Employees
