CREATE FUNCTION ufn_CashInUsersGame (@gameName NVARCHAR(100))
RETURNS TABLE
AS
	RETURN
		(
		SELECT SUM(orderedGames.Cash) AS [SumCash]
		FROM 
			(SELECT 
				ug.Cash,
				ROW_NUMBER() OVER (PARTITION BY g.Name ORDER BY ug.CASH DESC) AS [cashOrderId]
			FROM UsersGames AS ug
			JOIN Games AS g ON ug.GameId = g.Id
			WHERE g.Name = @gameName) AS [orderedGames]
		WHERE orderedGames.cashOrderId % 2 = 1) 
