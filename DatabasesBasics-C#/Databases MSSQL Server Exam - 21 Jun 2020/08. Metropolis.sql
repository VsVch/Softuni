SELECT TOP(10)
	c.Id,
	c.Name,
	c.CountryCode,
	COUNT(a.Id) AS Accounts
FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
GROUP BY c.Name, c.CountryCode, c.Id
ORDER BY COUNT(a.Id) DESC


SELECT 
	COUNT(a.Id)
FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
WHERE CityId = 39
GROUP BY c.Name
