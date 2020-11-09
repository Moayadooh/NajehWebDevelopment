--DDL
create database marketDB
use marketDB
Go
create table dbo.Users
(
    Id int not null primary key Identity(1,1),
	Name nvarchar(50) not null,
	password nvarchar(50) not null,
	Birth date null,
	Salary money,
	address nvarchar(50),
	Active bit
);
Go

--DML
insert into Users (Name,password,Birth,Salary,address,active)
values('ammar','123','05-15-2005',3454.34,'amman',1)
Go

insert into Users (Name,password,Birth,Salary,address,active)
values('Qasem','123','2004-04-12',3454.34,'amman',1),
('ali','1234','2004-04-12',3454.34,'amman',1),
('zaqi','1235','2014-03-12',2454.34,'zarqa',0),
('saad','1236','2010-05-1',1454.34,'irbid',0),
('waad','1237','2014-03-10',8454.34,'jarash',1),
('khaled','1238','2006-05-22',7454.34,'aqaba',1),
('ahmad','1239','2012-10-2',9454.34,'amman',1),
('abdalmouty','1212','2007-10-12',1454.34,'irbid',0)
Go

update Users set password='ftr567',Name='Qasem Yaser',Birth='2001-06-14',Active=0 where id=2;

delete from users where id =9

truncate table users

Select * from Users order by id
