insert into Sales.Customers
(
[companyname],
[contactname],
[contacttitle],
[address],
[city],
[region],
[postalcode],
[country],
[phone],
[fax]
)
select * from [dbo].[PotentialCustomers]

