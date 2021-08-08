--4.	Withdraw Money
CREATE PROCEDURE usp_WithdrawMoney @AccountId INT, @MoneyAmount DECIMAL(15,4)
AS
BEGIN TRANSACTION
	IF(@MoneyAmount IS NULL OR @MoneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid money amount!', 16, 1)
		RETURN 
	END

	IF(@AccountId IS NULL OR 
		NOT EXISTS(SELECT Id
		FROM Accounts
		WHERE Id = @AccountId))
	BEGIN
		ROLLBACK
		RAISERROR('Invalid account ID!', 16, 2)
		RETURN 
	END

	DECLARE @availableAmount DECIMAL(15,4)
	SET @availableAmount = (SELECT Balance
							FROM Accounts
							WHERE Id = @AccountId)
	IF(@availableAmount IS NULL OR @availableAmount < @MoneyAmount)
	BEGIN
		ROLLBACK
		RAISERROR('Insufficient amount!', 16, 3)
		RETURN 
	END

	UPDATE Accounts
		SET Balance -= @MoneyAmount
		WHERE Id = @AccountId
COMMIT