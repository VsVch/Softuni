SELECT 
	MIN (s.AvgSalary) 
FROM
	(SELECT AVG(Salary) AS AvgSalary FROM Employees GROUP BY DepartmentID) AS s