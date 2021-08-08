SELECT MountainRange, PeakName, Elevation 
	FROM Mountains
	JOIN Peaks ON Mountains.Id = Peaks.MountainId
	WHERE Mountains.MountainRange = 'Rila'
	ORDER BY Elevation DESC
