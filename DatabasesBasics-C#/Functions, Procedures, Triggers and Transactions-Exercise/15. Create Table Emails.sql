CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY, 
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id), 
	[Subject] VARCHAR(MAX), 
	Body DATETIME
)

CREATE OR ALTER TRIGGER tr_RecordEmail
ON Logs FOR INSERT
AS	
	DECLARE @UserId INT = (SELECT TOP(1) AccountId FROM inserted)	
	DECLARE @OldSum DECIMAL(15,2) = (SELECT TOP(1) OldSum FROM inserted)
	DECLARE @NewSum DECIMAL(15,2) = (SELECT TOP(1) NewSum FROM inserted)
		
	INSERT INTO NotificationEmails(Recipient, [Subject], Body) VALUES 
		(@UserId,'Balance change for account: ' + CAST(@UserId AS varchar(100)), 
		'On '+ CONVERT(VARCHAR(30),GETDATE(), 103) +' your balance was changed from '+ CAST(@OldSum AS VARCHAR(30)) + ' to ' + CAST(@NewSum AS VARCHAR(30)))

