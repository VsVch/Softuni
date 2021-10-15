SELECT 
	a.Id,
	a.Email,
	c.Name,
	COUNT(c.Name)
FROM Accounts AS a
JOIN AccountsTrips AS at ON a.Id = at.AccountId
JOIN Trips AS t ON at.TripId = t.Id
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN Cities AS c ON c.Id = h.CityId
WHERE a.CityId = h.CityId
GROUP BY c.Name, a.Email,  a.Id
ORDER BY COUNT(c.Name) DESC, a.Id




SELECT * FROM Accounts