--11.	Vacation
CREATE FUNCTION udf_CalculateTickets
	(@origin NVARCHAR(50), @destination NVARCHAR(50), @peopleCount INT)
	RETURNS NVARCHAR(50)
	AS
	BEGIN
		IF(@peopleCount IS NULL OR @peopleCount <= 0)
				RETURN 'Invalid people count!'

		DECLARE @flightId INT

		SET @flightId = (SELECT TOP(1) Id FROM Flights WHERE Origin = @origin AND Destination = @destination)

		IF(@origin IS NULL OR @destination IS NULL OR @flightId IS NULL)
				RETURN 'Invalid flight!'

		DECLARE @singlTicketPrice DECIMAL(15,2)
		SET @singlTicketPrice = (SELECT Price
								FROM Flights AS fl
								JOIN Tickets AS t ON fL.Id = t.FlightId
								WHERE fl.Id = @flightId)

		DECLARE @ticketsPrice DECIMAL(15,2) = @singlTicketPrice * @peopleCount

		RETURN 'Total price ' + CAST(@ticketsPrice AS NVARCHAR)
	END