/*SELECT MIN(s.AvgSalary)

FROM
	(SELECT AVG(Salary) AS AvgSalary
	FROM Employees GROUP BY DepartmentID ) AS s*/
SELECT TOP(1) AVG(Salary) AS AveSalary
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY e.DepartmentID
ORDER BY AveSalary


	
