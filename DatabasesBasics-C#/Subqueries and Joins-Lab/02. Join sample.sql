SELECT * 
FROM Employees AS e
INNER JOIN Employees AS m ON e.ManagerID = m.EmployeeID