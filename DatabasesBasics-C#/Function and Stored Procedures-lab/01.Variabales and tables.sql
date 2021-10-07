DECLARE @Year SMALLINT = 2021;
SELECT @Year;

SET @Year = @Year + 1;

DECLARE @MyTempTable  TABLE (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(MAX)
)

INSERT INTO @MyTempTable (Name) VALUES ('Sasho');

SELECT * FROM @MyTempTable

GO -- Clear all variabales and tables