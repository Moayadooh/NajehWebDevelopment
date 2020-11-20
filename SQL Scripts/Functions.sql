
CREATE DATABASE dbName
SELECT DB_NAME()
USE dbName
GO

NEWID() -- Generate UNIQUEIDENTIFIER
UniqueColumn UNIQUEIDENTIFIER DEFAULT NEWID(),

-- Variable Declaration
DECLARE @mysearch NVARCHAR(60)
SET @mysearch =  (SELECT ('microsoft sql server'))
SELECT @mysearch

DECLARE
  @v1 AS INT = NULL,
  @v2 AS INT = 50,
  @v3 AS INT = 100

-- Fitch "start from 51"
SELECT orderid,custid,empid,orderdate
FROM sales.orders
ORDER BY orderdate, orderid
OFFSET 50 ROWS FETCH FIRST 50 ROWS ONLY

-- Merge
MERGE INTO Production.Products AS p
USING Production.ProductsStaging AS s
ON p.Productid = s.Productid
WHEN Matched THEN
UPDATE SET p.discontinued = s.discontinued
WHEN NOT matched THEN
INSERT ([productname],[supplierid],[categoryid],[unitprice],[discontinued])
VALUES (s.productname,s.supplierid,s.categoryid,s.unitprice,s.discontinued);

-- RANK
SELECT top(5) productid,productname,unitprice,
RANK() OVER(ORDER BY unitprice Desc) AS rankbyprice
FROM Production.Products

-- SWITCH CASE
SELECT productid,productname,unitprice,
CASE discontinued
 WHEN 0 THEN 'ACTIVE'
 WHEN 1 THEN 'NONACTIVE'
 END AS Status
FROM Production.Products

-- Pivot
SELECT UserID, [2017], [2018], [2019], [2020]
FROM (SELECT UserID, Events_Name, Year FROM dbo.Events) AS e
PIVOT (COUNT(Events_Name) FOR Year IN ([2017],[2018],[2019],[2020])) AS pvt


ISNUMERIC('1E3')
IIF(num > 50,'high','low') -- return high if more than 50, otherwise return low
CHOOSE(3,'Beverages','condiments','confections') -- return 'confections'

DECLARE
  @v1 AS INT = NULL,
  @v2 AS INT = 50,
  @v3 AS INT = 100

  SELECT ISNULL(@v1 , @v3)
  SELECT COALESCE(@v1 , @v2 , @v3)
  
NULLIF(col1,col2) -- if both are equal return null else return col2 value

WHERE id <> 3 -- exclude number 3

WHERE EXISTS (
)

WITH CTE AS (
)
