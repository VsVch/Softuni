--Conditional Statements
DECLARE @Year SMALLINT = 0;
DECLARE @MyTempTable  TABLE (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(MAX)
)

IF(YEAR(GETDATE()) =2021)
	BEGIN
		SET @Year =2021	
		INSERT INTO @MyTempTable (Name) VALUES ('Sasho')
	END
ELSE IF(YEAR(GETDATE())= 2024)
	SET @Year = 2024
ELSE
	SET @Year = -2000

SELECT @Year;
SELECT * FROM @MyTempTable;

DECLARE @Years SMALLINT = 2015;
SELECT CASE @Years
	WHEN 2021 THEN 'Lubo'
	WHEN 2015 THEN 'Misho'
	WHEN 1982 THEN 'Sasho'
	ELSE 'Unknown year'
END
