UPDATE Issues
	SET IssueStatus = 'closed' WHERE AssigneeId = 6

SELECT * FROM Issues WHERE AssigneeId = 6