SELECT w.FullName,w.Country AS Country, w.ZIP,w.CigarPrice
FROM (SELECT 
			CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
			a.Country,
			a.ZIP,
			CONCAT('$',ci.PriceForSingleCigar) AS CigarPrice,
			DENSE_RANK() OVER ( PARTITION BY CONCAT(c.FirstName, ' ', c.LastName) ORDER BY ci.PriceForSingleCigar DESC) AS Densrank
FROM Clients AS c
LEFT JOIN Addresses AS a ON c.AddressId = a.Id
LEFT JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
LEFT JOIN Cigars AS ci ON cc.CigarId = ci.Id
WHERE a.ZIP NOT LIKE '%[^0-9]%' 
GROUP BY CONCAT(c.FirstName, ' ', c.LastName), a.Country, a.ZIP, ci.PriceForSingleCigar) AS w
WHERE w.Densrank = 1

