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
values(25,'ali saad kamel','ali.jpg','845747474')
select * from Account
-- 1 to many
Create table Department
(
   DepartmentID int primary key not null identity(1,1),
   DepartmentName nvarchar(50)
);

Go
alter table Users
add DptID int

Go
----------------
alter table users
add constraint fk_Department_Users foreign key (DptID) references Department(DepartmentID)
Go


------------------------------------
insert into Department values('IT'),('ENG'),('MED'),('Sci')
select * from Department
-------------------------------------
use marketDB
Go
select * from Users
UPdate Users set Users.DptID=2 where id=23 
UPdate Users set Users.DptID=3 where id=24 
UPdate Users set Users.DptID=3 where id=25 
UPdate Users set Users.DptID=3 where id=26 
UPdate Users set Users.DptID=4 where id=27 
UPdate Users set Users.DptID=4 where id=28 
UPdate Users set Users.DptID=1 where id=29 
UPdate Users set Users.DptID=1 where id=30 
UPdate Users set Users.DptID=1 where id=32 
UPdate Users set Users.DptID=3 where id=33 
UPdate Users set Users.DptID=4 where id=34 
UPdate Users set Users.DptID=4 where id=35 
Go



-- many to many