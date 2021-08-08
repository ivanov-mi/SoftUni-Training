--9.	Full Info
SELECT (p.FirstName + ' ' + p.LastName) AS [Full Name], 
		pl.[Name] AS [Plane Name],  
		(fl.Origin + ' - ' + fl.Destination) AS [Trip], 
		lt.[Type] AS [Luggage Type]
	FROM Passengers AS p
	JOIN Tickets AS t ON p.Id = t.PassengerId
	JOIN Flights AS fl ON t.FlightId = fl.Id
	JOIN Planes AS pl ON fl.PlaneId = pl.Id
	JOIN Luggages AS l ON t.LuggageId = l.Id
	JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
	ORDER BY [Full Name], [Name], fl.Origin, fl.Destination, lt.[Type]