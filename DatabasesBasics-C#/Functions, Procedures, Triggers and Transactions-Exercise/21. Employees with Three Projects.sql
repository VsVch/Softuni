CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT) 
AS
BEGIN TRANSACTION
	DECLARE @CurrEmployee INT = (SELECT EmployeeID FROM Employees WHERE @emloyeeId = EmployeeID)
	DECLARE @CurrProject INT = (SELECT ProjectID FROM Projects WHERE @projectID = ProjectID)
	DECLARE @NumberOfProject INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE @emloyeeId = EmployeeID)
										   
										   
	IF(@CurrEmployee IS NULL)	
		BEGIN
			ROLLBACK;
			THROW 50001,'Invalid Employee id!', 1
			RETURN;
		END

	IF(@CurrProject IS NULL)
		BEGIN
			ROLLBACK;
			THROW 50002, 'Invalid Project id', 1
			RETURN;
		END	

	IF(@NumberOfProject >= 3)
		BEGIN
			ROLLBACK;
			THROW 50003, 'The employee has too many projects!', 1
			RETURN;
		END			
	
		INSERT INTO EmployeesProjects (EmployeeID, ProjectID) VALUES (@emloyeeId, @projectID)
COMMIT	
	