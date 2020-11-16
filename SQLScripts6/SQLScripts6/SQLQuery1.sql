Create view Production.CategorizedProducts
as
SELECT Production.Categories.categoryid AS CatID, 
Production.Categories.categoryname AS CatName, 
Production.Products.productname AS ProdName, 
Production.Products.unitprice
FROM Production.Categories 
INNER JOIN Production.Products ON 
Production.Categories.categoryid = Production.Products.categoryid
go

select * from Production.CategorizedProducts

select catID, CatName, ProdName, UnitPrice, 
RANK() over(order by UnitPrice desc) as PriceRank 
from Production.CategorizedProducts 
-------------------------------------------------------------------------------------
select catID, CatName, ProdName, UnitPrice, 
RANK() over(partition by catID order by unitprice desc) as priceCatRank 
from Production.CategorizedProducts 
-------------------------------------------------------------------------------------
select catID, CatName, ProdName, UnitPrice, 
Sum(unitprice) over(partition by catID order by unitprice desc) as priceCatSum
from Production.CategorizedProducts
-------------------------------------------------------------------------------------
select catID, CatName, ProdName, UnitPrice, 
ROW_NUMBER() over(partition by catID order by unitprice desc) as rownumberperproduct
from Production.CategorizedProducts
