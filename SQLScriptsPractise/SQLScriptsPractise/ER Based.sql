create database CompanyDB
use CompanyDB

create table Employees
(
Id int primary key identity, -- or identity(1,1)
Name nvarchar(30) not null,
Status bit
);
alter table Employees add Salary money;

insert into Employees values('Moayad',1,900.50),('Eyad',0,1200),('Mohanned',null,5000);
select top 2 * from Employees;
delete from Employees;
truncate table Employees;

-- one to one
create table Profile
(
Id int primary key,
MobileNo nvarchar(15) not null,
OtherMobileNo nvarchar(15) null,
);
alter table Profile add constraint FK_Profile_Employees foreign key (Id) references Employees(Id);

insert into Profile values(1,'96430801',null);
select e.*, p.* from Employees e left join Profile p on e.Id = p.Id;

-- one to many
create table Departments
(
Id int primary key identity,
Name nvarchar(30) not null
);
alter table Employees add DepId int;
alter table Employees add constraint FK_Employees_Departments foreign key (DepId) references Departments(Id);
sp_rename 'Departments.Name', 'DepartmentName', 'COLUMN';

insert into Departments values('IT'),('ENG'),('SCI');
update Employees set DepId = 1 where DepId is null;

select e.Name, e.Status, e.Salary, d.DepartmentName from Employees e join Departments d
on e.DepId = d.Id;

-- many to many
