CREATE PROC usp_EmployeesBySalaryLevel(@SalaryLevel NVARCHAR(50))
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
END

EXEC dbo.usp_EmployeesBySalaryLevel 'high' 