
SELECT TOP(5)
		r.Id,
	   r.Name,
	   COUNT(r.Name) AS Commits
FROM Repositories AS r
JOIN RepositoriesContributors AS rc ON r.Id =rc.RepositoryId
JOIN Users AS u ON rc.ContributorId = u.Id
JOIN Commits AS c ON c.RepositoryId = r.Id
GROUP BY r.Name, r.Id
ORDER BY Commits DESC, r.Id, r.Name


SELECT * 
FROM Repositories
