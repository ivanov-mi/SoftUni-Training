--7. Longest and Shortest Trips	
SELECT [AccountId], 
		[FullName], 
		MAX([Days]) AS [LongestTrip], 
		MIN([Days]) AS [ShortestTrip]
	FROM 
		(SELECT 
			at.AccountId AS [AccountId],
			(a.FirstName + ' ' + a.LastName) AS [FullName],
		DATEDIFF(DAY, ArrivalDate, ReturnDate) AS [Days]
		FROM AccountsTrips AS at 
		JOIN Accounts AS a ON at.AccountId = a.Id
		JOIN Trips AS t ON at.TripId = t.Id
		WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL) AS [LongestTrip]
	GROUP BY [AccountId], [FullName]
	ORDER BY [LongestTrip] DESC, [ShortestTrip]
