create table dbo.simpleOrders(
orderid int identity(1,1) not null primary key,
custid int not null foreign key references sales.Customers(custid),
empid int not null foreign key references hr.employees(empid),
orderdate datetime not null
);
------------------------------------------------------------------------------
create table dbo.simpleOrderDetails(
orderid int not null foreign key references dbo.simpleOrders(orderid),
productid int not null foreign key references production.products(productid),
unitprice money not null,
qty smallint not null,

constraint PK_OrderDetails primary key(orderid,productid)
);
GO
------------------------------------------------------------------------------
-- select * from hr.Employees where empid = 9
-- select * from sales.Customers where custid = 68
begin try
	insert into dbo.simpleOrders(custid,empid,orderdate) 
	values(68,9,'2006-07-12')

	insert into dbo.simpleOrders(custid,empid,orderdate) 
	values(88,3,'2006-07-15')

	insert into dbo.simpleOrderDetails(orderid,productid,unitprice,qty) 
	values(1,9,15.0,20)

	-- select * from Production.Products where productid = 77
	insert into dbo.simpleOrderDetails(orderid,productid,unitprice,qty) 
	values(999,77,12.3,15)
end try

begin catch
	select ERROR_NUMBER() as Errnum, ERROR_MESSAGE() as ErrMsg
end catch
------------------------------------------------------------------------------
begin try
	begin transaction
		insert into dbo.simpleOrders(custid,empid,orderdate) 
		values(40,8,'2011-03-24')
		--save tran firstpoint
		
		insert into dbo.simpleOrderDetails(orderid,productid,unitprice,qty) 
		values(999,2,15.0,20) --(1,2,15.0,20)
		--save tran secondpoint
		--rollback tran secondpoint
	commit transaction
end try

begin catch
	select ERROR_NUMBER() as Errnum, ERROR_MESSAGE() as ErrMsg
	rollback transaction
end catch

select * from simpleOrders
select * from simpleOrderDetails
