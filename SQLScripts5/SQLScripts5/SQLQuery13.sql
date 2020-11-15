
select CatID, CatName , ProdName, UnitPrice,
RANK() over(order by unitprice desc) as PriceRank
from Production.CategorizedProducts
order by PriceRank