CREATE TABLE Deleted_Employees
(
EmployeeId INT PRIMARY KEY IDENTITY, 
FirstName NVARCHAR(50) NOT NULL, 
LastName NVARCHAR(50) NOT NULL, 
MiddleName NVARCHAR(50) NOT NULL, 
JobTitle NVARCHAR(100) NOT NULL, 
DepartmentId INT, 
Salary DECIMAL(15,2)
)

CREATE TRIGGER tr_Deleted_Employees ON Employees FOR DELETE
AS	
	INSERT INTO Deleted_Employees (FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	SELECT  FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary FROM deleted 