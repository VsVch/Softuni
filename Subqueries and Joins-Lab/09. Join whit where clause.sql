SELECT 
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.[Name] As Department
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID =d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID