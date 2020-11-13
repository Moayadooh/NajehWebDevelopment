select ISNUMERIC('sql') as isnumericresult
select ISNUMERIC('45') as isnumericresult
select ISNUMERIC('1E3') as isnumericresult
---------------------------------------------
select productid,unitprice,IIF(unitprice > 50,'high','low')as unitpricepoint
from Production.Products
--------------------------------------------
select CHOOSE(3,'Beverages','condiments','confections') as choose_result;
select distinct productname from Production.Products
----------------------------------------------------------------
select custid,city , ISNULL(region,'Unknown') as region , country
from Sales.Customers
----------------------------------------------------------------
Select custid, country  , region , city, 
country + ',' + COALESCE(region, ' ') + ' ,' + city as location
from sales.customers
----------------------------------------------------------------
declare @v varchar(5);
select ISNULL(@v,'ammaryaser') as isnullresult
select Coalesce(@v,'ammaryaser') as coalescresult
------------------------------------------------------------------
Declare
  @v1 as int = NULL,
  @v2 as int = 50,
  @v3 as int = 100

  select isnull(@v1 , @v3) AS ISNULLVALUE
  select COALESCE(@v1 , @v2 , @v3) AS COALESCEVALUE
----------------------------------------------------------
CREATE TABLE dbo.employees_goals
(
emp_id int,
goal int,
actual int
)
go
insert into dbo.employees_goals values
(1,100,110),
(2,90,90),
(3,100,80)
go
select emp_id, NullIF(actual,goal) as actual_if_different
from dbo.employees_goals;










