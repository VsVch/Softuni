SELECT 
	r.Description,
	c.Name As CategoryName
FROM Reports AS r
JOIN Categories As c ON r.CategoryId = c.Id
WHERE CategoryId IS NOT NULL
ORDER BY r.Description, c.Name
