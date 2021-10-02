SELECT COUNT(c.[Count]) AS [Count] FROM (SELECT 
	COUNT(m.MountainRange) AS [Count]
FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
GROUP BY c.CountryName) AS c
WHERE [Count] = 0