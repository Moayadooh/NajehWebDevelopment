
Create view Production.CategorizedProducts
as
SELECT Production.Categories.categoryid AS CatID, Production.Categories.categoryname AS CatName, Production.Products.productname AS ProdName, Production.Products.unitprice
FROM     Production.Categories INNER JOIN
                  Production.Products ON Production.Categories.categoryid = Production.Products.categoryid