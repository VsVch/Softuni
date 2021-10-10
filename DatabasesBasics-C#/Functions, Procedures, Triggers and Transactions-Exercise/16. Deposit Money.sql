
CREATE OR ALTER PROC usp_DepositMoney (@UserAccountId INT, @MoneyAmount DECIMAL(18,4))
AS
BEGIN TRANSACTION
	DECLARE @Account INT = (SELECT Id FROM Accounts WHERE @UserAccountId = Id);
IF (@Account IS NULL) 
	BEGIN
		ROLLBACK;
		THROW 50001, 'Account not found!', 1;
		RETURN;
	END
IF (@MoneyAmount < 0)
	BEGIN
		ROLLBACK;
		THROW 50002, 'Monye should be positive number', 1;
		RETURN;
	END
UPDATE Accounts SET Balance += @MoneyAmount WHERE @UserAccountId = Id
COMMIT

SELECT * FROM Accounts


