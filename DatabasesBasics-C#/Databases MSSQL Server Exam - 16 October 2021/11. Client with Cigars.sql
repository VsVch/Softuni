CREATE OR ALTER FUNCTION udf_ClientWithCigars(@name VARCHAR(30)) 
RETURNS INT
AS
BEGIN
	DECLARE @Result INT = (SELECT COUNT(*)
			FROM Clients AS c
			JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
			JOIN Cigars AS ci ON ci.Id =cc.CigarId
			WHERE FirstName = @name)
RETURN @Result
END

SELECT dbo.udf_ClientWithCigars('Betty')

SELECT COUNT(*)
FROM Clients AS c
JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
JOIN Cigars AS ci ON ci.Id =cc.CigarId
WHERE FirstName = 'Betty'