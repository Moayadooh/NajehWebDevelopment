if object_id('[Production].[ProdsByCategory]') is null
print 'object does not exist'
else
Drop Proc [Production].[ProdsByCategory]
go
-------------------------------------------------------------
if object_id('HR.Employees') is null
begin
print 'The table does not exist'
end
else
begin
print 'The table exists'
end 
-------------------------------------------------------------
if EXists (select * from Sales.Customers where custid=5)
begin 
print 'Customer has an id'
end
-------------------------------------------------------------
Declare @empid as int , @lname as nvarchar(20)
set @empid=1
while @empid <= 5
begin
select @lname = lastname from hr.Employees where empid=@empid
print @lname
set @empid +=1
end
