CREATE OR ALTER PROC usp_SearchByTaste(@taste NVARCHAR(20))
AS
SELECT 
	  c.CigarName,
	  CONCAT('$',c.PriceForSingleCigar),
	  t.TasteType,
	  b.BrandName,
	  CONCAT(s.Length, ' ', 'cm') AS CigarLength,
	  CONCAT(s.RingRange, ' ', 'cm') AS CigarRingRange
FROM Cigars AS c
LEFT JOIN Sizes AS s ON c.SizeId = s.Id
LEFT JOIN Brands AS b ON c.BrandId = b.Id
LEFT JOIN Tastes AS t ON t.Id = c.TastId
WHERE t.TasteType = @taste
ORDER BY CigarLength, CigarRingRange DESC

EXEC usp_SearchByTaste 'Woody'