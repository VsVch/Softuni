SELECT PeakName,RiverName, CONCAT(LOWER(SUBSTRING(PeakName, 1, LEN(PeakName) - 1)), LOWER(RiverName)) AS Mix
FROM (SELECT Peaks.PeakName, Rivers.RiverName  --Orders.OrderID, Customers.CustomerName, Orders.OrderDate
FROM Peaks
JOIN Rivers ON LOWER(RIGHT(Peaks.PeakName, 1)) = LOWER(LEFT(Rivers.RiverName, 1))--Customers ON Orders.CustomerID=Customers.CustomerID;
) AS Mix
ORDER BY Mix 