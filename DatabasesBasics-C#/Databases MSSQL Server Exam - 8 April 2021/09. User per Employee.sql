SELECT
	 e.FirstName + ' ' + e.LastName AS FullName,
	 COUNT(u.Username) AS UsersCount
FROM Employees AS e
LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
LEFT JOIN Users AS u ON u.Id = r.UserId
GROUP BY e.FirstName + ' ' + e.LastName
ORDER BY COUNT(u.Username) DESC, FullName

SELECT * FROM Users

SELECT * FROM Employees

