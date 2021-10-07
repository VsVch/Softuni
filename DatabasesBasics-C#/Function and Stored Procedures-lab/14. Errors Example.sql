CREATE PROC sp_AddEmploeeToProject(@EmploeeyId INT, @ProjectId INT)
AS
	DECLARE @CountEmploeeyProject INT =
		(SELECT COUNT(*) FROM EmployeesProjects
			WHERE EmployeeID = @EmploeeyId 
				AND ProjectID = @ProjectId);
	IF @CountEmploeeyProject > 0
		THROW 50001, 'This emploeey is already in the project', 1

		INsERT INTO EmployeesProjects(EmployeeID, ProjectID)
			VALUES(@EmploeeyId, @ProjectId);
