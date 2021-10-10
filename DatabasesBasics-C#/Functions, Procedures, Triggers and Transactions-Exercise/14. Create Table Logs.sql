CREATE TABLE Logs 
(
	LogId INT PRIMARY KEY IDENTITY, 
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id), 
	OldSum DECIMAL(15,2) NOT NULL, 
	NewSum DECIMAL(15,2) NOT NULL
)

CREATE OR ALTER TRIGGER tr_InsertAccountInfo
ON Accounts FOR UPDATE
AS
	DECLARE @AccountIdDate INT  = (SELECT Id FROM inserted )
	DECLARE @OldSumDate DECIMAL(15,2) =(SELECT Balance FROM deleted);
	DECLARE @NewSumDate DECIMAL(15,2) = (SELECT Balance FROM inserted);
	INSERT INTO Logs(AccountId, OldSum, NewSum) VALUES
		(@AccountIdDate, @OldSumDate, @NewSumDate)		


UPDATE Accounts
SET Balance -= 100
WHERE Id = 1

SELECT * FROM Logs