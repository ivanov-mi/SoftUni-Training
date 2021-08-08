--10. GDPR Violation
SELECT t.Id, 
		(SELECT
			CASE 
				WHEN a1.MiddleName IS  NULL THEN (a1.FirstName + ' ' + a1.LastName)
				ELSE (a1.FirstName + ' ' + a1.MiddleName + ' ' + a1.LastName)
			END AS [FullName] 
			FROM Accounts AS a1
			WHERE a1.Id = a.Id
		) AS [FullName] ,
		(SELECT [Name] FROM Cities WHERE Id = a.CityId) AS [From],
		(SELECT [Name] FROM Cities WHERE Id = h.CityId) AS [To],
		(SELECT
			CASE 
				WHEN t1.CancelDate IS NOT NULL THEN 'Canceled'
				ELSE CAST(DATEDIFF(DAY, t1.ArrivalDate, t1.ReturnDate) AS nvarchar) + ' days'
			END AS [Duration] 
			FROM Trips AS t1
			WHERE t1.Id = t.Id
		) AS [Duration]
	FROM Accounts AS a
	JOIN Cities AS c ON a.CityId = c.Id
	JOIN AccountsTrips AS at ON a.Id = at.AccountId
	JOIN Trips AS t ON at.TripId = t.Id
	JOIN Rooms AS r ON t.RoomId = r.Id
	JOIN Hotels AS h ON r.HotelId = h.Id
	ORDER BY [FullName], t.Id