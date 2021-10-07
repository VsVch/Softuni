CREATE PROC sp_TwoSelects
AS
	SELECT COUNT(*) AS EmployeesCount FROM Employees
	SELECT COUNT(*) AS AddressesCount FROM Addresses

GO

EXEC sp_TwoSelects