SELECT TOP(5) c.CountryName,
		CASE
			WHEN p.PeakName IS NULL THEN '(no highest peak)'       
			ELSE p.PeakName
        END AS 'Highest Peak Name',
			CASE 
			WHEN p.Elevation IS NULL THEN '0'
			ELSE p.Elevation
		END AS 'Highest Peak Elevation',
		CASE
			WHEN m.MountainRange IS NULL THEN '(no mountain)'
			ELSE m.MountainRange
		END	AS Mountain
FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m .Id
	LEFT JOIN Peaks AS p ON m.Id = p.MountainId

ORDER BY CountryName, [Highest Peak Elevation] DESC