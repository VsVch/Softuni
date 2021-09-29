WiTH AvgSalaryCTE (AvgSalary)
AS
(
	SELECT AVG(Salary) AS AvgSalary FROM Employees GROUP BY DepartmentID
)
SELECT MIN(AvgSalary) FROM AvgSalaryCTE