--First way to do it
/*SELECT TownID, Name
FROM Towns
WHERE [Name] LIKE '[M,K,B,E]%'
ORDER BY [Name] */

--Second way to do it

SELECT TownID, [Name]
FROM Towns
WHERE LEFT (Name, 1) IN ('M','K','B','E')
ORDER BY [Name]