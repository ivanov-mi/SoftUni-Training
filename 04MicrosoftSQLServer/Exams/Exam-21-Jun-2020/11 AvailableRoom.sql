--11. Available Room
CREATE OR ALTER FUNCTION udf_GetAvailableRoom
	(@HotelId INT, @Date DATE, @People INT) 
	RETURNS NVARCHAR(100)
	AS
	BEGIN
		DECLARE @result NVARCHAR(100)

		DECLARE @t TABLE(
			RoomId INT NOT NULL,
			RoomType NVARCHAR(20) NOT NULL,
			Beds INT NOT NULL,
			TotalPrice DECIMAL(15,2) NOT NULL)

		INSERT INTO @t (RoomId, RoomType, Beds, TotalPrice)
		SELECT TOP(1)
				r.Id,
				r.[Type],
				r.Beds,
				(h.BaseRate + r.Price)*2 AS [TotalPrice]
			FROM Hotels AS h
			JOIN Rooms AS r ON h.Id = r.HotelId
			JOIN Trips AS t ON r.Id = t.RoomId
			WHERE @HotelId = h.Id AND
				@People <= r.Beds AND
				r.Id NOT IN ( SELECT r.Id 
					FROM Hotels AS h
					JOIN Rooms AS r ON h.Id = r.HotelId
					JOIN Trips AS t ON r.Id = t.RoomId
					WHERE @Date BETWEEN t.ArrivalDate AND t.ReturnDate AND t.CancelDate IS NULL)
			ORDER BY [TotalPrice] DESC

			DECLARE @RoomId INT = (SELECT TOP(1) RoomId FROM @t)
			DECLARE @RoomType NVARCHAR(20) = (SELECT TOP(1) RoomType FROM @t)
			DECLARE @Beds INT = (SELECT TOP(1) Beds FROM @t)
			DECLARE @TotalPrice DECIMAL(15,2) = (SELECT TOP(1) TotalPrice FROM @t)

			IF (@RoomId IS NULL)
				SET @result = 'No rooms available'

			ELSE 
				SET @result = 'Room ' + 
				CAST(@RoomID AS nvarchar) + ': ' + 
				CAST(@RoomType AS nvarchar) + 
				' (' + CAST(@Beds AS nvarchar) + ' beds) - $' +
				CAST(@TotalPrice AS nvarchar)

		RETURN @result
	END