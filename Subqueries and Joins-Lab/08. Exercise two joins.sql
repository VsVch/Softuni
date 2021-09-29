SELECT TOP (50)
	e.FirstName,
	e.LastName,
	t.[Name] AS Town,
	a.AddressText
FROM Employees As e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns As t ON a.AddressID = t.TownID
ORDER BY e.FirstName, e.LastName