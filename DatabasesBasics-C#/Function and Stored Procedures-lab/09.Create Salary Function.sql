CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@Salary MONEY)
RETURNS VARCHAR(MAX)
AS
BEGIN
	IF @Salary IS NULL
		RETURN NULL
	IF(@Salary < 30000)
		RETURN 'Low'
	ELSE IF (@Salary <= 50000)
		RETURN 'Average'
	ELSE
		RETURN 'High'
	RETURN NUll
END

SELECT FirstName, LastName, Salary, dbo.ufn_GetSalaryLevel(Salary)
FROM Employees