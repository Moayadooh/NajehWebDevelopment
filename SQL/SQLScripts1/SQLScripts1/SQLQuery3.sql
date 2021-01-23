use marketDB
-- 1 to 1
Create table Account
( 
   AccountID int primary key not null,
   FullName nvarchar(50),
   image nvarchar(50),
   phone nvarchar(30),

   CONSTRAINT FK_Account_User Foreign Key (AccountID) references Users(Id)  
)

select * from users
insert into Account (AccountID,FullName,image,phone)
values(3,'ali saad kamel','ali.jpg','845747474')
select * from Account
--select * from Users inner join Account on Users.Id = Account.AccountID where Users.Id = 3

-- 1 to many
Create table Department
(
   DepartmentID int primary key not null identity(1,1),
   DepartmentName nvarchar(50)
);

Go
alter table Users add DptID int

Go
------------------------------------
alter table users add 
constraint fk_Department_Users foreign key (DptID) references Department(DepartmentID)
Go
------------------------------------
insert into Department values('IT'),('ENG'),('MED'),('Sci')
select * from Department
-------------------------------------
Go
select * from Users
UPdate Users set Users.DptID=2 where id=2 
UPdate Users set Users.DptID=3 where id=3 
UPdate Users set Users.DptID=3 where id=4 
UPdate Users set Users.DptID=3 where id=5 
UPdate Users set Users.DptID=4 where id=6 
UPdate Users set Users.DptID=4 where id=7 
UPdate Users set Users.DptID=1 where id=8 
UPdate Users set Users.DptID=1 where id=9 
UPdate Users set Users.DptID=1 where id=10 
UPdate Users set Users.DptID=3 where id=11
Go
--select * from Users join Department on Users.DptID = Department.DepartmentID
