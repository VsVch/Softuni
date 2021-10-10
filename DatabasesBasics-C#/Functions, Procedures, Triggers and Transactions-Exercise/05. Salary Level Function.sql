CREATE FUNCTION dbo.ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS VARCHAR(MAX)
AS
BEGIN
DECLARE @SalaryLevel VARCHAR(10) 
	IF(@Salary < 30000)
		SET @SalaryLevel = 'Low'
	ELSE IF(@Salary <= 50000)
		SET @SalaryLevel = 'Average'
	ELSE	
		SET @SalaryLevel = 'High'
	RETURN @SalaryLevel
END

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) 
FROM Employees
