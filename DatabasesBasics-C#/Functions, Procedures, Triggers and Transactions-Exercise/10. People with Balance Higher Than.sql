CREATE PROC usp_GetHoldersWithBalanceHigherThan(@number MONEY)
AS
BEGIN
	SELECT s.FirstName, s.LastName 
FROM(
	SELECT FirstName, LastName , SUM(Balance) AS b
		FROM AccountHolders AS ah
		JOIN Accounts AS acc ON ah.Id = acc.AccountHolderId		
		GROUP BY FirstName, LastName
		HAVING SUM(Balance) > @number) AS s
ORDER BY s.FirstName, s.LastName
END

EXEC usp_GetHoldersWithBalanceHigherThan 50000
