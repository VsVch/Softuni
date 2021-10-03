SELECT r.DepartmentID, r.Salary
FROM(SELECT DepartmentID, Salary, DENSE_RANK() OVER  
							(PARTITION BY DepartmentID ORDER BY Salary DESC) AS Ranked
FROM Employees
GROUP BY DepartmentID, Salary) AS r
WHERE Ranked = 3

