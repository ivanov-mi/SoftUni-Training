--10.	PSP
SELECT pl.[Name], pl.Seats, Count(t.PassengerId) AS [Passengers Count]
	FROM Planes AS pl
	LEFT JOIN Flights AS fl ON pl.Id = fl.PlaneId
	LEFT JOIN Tickets AS t ON fl.Id = t.FlightId
	GROUP BY pl.[Name], pl.Seats
	ORDER BY [Passengers Count] DESC, pl.[Name], pl.Seats