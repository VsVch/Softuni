CREATE OR ALTER PROC usp_TransferMoney(@SenderIdentity INT, @ReceiverIdentity INT, @AmountFounds DECIMAL(15,4))
AS
BEGIN TRANSACTION 
	EXEC dbo.usp_WithdrawMoney @SenderIdentity,  @AmountFounds
	EXEC dbo.usp_DepositMoney @ReceiverIdentity, @AmountFounds
COMMIT


EXEC usp_TransferMoney 5, 1 , 5000

SELECT * FROM Accounts WHERE Id =1 OR Id = 5