SELECT Username, SUBSTRING(Email, PATINDEX('%@%', Email) +1,LEN(Email)) AS Email
FROM Users
ORDER BY Email, Username 