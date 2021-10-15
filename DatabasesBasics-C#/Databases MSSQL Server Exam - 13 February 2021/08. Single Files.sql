SELECT f2.Id, f2.[Name], CONCAT(f2.[Size], 'KB') AS [Size]
FROM Files AS f1
RIGHT JOIN Files AS f2 ON
	f1.ParentId = f2.Id
WHERE f1.ParentId IS NULL
ORDER BY Id, [Name], [Size] DESC
