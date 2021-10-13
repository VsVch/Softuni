CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @CurrHotelRoom INT = (SELECT HotelId FROM Rooms WHERE Id = @TargetRoomId)
	DECLARE @CurrHotelTrip INT =  (SELECT r.HotelId FROM Trips AS t	
JOIN Rooms AS r ON t.RoomId = r.Id WHERE t.Id = @TripId)
	DECLARE @RoomBeads INT = (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId)
	DECLARE @NumberOfAccounts INt = (SELECT COUNT(*) FROM Accounts AS a
									JOIN AccountsTrips AS at ON a.Id = at.AccountId
									JOIN Trips AS t ON t.Id = at.TripId
									WHERE t.Id = @TripId)
IF(@CurrHotelRoom != @CurrHotelTrip)
	THROW 50001, 'Target room is in another hotel!',1

ELSE IF(@RoomBeads < @NumberOfAccounts)
	THROW 50001, 'Not enough beds in target room!',1
ELSE
	UPDATE Trips SET RoomId = @TargetRoomId

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10

EXEC usp_SwitchRoom 10, 7

EXEC usp_SwitchRoom 10, 8

SELECT * FROM Trips AS t
JOIN Rooms AS r ON t.RoomId = r.Id
WHERE t.Id = 2

SELECT COUNT(*) FROM Accounts AS a
JOIN AccountsTrips AS at ON a.Id = at.AccountId
JOIN Trips AS t ON t.Id = at.TripId
WHERE t.Id = 10



	