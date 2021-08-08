--4.	Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown  (@townName NVARCHAR(50))
AS
	SELECT e.FirstName AS [First Name], e.LastName AS [Last Name]
	FROM Employees AS e
	JOIN Addresses AS A ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	WHERE t.[Name] = @townName