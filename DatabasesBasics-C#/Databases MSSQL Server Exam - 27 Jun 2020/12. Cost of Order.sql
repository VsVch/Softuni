CREATE FUNCTION udf_GetCost(@jobsId INT)
RETURNS DECIMAL(15,2)
AS
BEGIN
	DECLARE @Price DECIMAL(15,2)
	
	SET @Price = (SELECT SUM(p.Price * op.Quantity) AS Result
						FROM Jobs AS j
						JOIN Orders AS o ON o.JobId = j.JobId
						JOIN OrderParts AS op ON o.OrderId = op.OrderId
						JOIN Parts AS p ON p.PartId = op.PartId
						WHERE j.JobId = @jobsId
						GROUP BY j.JobId)
	IF (@Price IS NULL)
		SET @Price = 0		
	RETURN @Price
END

SELECT dbo.udf_GetCost(1)


