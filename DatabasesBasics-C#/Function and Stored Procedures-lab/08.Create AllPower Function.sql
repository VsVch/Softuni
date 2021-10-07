CREATE FUNCTION udf_AllPowers(@MaxPower INT)
RETURNS @Table TABLE(Id INT IDENTITY PRIMARY KEY, Square BIGINT)
AS
BEGIN
	DECLARE @I INT = 1;
	WHILE (@MaxPower >= @I)
	BEGIN
		INSERT INTO @Table (Square) VALUEs (@I * @I);
		SET @I += 1;
	END
	RETURN
END