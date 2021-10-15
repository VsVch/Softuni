SELECT * FROM Repositories
WHERE Name = 'Softuni-Teamwork'

SELECT * FROM RepositoriesContributors
WHERE RepositoryId = 3

SELECT * FROM Issues 
WHERE RepositoryId = 3

DELETE RepositoriesContributors
WHERE RepositoryId = 3

DELETE Issues 
WHERE RepositoryId = 3