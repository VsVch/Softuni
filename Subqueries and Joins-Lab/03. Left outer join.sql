SELECT * 
FROM Employees AS e
LEFT JOIN Employees AS m ON e.ManagerID = m.EmployeeID 
