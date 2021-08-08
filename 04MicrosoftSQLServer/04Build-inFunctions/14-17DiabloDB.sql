--Problem 14.	Games from 2011 and 2012 year
SELECT TOP 50 [Name], Format([Start], 'yyyy-MM-dd') AS [Start]
	FROM Games
	WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012
	ORDER BY Start, [Name]

--Problem 15.	 User Email Providers
SELECT Username, 
	RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
	FROM Users
	ORDER BY [Email Provider], Username

--Problem 16.	 Get Users with IPAdress Like Pattern
SELECT Username, IpAddress
	FROM Users
	WHERE IpAddress LIKE '___.1%.%.___'
	ORDER BY Username

--Problem 17.	 Show All Games with Duration and Part of the Day
SELECT [Name] AS Game,
	CASE 
		WHEN DATEPART(HOUR, Start) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(HOUR, Start) BETWEEN 12 AND 17 THEN 'Afternoon'
		Else 'Evening'
	END AS [Part Of the Day],
		CASE 
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		Else 'Extra Long'
	END AS [Duration]
	FROM Games
	ORDER BY [Name], [Duration], [Part Of the Day]