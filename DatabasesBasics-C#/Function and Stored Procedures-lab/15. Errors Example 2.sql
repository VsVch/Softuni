CREATE PROC AddToProject(@EmployeeID INT, @Project INT)
AS
	DECLARE @EmplyeesProject INT = 
		(SELECT COUNT(*) FROM EmployeesProjects
			WHERE EmployeeID = @EmployeeID)

	IF(@EmplyeesProject >= 3)
		THROW 50001, 'employee has more than 3 projects', 1;

	DECLARE @EmployeeInThisProjectCount INT =
		(SELECT COUNT(*) FROM EmployeesProjects
			WHERE EmployeeID = @EmployeeID
				AND ProjectID = @Project)
	IF(@EmployeeInThisProjectCount >= 1)
		THROW 50002, 'Employee already in this project',1

	INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
		VALUES(@EmployeeID, @Project)
GO