CREATE TABLE Users
(	
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) NOT NULL,
	Password NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
)

CREATE TABLE Repositories
(	
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
)

CREATE TABLE RepositoriesContributors
(	
	RepositoryId INT REFERENCES Repositories(Id),
	ContributorId INT REFERENCES Users(Id),

	CONSTRAINT PK_RepositoriesContributors PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues
(	
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(255) NOT NULL,
	IssueStatus NVARCHAR(50) NOT NULL,
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits
(	
	Id INT PRIMARY KEY IDENTITY,
	Message NVARCHAR(255) NOT NULL,
	IssueId INT REFERENCES Issues(Id),
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(100) NOT NULL,
	Size DECIMAL(15,2) NOT NULL,
	ParentId INT REFERENCES Files(Id),
	CommitId INT REFERENCES Commits(Id)
)