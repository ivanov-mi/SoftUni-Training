--9. Romantic Getaways
SELECT a.Id, a.Email, c.Name AS [City], COUNT(t.Id) AS [Trips]
	FROM Accounts AS a
	JOIN Cities AS c ON a.CityId = c.Id
	JOIN AccountsTrips AS at ON a.Id = at.AccountId
	JOIN Trips AS t ON at.TripId = t.Id
	JOIN Rooms AS r ON t.RoomId = r.Id
	JOIN Hotels AS h ON r.HotelId = h.Id
	WHERE a.CityId = h.CityId
	GROUP BY a.Id, a.Email, c.Name
	ORDER BY COUNT(t.Id) DESC, a.Id
