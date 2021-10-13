SELECT CONCAT(FirstName,' ',LastName) 
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
GROUP BY m.MechanicId, CONCAT(FirstName,' ',LastName)
HAVING COUNT(j.FinishDate) = COUNT(j.Status)
ORDER BY m.MechanicId


SELECT * 
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId