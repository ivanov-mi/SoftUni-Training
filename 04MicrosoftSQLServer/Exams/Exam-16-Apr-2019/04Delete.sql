--4.	Delete
DELETE Tickets
	FROM Tickets AS t
	JOIN Flights AS fl ON fl.Id = t.FlightId
	WHERE fl.Destination = 'Ayn Halagim'

DELETE Flights
	WHERE Destination = 'Ayn Halagim'

DELETE Planes
	FROM Planes AS p 
	JOIN Flights AS fl ON fl.Id = p.Id
	WHERE fl.Destination = 'Ayn Halagim'