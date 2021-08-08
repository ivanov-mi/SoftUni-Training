--12. Switch Room
CREATE OR ALTER PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS	
	DECLARE @currentHotelId INT = (SELECT TOP(1) r.HotelId
		FROM Rooms AS r
		JOIN Trips AS t ON r.Id = t.RoomId
		WHERE @TripId = t.Id)

	DECLARE @anotherHotelId INT = (SELECT TOP(1) r.HotelId
		FROM Rooms AS r
		JOIN Hotels AS h ON r.HotelId = h.Id
		WHERE @TargetRoomId = r.Id)

	IF(@currentHotelId IS NULL OR @anotherHotelId IS NULL OR @currentHotelId != @anotherHotelId)
		THROW 50005 ,'Target room is in another hotel!', 1

	DECLARE @tripAccounts INT = (SELECT TOP(1) COUNT(ac.AccountId)
	FROM Trips AS t
	JOIN AccountsTrips AS ac ON ac.AccountId = t.Id
	WHERE ac.TripId = 10)

	DECLARE @anotherRoomBeds INT = (SELECT TOP(1) r.Beds
		FROM Rooms AS r
		WHERE @TargetRoomId = r.Id)

	IF(@tripAccounts IS NULL OR @anotherRoomBeds IS NULL OR @anotherRoomBeds < @tripAccounts)
		THROW 50006 ,'Not enough beds in target room!', 1

	UPDATE Trips
		SET RoomId = @TargetRoomId