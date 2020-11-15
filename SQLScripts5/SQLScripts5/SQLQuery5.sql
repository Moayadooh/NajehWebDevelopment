create table t1
(
    v1 int 
)

insert into t1 (v1) values(1),(2),(3)

create table t2
(
    v2 int 
)

insert into t2 (v2)values(2),(3),(4)

select * from t1
select * from t2
---------------------------------------------------------
-- retun rows with distinct rows data
select v1 from t1 
union 
select v2 from t2 
-- return rows with dublicate rows data
select v1 from t1 
union all
select v2 from t2 

select v1 from t1 
intersect
select v2 from t2 


