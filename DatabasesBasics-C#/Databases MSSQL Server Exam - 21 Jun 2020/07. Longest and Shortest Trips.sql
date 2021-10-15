SELECT 
	AccountId,
	CONCAT(FirstName,' ',LastName) AS FullName,
	DATEDIFF(DAY, ArrivalDate, ReturnDate) 
FROM Accounts AS a
JOIN AccountsTrips AS at ON a.Id = at.AccountId
JOIN Trips AS t ON t.Id = at.AccountId
WHERE CancelDate IS NULL
ORDER BY DATEDIFF(DAY, ArrivalDate, ReturnDate) DESC