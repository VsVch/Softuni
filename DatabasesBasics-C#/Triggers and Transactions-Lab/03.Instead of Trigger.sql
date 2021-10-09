CREATE TRIGGER tr_OnDeleteAccountHoldersSetDeleted
ON AccountHolders INSTEAD OF DELETE
AS
	UPDATE AccountHolders SET IsDeleted = 1
		WHERE Id IN (SELECT Id FROM deleted)
GO