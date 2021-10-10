CREATE PROC usp_GetTownsStartingWith(@Symbol NVARCHAR(50))
AS
BEGIN
	SELECT [Name] AS Town
	FROM Towns
	--WHERE @Symbol = LEFT(Name, 1)
	WHERE [Name] LIKE @Symbol + '%'
END

EXEC dbo.usp_GetTownsStartingWith b
