USE HealthMinister
GO

WITH CTE AS
(
	SELECT DeptID, COUNT(*) AS NumOfRows FROM dbo.DeptHOSBeds
	GROUP BY DeptID HAVING SUM(Num_Beds) > 50
)
SELECT d.Dept_Name, dpt.DeptID, dpt.NumOfRows
FROM dbo.Departments AS d
INNER JOIN CTE AS dpt ON d.ID = dpt.DeptID
