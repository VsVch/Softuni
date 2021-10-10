CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @yearInterestRate FLOAT) 
AS
BEGIN
	SELECT  a.Id AS 'Account Id',
			a.FirstName AS 'First Name',
			a.LastName AS 'Last Name',
			acc.Balance AS 'Current Balance',
			dbo.ufn_CalculateFutureValue(acc.Balance, @yearInterestRate, 5) AS 'Balance in 5 years'
	FROM AccountHolders AS a
	JOIN Accounts AS acc ON a.Id = acc.AccountHolderId
	WHERE acc.Id = @accountId
END

EXEC usp_CalculateFutureValueForAccount 1, 0.1

