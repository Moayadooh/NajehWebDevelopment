USE HealthMinister
GO

SELECT UserID, [2017], [2018], [2019], [2020]
FROM (SELECT UserID, Events_Name, Year FROM dbo.Events) AS e
PIVOT (COUNT(Events_Name) FOR Year IN ([2017],[2018],[2019],[2020])) AS pvt
