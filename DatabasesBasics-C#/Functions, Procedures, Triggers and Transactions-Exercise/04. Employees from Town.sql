CREATE PROC usp_GetEmployeesFromTown(@TownName NVARCHAR(90))
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
	WHERE [Name] = @TownName
END

EXEC dbo.usp_GetEmployeesFromTown 'Sofia'