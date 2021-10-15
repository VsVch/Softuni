SELECT *
FROM Accounts
WHERE Id = 47

SELECT *
FROM AccountsTrips
WHERE AccountId = 47

SELECT *
FROM Trips
WHERE Id = 47

DELETE
FROM Trips
WHERE Id = 47

DELETE
FROM AccountsTrips
WHERE AccountId = 47

DELETE
FROM Accounts
WHERE Id = 47