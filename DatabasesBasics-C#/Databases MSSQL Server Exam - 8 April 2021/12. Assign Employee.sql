CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
AS
	DECLARE @EmployeeDepartment NVARCHAR = (SELECT d.Name 
										  FROM Employees AS e
										  JOIN Departments AS d ON e.DepartmentId = d.Id
										  WHERE e.Id = @EmployeeId)

	DECLARE @ReportDepartment NVARCHAR = (SELECT d.Name
										  FROM Reports AS r
										  JOIN Categories AS c ON r.CategoryId = c.Id
										  JOIN Departments As d ON d.Id =c.DepartmentId
										  WHERE r.Id = @ReportId)
	IF(@EmployeeDepartment != @ReportDepartment)
		THROW 50021, 'Employee doesn''t belong to the appropriate department!', 1

	ELSE
		UPDATE Reports
			SET EmployeeId = @EmployeeId WHERE Id = @ReportId

	EXEC usp_AssignEmployeeToReport 30, 1

	EXEC usp_AssignEmployeeToReport 17, 2

	