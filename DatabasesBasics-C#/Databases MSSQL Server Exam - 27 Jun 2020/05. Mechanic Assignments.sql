SELECT 
	m.FirstName + ' ' + LastName As FullName,
	j.Status AS 'Job Status',
	j.IssueDate AS 'Job Issue Date'
FROM Mechanics AS m
JOIN Jobs AS j ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId
