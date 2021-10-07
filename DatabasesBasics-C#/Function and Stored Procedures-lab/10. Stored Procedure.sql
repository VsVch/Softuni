CREATE PROC sp_RecreateProjects
AS		
	INSERT INTO Projects(Name, Description, StartDate,EndDate)
	SELECT '[new]' + Name, Description, StartDate,EndDate FROM Projects

GO