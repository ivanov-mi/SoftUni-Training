CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan (@accountBallance MONEY)
AS
	SELECT ah.FirstName AS [First Name], ah.LastName AS [Last Name]
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @accountBallance
	ORDER BY ah.FirstName, ah.LastName