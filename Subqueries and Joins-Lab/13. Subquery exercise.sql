SELECT * FROM
(SELECT * FROM Employees
WHERE JobTitle LIKE 'Production%') AS e
WHERE e.HireDate BETWEEN '2000-12-31' AND '2002-01-01'