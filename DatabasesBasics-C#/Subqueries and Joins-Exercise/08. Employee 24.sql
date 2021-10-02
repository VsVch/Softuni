SELECT 
	e.EmployeeID,
	e.FirstName,
	CASE
	WHEN DATEPART(YEAR,p.StartDate) >= 2005 THEN NULL
	ELSE p.[NAME] 
	END AS ProjectName
FROM Employees AS e
	LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24