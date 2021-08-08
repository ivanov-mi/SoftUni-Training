--12. Highest Peaks in Bulgaria
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	FROM Countries AS c
	JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	JOIN Mountains AS m ON mc.MountainId = m.Id
	JOIN Peaks AS p ON m.Id = p.MountainId
	WHERE c.CountryName = 'Bulgaria' AND p.Elevation > 2835
	ORDER BY p.Elevation DESC

--13. Count Mountain Ranges
SELECT c.CountryCode, Count(c.CountryCode) AS MountainRanges
	FROM Countries AS c
	JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	JOIN Mountains AS m ON mc.MountainId = m.Id
	WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
	GROUP BY c.CountryCode

--14. Countries with Rivers
SELECT TOP(5) c.CountryName, r.RiverName
	FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	JOIN Continents AS cont ON c.ContinentCode = cont.ContinentCode
	WHERE cont.ContinentName = 'Africa'
	ORDER BY c.CountryName

--15. *Continents and Currencies
SELECT ContinentCode,
	   CurrencyCode,
	   CurrencyCount AS CurrencyUsage
	   FROM (SELECT ContinentCode,
			CurrencyCode,
			CurrencyCount,
			DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyCount DESC) AS CurrencyRank
			FROM (SELECT ContinentCode,
				CurrencyCode,
				count(*) AS CurrencyCount FROM Countries
				GROUP BY ContinentCode, CurrencyCode) AS subQuery
				WHERE CurrencyCount > 1) AS randomquery
WHERE CurrencyRank = 1
ORDER BY ContinentCode

--16. Countries Without Any Mountains
SELECT COUNT(c.CountryCode) AS Count
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	WHERE mc.MountainId IS NULL 

--17. Highest Peak and Longest River by Country
SELECT TOP(5) CountryName, 
	[HighestPeakElevation],
	[LongestRiverLength]
	FROM
		(SELECT c.CountryName, 
		p.Elevation AS [HighestPeakElevation],
		r.[Length] AS [LongestRiverLength],
		DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS [HighestPeakElevationRank],
		DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY r.[Length] DESC) AS [LongestRiverLengthRank]
		FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
		LEFT JOIN Peaks AS p ON m.Id = p.MountainId
		LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
		LEFT JOIN Rivers AS r ON cr.RiverId = r.Id) as SubQuery
	WHERE [HighestPeakElevationRank] = 1 AND 
		[LongestRiverLengthRank] = 1
	ORDER BY [HighestPeakElevation] DESC, 
		[LongestRiverLength] DESC, 
		CountryName

--18. Highest Peak Name and Elevation by Country
SELECT TOP(5) CountryName, 
	[Highest Peak Name],  
	[Highest Peak Elevation], 
	[Mountain]
	FROM 
		(SELECT c.CountryName, 
			CASE 
				WHEN p.PeakName IS NULL THEN '(no highest peak)'
				ELSE p.PeakName 
			END AS [Highest Peak Name], 
			p.Elevation,
			CASE 
				WHEN p.Elevation IS NULL THEN 0
				ELSE p.Elevation
			END AS [Highest Peak Elevation],
			m.MountainRange,
				CASE 
				WHEN m.MountainRange IS NULL THEN '(no mountain)'
				ELSE m.MountainRange
			END AS [Mountain],
			RANK() OVER (PARTITION BY CountryName ORDER BY p.Elevation DESC) AS [Rank]
			FROM Countries AS c
			LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
			LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
			LEFT JOIN Peaks AS p ON m.Id = p.MountainId) as SubQuery
	WHERE [Rank] = 1
	ORDER BY CountryName, [Highest Peak Name]