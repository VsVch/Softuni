CREATE VIEW v_UserWithCountries AS
SELECT 
	CONCAT(cs.FirstName, ' ', cs.LastName) AS CustomerName,
	cs.AGE AS Age,
	cs.Gender, 
	c.Name AS CountryName
FROM Customers AS cs
JOIN Countries AS c ON cs.CountryId = c.Id
