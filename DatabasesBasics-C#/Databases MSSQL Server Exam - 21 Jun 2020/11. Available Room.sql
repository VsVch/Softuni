CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR
AS
BEGIN
	DECLARE @RESERVATIONDATE INT = (SELECT * 
									 FROM Rooms AS r
									 JOIN Trips AS t On r.Id = t.RoomId
									 WHERE ArrivalDate < @Date AND ReturnDate <= @Date)

	DECLARE @DesireHotel INT = (SELECT Id
								FROM Hotels
								WHERE Id = @HotelId )

	DECLARE @Room INT = (SELECT TOP(1) Id
								FROM Rooms
								WHERE HotelId = @HotelId AND Beds >= @People
								ORDER BY Price DESC)

	DECLARE @CheckRoom INT = (SELECT HotelId 
								FROM Rooms
								WHERE HotelId = @HotelId AND  @Room IS NOT NULL	)

	DECLARE @Type NVARCHAR = (SELECT TOP(1) Type
								FROM Rooms
								WHERE HotelId = @HotelId AND Beds >= @People
								ORDER BY Price DESC)

	DECLARE @Beds INT = (SELECT TOP(1) Beds
								FROM Rooms
								WHERE HotelId = @HotelId AND Beds >= @People
								ORDER BY Price DESC)

	DECLARE @RoomPrice DECIMAL = (SELECT TOP(1) Price
								  FROM Rooms
								  WHERE HotelId = 112 AND Beds >= @People
								  ORDER BY Price DESC)

	DECLARE @HotelRate DECIMAL = (SELECT BaseRate
								  FROM Hotels
								  WHERE Id = @HotelId )

    DECLARE @Result NVARCHAR = NULL 

	

	IF(@RESERVATIONDATE IS NOT NULL OR 
	@DesireHotel IS NULL OR 
	@CheckRoom IS NOT NULL OR
	@Beds < @People)
		SET @Result = 'No rooms available'
	ELSE
		DECLARE @TotallPrice DECIMAL = (@HotelRate + @RoomPrice) * @People
		SET @Result = 'Room' + ' '+ @Room+':'+' ' + @Type+' '+ '('+@Beds+' '+'beds) - $'+@TotallPrice

		--Room {Room Id}: {Room Type} ({Beds} beds) - ${Total Price}

	RETURN @Result
END


CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS 
BEGIN 
    DECLARE @RoomsBooked TABLE (Id INT)
    INSERT INTO @RoomsBooked
        SELECT DISTINCT r.Id 
        FROM Rooms AS r
        LEFT JOIN Trips AS t ON t.RoomId = r.Id
        WHERE r.HotelId = @HotelId AND @Date BETWEEN t.ArrivalDate AND t.ReturnDate AND t.CancelDate IS NULL
 
    DECLARE @Rooms TABLE (Id INT, Price DECIMAL(15,2), [Type] VARCHAR(20), Beds INT, TotalPrice DECIMAL(15,2))
    INSERT INTO @Rooms
        SELECT TOP(1) r.Id, r.Price, r.[Type], r.Beds, ((h.BaseRate + r.Price) * @People) AS TotalPrice
        FROM Rooms AS r
        LEFT JOIN Hotels AS h ON r.HotelId = h.Id
        WHERE r.HotelId = @HotelId AND r.Beds >= @People AND r.Id NOT IN (SELECT Id 
                                                                            FROM @RoomsBooked)
        ORDER BY TotalPrice DESC
 
    DECLARE @RoomCount INT = (SELECT COUNT(*)  FROM @Rooms)
    IF (@RoomCount < 1)
        BEGIN
            RETURN 'No rooms available'
        END
 
    DECLARE @Result VARCHAR(MAX) = (SELECT CONCAT('Room ', Id, ': ', [Type],' (', Beds, ' beds',')', ' - ', '$', TotalPrice)
                                        FROM @Rooms)
    RETURN @Result
END