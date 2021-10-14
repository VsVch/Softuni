SELECT 
	ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee ,
	ISNULL(d.Name, 'None') AS Department,
	ISNULL(c.Name, 'None') AS Category,
	r.Description AS Description,
	FORMAT(r.OpenDate,'dd.MM.yyyy') AS OpenDate,
	s.Label,
	CASE 
	WHEN u.Name IS NULL THEN 'None'
	ELSE u.Name
	END AS [User]	
FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Categories AS c ON c.Id= r.CategoryId
LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
LEFT JOIN Status AS s ON r.StatusId = s.Id
LEFT JOIN Users AS u ON u.Id = r.UserId
ORDER BY e.FirstName DESC, e.LastName DESC,d.Name ASC,
c.Name, r.Description, r.OpenDate, s.Label, u.Name



