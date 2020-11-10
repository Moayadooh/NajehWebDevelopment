Create database Cardb

use Cardb
go
Create table Cars
(
ID int primary key not null,
Brand nvarchar(50),
ModelYear date,
color nvarchar(50)
);
Go
create table Types
(
ID int primary key not null,
Name nvarchar(50)
);
----------------------------------------------
--Create juncion table
Create table JunctionCarType
(
JunctionID int primary key not null identity(1,1),
CarID int not null,
TypeID int not null,
 constraint fk_Car_Junction foreign key (CarID) references Cars(ID),
 constraint fk_Type_Junction foreign key (TypeID) references Types(ID)
)
----------------------------------------------
insert into cars values(100,'BMW', '2019-05-01','black'),
(101,'Avalon','2018-01-02','red'),
(102,'Mazda','2020-05-01','black'),
(103,'Opel','2013-05-01','white'),
(104,'Toyota','2011-05-01','green'),
(105,'Gems','2019-05-01','black'),
(106,'Dodge','2019-05-01','white')
Go
insert into Types values(97,'Saloon'),
(98,'Station'),
(99,'Hachback')
Go
----------------------------------------------
insert into JunctionCarType (CarID,TypeID)
values(100,97),
(100,98),
(100,99),
(101,97),
(101,99),
(102,99),
(102,97),
(103,98),
(103,99),
(104,97),
(105,97),
(106,97),
(106,98),
(106,99)
GO
----------------------------------------------
select * from Cars
select * from Types

select Cars.Brand,Cars.ModelYear, Cars.color, Types.Name from Cars 
join JunctionCarType on Cars.ID = JunctionCarType.CarID 
join Types on JunctionCarType.TypeID =  Types.ID

select * from Vw_CarType
