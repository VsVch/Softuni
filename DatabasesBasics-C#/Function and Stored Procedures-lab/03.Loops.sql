--Loops
DECLARE @Year SMALLINT = 2000 -- OR (SELECT COUNT(*) FROM Employees);

WHILE @Year <= 2008
BEGIN
	SELECT @Year, COUNT(*) FROM Employees WHERE YEAR (HireDate) = @Year
	SET @Year = @Year + 1
END
