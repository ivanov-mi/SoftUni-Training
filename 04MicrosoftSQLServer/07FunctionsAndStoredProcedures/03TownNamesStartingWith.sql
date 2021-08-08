--3.	Town Names Starting With
CREATE PROCEDURE usp_GetTownsStartingWith (@townName NVARCHAR(50))
AS
	SELECT [Name]
	FROM Towns
	WHERE [Name] LIKE (@townName + '%')