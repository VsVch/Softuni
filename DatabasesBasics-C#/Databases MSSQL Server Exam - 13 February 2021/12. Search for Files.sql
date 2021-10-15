CREATE OR ALTER PROC usp_SearchForFiles(@fileExtension NVARCHAR(50))
AS	
	SELECT id, Name, FORMAT(Size, '' )+ 'KB' AS Size
	FROM Files
	WHERE SUBSTRING(Name, CHARINDEX('.', Name, 1) +1, LEN(Name)) = @fileExtension
	ORDER BY Id, Name, Size DESC


EXEC usp_SearchForFiles 'txt'


