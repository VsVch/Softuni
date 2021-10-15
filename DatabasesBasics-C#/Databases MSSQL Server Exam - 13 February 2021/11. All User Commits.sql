CREATE FUNCTION udf_AllUserCommits(@username NVARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*) FROM Users AS u
								 JOIN Commits AS c ON u.Id = c.ContributorId
								 WHERE u.Username = @username)


END

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')