SELECT ContinentCode, CurrencyCode, Total FROM (
SELECT ContinentCode, CurrencyCode,	COUNT(CountryCode) AS Total,
		DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY COUNT(CountryCode) DESC) AS Ranked
  FROM Countries 
GROUP BY CurrencyCode, ContinentCode) AS k
	WHERE Ranked = 1 AND Total > 1
ORDER BY ContinentCode
 