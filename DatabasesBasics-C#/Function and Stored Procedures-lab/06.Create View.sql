CREATE OR ALTER VIEW EmployeesByYear AS
SELECT * FROM Employees
WHERE YEAR(HireDate) = 2000