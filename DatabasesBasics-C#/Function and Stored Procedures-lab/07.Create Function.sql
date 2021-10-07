CREATE FUNCTION udf_EmploeesByYear(@Year SMALLINT)
RETURNS TABLE
AS
RETURN
(
SELECT * FROM Employees
WHERE YEAR(HireDate) = @Year
)