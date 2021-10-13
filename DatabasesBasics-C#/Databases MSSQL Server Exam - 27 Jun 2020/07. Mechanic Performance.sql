SELECT  
	FirstName + ' ' + LastName AS 'Mechanic',
	AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS 'Average Days'      
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
WHERE j.Status = 'Finished'
GROUP BY m.MechanicId, FirstName + ' ' + LastName
ORDER BY m.MechanicId 

SELECT *
FROM Mechanics AS m
 JOIN Jobs AS j ON m.MechanicId = j.MechanicId
