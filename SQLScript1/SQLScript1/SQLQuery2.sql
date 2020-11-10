Use marketDB
Go
select * from Users
select id,name,password  from users
select * from Users where id=1;
select * from Users where id=1 and Active=1;
select * from Users where name='ammar'and password='1234';
select * from Users where Active=1 or address='amman' and id > 7;
select * from users where Birth >= '2005-01-01' and Birth <= '2007-12-30'
select * from users where Salary between 3000 and 3500
-------------------------------------------------------------------------------
select * from Users where name like 'a%'
select * from Users where name like '%d'
select * from Users where name like '%m%'
select * from Users where name like '__m%'
select * from Users where name not like 'a%'
select * from Users where name not like '%m%'
select * from Users where name not like '__m%'
-------------------------------------------------------------------
insert into Users (Name,password,Birth,Salary,address,active)
values('raafat','123','2004-04-12',null,'amman',1),
('salem','233','2001-04-12',null,'irbid',0)
-------------------------------------------------------------------
select * from Users where Salary is null
select * from Users where Salary is not null
-------------------------------------------------------------------
select top 6 Salary,Name,PAssword from Users 
select  Salary,Name,PAssword from Users
GO
------------------------------------------------------------------
select * from Users where address in ('irbid','zarqa')
select * from Users where address not in ('irbid','zarqa')
Go
------------------------------------------------------------------
select max(salary) as MaxSalary from Users 
select min(salary) as MinSalary from Users 
select avg(salary) as AvgSalary from Users 
select Sum(salary) as MaxSalary from Users 
select COUNT(*) as MaxSalary from Users 
GO
------------------------------------------------------------------
select count(id) as numberOfpeople,address from users group by address 
order by address DEsc
GO
------------------------------------------------------------------
select Sum(Salary) as Total,Address from users group by address 
order by address
Go
------------------------------------------------------------------
select Sum(Salary) as Total,Address from users group by address having count(ID) > = 3
order by address
------------------------------------------------------------------
select * from users
Go
-----------------------------------------------------------------------------
select Count(Id) as Nums,Address from users group by address having avg(Salary) > = 3000
order by address
-----------------------------------------------------------------------------
--retrieve Drop Down List
select distinct address from users
-----------------------------------------------------------------------------
