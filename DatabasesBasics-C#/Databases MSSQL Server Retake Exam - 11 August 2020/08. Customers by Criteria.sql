SELECT FirstName,AGE, PhoneNumber
FROM Customers
WHERE Age >= 21 AND (FirstName LIKE '%an%' OR PhoneNumber LIKE '%38') AND CountryId != 31
ORDER BY FirstName, AGE DESC


SELECT *
FROM Countries
WHERE Name ='Greece'