CREATE OR ALTER PROC usp_TransferFunds(@FromAccId INT, @ToAccId INT, @Amount MONEY)
AS
BEGIN TRANSACTION
IF(SELECT Balance FROM Accounts WHERE Id = @FromAccId) < @Amount
	BEGIN
	ROLLBACK;
		THROW 50001, 'Insufficient founds', 1;
	END
IF(SELECT COUNT(*) FROM Accounts WHERE Id = @FromAccId) < 1
	BEGIN
		ROLLBACK;
		THROW 50002, 'Account not found!', 1;
	END
IF NOT EXISTS(SELECT * FROM Accounts WHERE Id =@ToAccId)
	BEGIN
		ROLLBACK;
		THROW 50003, 'Account not found!', 1;
	END
	UPDATE Accounts SET Balance = Balance - @Amount WHERE Id = @FromAccId;
	UPDATE Accounts SET Balance = Balance + @Amount WHERE Id = @ToAccId;
COMMIT