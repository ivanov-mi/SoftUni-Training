--12.	Wrong Data
CREATE PROCEDURE usp_CancelFlights
AS
	UPDATE Flights
	SET DepartureTime = NULL, ArrivalTime = NULL
	WHERE DepartureTime < ArrivalTime