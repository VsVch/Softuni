SELECT dbo.ufn_IsWordComprised('oistmiahf','halves')

CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters NVARCHAR(MAX), @Word NVARCHAR(MAX))
RETURNS BIT
BEGIN
	DECLARE @Count INT = 1;

	WHILE(@Count <= LEN(@Word))
	BEGIN
		DECLARE @CurrChar CHAR(1) = SUBSTRING(@Word, @Count, 1)
		IF(CHARINDEX (@CurrChar, @SetOfLetters) = 0)
			RETURN 0		
	SET @Count += 1
	END
RETURN 1
END

