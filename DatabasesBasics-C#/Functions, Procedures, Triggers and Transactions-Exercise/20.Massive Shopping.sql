
DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = 9 AND GameId = 87)

DECLARE @stamatCash DECIMAL(15, 2) = 
(SELECT Cash FROM UsersGames WHERE Id = @userGameId)

DECLARE @itemPrice DECIMAL(15, 2) =
(SELECT SUM(Price) AS TotalPrice FROM Items WHERE MinLevel BETWEEN 11 AND 12)

IF(@stamatCash >= @itemPrice)
BEGIN
	BEGIN TRANSACTION
	UPDATE UsersGames
	SET Cash -=@itemPrice
	WHERE Id = @userGameId

	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT Id, @userGameId  FROM Items WHERE MinLevel BETWEEN 11 AND  12
	COMMIT
END


SET @stamatCash = 
(SELECT Cash FROM UsersGames WHERE Id = @userGameId)

SET @itemPrice  =
(SELECT SUM(Price) AS TotalPrice FROM Items WHERE MinLevel BETWEEN 19 AND 21)

IF(@stamatCash >= @itemPrice)
BEGIN
	BEGIN TRANSACTION
	UPDATE UsersGames
	SET Cash -=@itemPrice
	WHERE Id = @userGameId

	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN 19 AND 21
	COMMIT
END