CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT
AS
BEGIN	
	DECLARE @Result INT = 0;
	IF(@StartDate IS NULL OR @EndDate IS NULL)
		SET @Result = 0
	ELSE
		SET @Result = DATEDIFF(HOUR,@StartDate,@EndDate )

	RETURN @Result 
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports
