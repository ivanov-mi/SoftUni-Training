--3.	Update
UPDATE Tickets
	SET Price *= 1.13
	FROM Tickets AS t
	JOIN Flights AS fl ON t.FlightId = fl.Id
	WHERE fl.Destination = 'Carlsbad'