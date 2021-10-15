SELECT 
	t.Id AS ID,
	a.FirstName +' '+ ISNULL(a.MiddleName + ' ', '')+ a.LastName AS 'Full Name',
	c.name AS [From],
	ca.Name AS [To],
	CASE
		WHEN t.CancelDate IS NULL THEN CONCAT(DATEDIFF(DAY, t.ArrivalDate,t.ReturnDate),  ' ', 'days')
		ELSE 'Canceled'
	END AS Duration
	
FROM AccountsTrips AS at		
JOIN Accounts AS a ON at.AccountId = a.Id
JOIN Trips AS t ON t.Id = at.TripId
JOIN Cities AS c ON c.Id = a.CityId
JOIN Rooms AS r ON t.RoomId =r.Id
JOIN Hotels AS h On r.HotelId= h.Id
JOIN Cities AS ca ON h.CityId = ca.Id

ORDER BY 'Full Name' ASC, t.Id ASC

SELECT	t.Id, 
		a.FirstName + ' ' + ISNULL(a.MiddleName + ' ', '') + a.LastName AS FullName,
		c.[Name] AS Hometown,
		a.[Name] AS [To], 
    CASE 
        WHEN t.CancelDate IS NULL THEN CONCAT(DATEDIFF(DAY, t.ArrivalDate,t.ReturnDate),' ', 'days')
        ELSE 'Canceled'
        END AS Duration
        FROM AccountsTrips AS [at]
            JOIN Accounts AS a ON a.Id = [at].AccountId
            JOIN Trips AS t ON t.Id = [at].TripId
            JOIN Cities AS c ON a.CityId = c.Id
            JOIN Rooms AS r ON t.RoomId = r.Id
            JOIN Hotels AS h ON r.HotelId = h.Id
            JOIN Cities AS ca ON h.CityId = ca.Id
            ORDER BY FullName ASC,
                t.Id ASC