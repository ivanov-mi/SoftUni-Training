CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount 
	(@accountId INT, @interestRate FLOAT)
AS
	SELECT a.Id, 
		ah.FirstName AS [First Name], 
		ah.LastName AS [Last Name],
		a.Balance AS [Current Balance],
		[dbo].[ufn_CalculateFutureValue] (a.Balance, @interestRate, 5)
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
	WHERE a.Id = @accountId
