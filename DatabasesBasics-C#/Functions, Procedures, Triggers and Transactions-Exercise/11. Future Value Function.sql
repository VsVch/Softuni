CREATE OR ALTER FUNCTION ufn_CalculateFutureValue
(@initialSum DECIMAL(15,2), @yearInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(15,4)
AS
BEGIN
	DECLARE @Sum DECIMAL(15,4);		
	SET @Sum = @initialSum * (POWER((1 + @yearInterestRate), @numberOfYears));
	RETURN @Sum
END

 SELECT  dbo.ufn_CalculateFutureValue(1000, 0.1, 5)
 FROM AccountHolders