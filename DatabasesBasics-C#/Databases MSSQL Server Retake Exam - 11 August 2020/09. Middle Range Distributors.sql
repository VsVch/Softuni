SELECT *
FROM(SELECT 
	d.Name AS  DistributorName,
	i.Name AS IngredientName,
	p.Name AS ProductName,
	AVG(CAST(f.Rate AS DECIMAL(8,6))) AS Average
FROM Ingredients AS i
JOIN Distributors AS d ON d.Id = i.DistributorId
JOIN ProductsIngredients  AS pri ON i.Id = pri.IngredientId
JOIN Products AS p ON p.Id = pri.ProductId
JOIN Feedbacks AS f ON f.ProductId = p.Id
GROUP BY d.Name, i.Name, p.Name) AS w
WHERE Average BETWEEN 5 AND 8

