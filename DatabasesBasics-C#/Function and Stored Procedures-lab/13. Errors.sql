CREATE FUNCTION udf_HoursToCompleteLab(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF	@StartDate IS NULL AND @EndDate IS NULL
		THROW 50001, 'Start date and end date is both null', 1
	IF @StartDate IS NULL
		RETURN 0;
	IF @EndDate IS NULL 
		RETURN 0;
	RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END