SELECT *
FROM Employees AS e
RIGHT JOIN Employees AS m ON e.ManagerID = m.EmployeeID