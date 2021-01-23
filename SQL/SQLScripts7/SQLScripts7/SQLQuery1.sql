CREATE PROC [Production].[ProdsByCategory]
(@numrows as int, @catid as int)
AS
select top(@numrows) productid, productname, unitprice
from Production.Products
where categoryid = @catid;
GO
---------------------------------------------------------------------
create table dbo.t1 (c1 int primary key,c2 int,c3 nchar(5))
GO
insert into dbo.t1 values(1,2,'Nabc')
insert into dbo.t1 values(2,3,'Ndef')
GO
insert into dbo.t1 value(3,2,'Nabc') -- error will stop full batch execution
insert into dbo.t1 values(4,3,'Ndef')
GO

select * from t1
---------------------------------------------------------------------
select @@SERVERNAME
---------------------------------------------------------------------
select * from TSQL.HR.Employees -- on other server
GO
use Cardb
create synonym dbo.employeetbl for TSQL.HR.Employees
GO
select * from dbo.employeetbl
GO
---------------------------------------------------------------------
declare @numrows int = 3, @catid int = 2
exec Production.ProdsByCategory @numrows = @numrows, @catid = @catid
GO
use marketDB
create synonym dbo.prodsbyCat for TSQL.[Production].[ProdsByCategory]
GO
declare @numrows int = 3, @catid int = 2
exec dbo.prodsbyCat @numrows = @numrows, @catid = @catid
GO
---------------------------------------------------------------------
select * from sys.synonyms
