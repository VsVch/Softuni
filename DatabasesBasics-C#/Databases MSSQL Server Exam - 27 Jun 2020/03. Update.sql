SELECT * FROM Mechanics
WHERE MechanicId = 3


SELECT * 
FROM Jobs

SELECT * 
FROM Jobs
WHERE Status = 'Pending'

UPDATE Jobs
SET  MechanicId = 3
WHERE  Status = 'Pending'

UPDATE Jobs
SET Status = 'In Progress'
WHERE  Status = 'Pending'
