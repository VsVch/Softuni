
CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
BEGIN TRANSACTION
	DECLARE @Acount INT = (SELECT Id FROM Accounts WHERE Id = @AccountId)
	DECLARE @Balance DECIMAL(18,4)= (SELECT Balance FROM Accounts WHERE Id = @AccountId)
	
	IF (@Acount IS NULL)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Invalid account!', 1
		RETURN;
	END
	IF(@MoneyAmount < 0)
	BEGIN
		ROLLBACK;
		THROW 50002, 'Money should be positive number!', 1
		RETURN;
	END
	IF((@Balance - @MoneyAmount) < 0)
	BEGIN
		ROLLBACK;
		THROW 50002, 'Money should be positive number!', 1
		RETURN;
	END

	UPDATE Accounts SET Balance -= @MoneyAmount WHERE Id =@AccountId
COMMIT