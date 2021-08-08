--7.	Passenger Trips
SELECT (p.FirstName + ' ' + p.LastName) AS [Full Name], 
		fl.Origin, 
		fl.Destination
	FROM Passengers AS p
	JOIN Tickets AS t ON p.Id = t.PassengerId
	JOIN Flights AS fl ON t.FlightId = fl.Id
	ORDER BY [Full Name], fl.Origin, fl.Destination