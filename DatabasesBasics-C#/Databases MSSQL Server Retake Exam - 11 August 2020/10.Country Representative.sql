SELECT w.CountryName, w.DisributorName
FROM (SELECT c.Name AS CountryName ,
		d.Name AS DisributorName,		
		DENSE_RANK() OVER ( PARTITION BY c.Name ORDER BY COUNT(i.Id) DESC) AS Densrank
FROM Countries AS c
JOIN Distributors AS d ON c.Id = d.CountryId
LEFT JOIN Ingredients AS i ON  d.Id = i.DistributorId
GROUP BY c.Name, d.Name) AS w
WHERE w.Densrank = 1
ORDER BY w.CountryName, w.DisributorName





