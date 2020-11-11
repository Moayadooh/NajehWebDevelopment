Merge into Production.Products as p
using Production.ProductsStaging as s
on p.Productid = s.Productid
when Matched then
update set p.discontinued = s.discontinued
when not matched then
insert ([productname],[supplierid],[categoryid],[unitprice],[discontinued])
values (s.productname,s.supplierid,s.categoryid,s.unitprice,s.discontinued);
