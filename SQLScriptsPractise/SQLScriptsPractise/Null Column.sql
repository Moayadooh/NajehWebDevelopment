create table dbo.t1(
c1 int identity not null primary key,
c2 int null
)

insert into dbo.t1(c2) values(null),(10),(20),(30),(40),(50)

select c1,c2 from dbo.t1
select sum(c2) as sumofc2, 
count(*) as countall , 
count(c2) as countnonnull,
avg(c2) as avrg,
sum(c2)/count(*) as realavrg2 --or avg(ISNULL(c2,0))
from dbo.t1


create table dbo.t2(
c1 int identity not null primary key,
c2 int null
)

insert into dbo.t2(c2) values(null),(10),(null),(30),(40),(50),(null),(60)

select c1,c2 from dbo.t2
select 
avg(t2.c2) as avrg,
AVG(isnull(t2.c2,0)) as realavrg2
from dbo.t2
