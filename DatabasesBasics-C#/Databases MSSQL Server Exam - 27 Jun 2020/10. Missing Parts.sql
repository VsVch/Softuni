SELECT p.PartId,p.Description, pn.Quantity, p.StockQty, o.Delivered -p.StockQty
FROM Jobs AS j
LEFT JOIN PartsNeeded AS pn ON  j.JobId = pn.JobId
LEFT JOIN Parts AS p ON pn.PartId = p.PartId
LEFT JOIN OrderParts AS op ON op.OrderId = p.PartId
LEFT JOIN Orders AS o ON op.OrderId = o.OrderId
WHERE j.Status != 'Finished' AND p.StockQty - pn.Quantity  < 0


SELECT *
FROM Jobs AS j
LEFT JOIN PartsNeeded AS pn ON  j.JobId = pn.JobId
LEFT JOIN Parts AS p ON pn.PartId = p.PartId
LEFT JOIN OrderParts AS op ON op.OrderId = p.PartId
JOIN Orders AS o ON op.OrderId = o.OrderId
WHERE j.Status != 'Finished'

SELECT * FROM Orders

SELECT 
	p.PartId,
	p.Description,
	pn.Quantity AS [Required],
	p.StockQty AS [InStock],	
	IIF(o.Delivered = 0, op.Quantity, 0)
	FROM Parts AS p	
	 LEFT JOIN PartsNeeded AS pn ON pn.PartId = p.PartId
	 LEFT JOIN OrderParts AS op ON op.PartId = p.PartId
	 LEFT JOIN Jobs AS j ON j.JobId = pn.JobId
	LEFT JOIN Orders AS o On o.JobId = j.JobId
WHERE j.Status != 'Finished' AND p.StockQty + IIF(o.Delivered = 0, op.Quantity, 0) < pn.Quantity
ORDER BY p.PartId