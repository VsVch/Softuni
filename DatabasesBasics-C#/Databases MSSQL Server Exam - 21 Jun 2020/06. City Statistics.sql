SELECT
	c.Name AS City,
	COUNT(h.Name) AS Hotels
FROM Cities AS c
JOIN Hotels AS h ON h.CityId = c.Id
GROUP BY c.Name
ORDER BY COUNT(h.Name) DESC, c.Name
