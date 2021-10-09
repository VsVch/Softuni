-- TRIGGER ON UPDATE ACCOUNT +> INSERT LOGS

CREATE TABLE AccountChanges
(
	Id INT PRIMARY KEY IDENTITY,
	AccountId INT NOT NULL REFERENCES Accounts(Id),
	OldBalance MONEY NOT NULL,
	NewBalance MONEY NOT NULL,
	DateOfChange DATETIME NOT NULL
)

CREATE TRIGGER tr_OnAccountChangeAddLogRecord
ON Accounts FOR UPDATE
AS
	INSERT AccountChanges(AccountId, OldBalance, NewBalance, DateOfChange)
	SELECT i.Id, d.Balance, i.Balance, GETDATE() FROM inserted i
		JOIN deleted d ON i.Id = d.Id 
	WHERE i.Balance != d.Balance
GO