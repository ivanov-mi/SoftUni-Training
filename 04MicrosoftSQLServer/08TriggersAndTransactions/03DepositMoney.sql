--3.	Deposit Money
CREATE OR ALTER PROCEDURE usp_DepositMoney @AccountId INT, @MoneyAmount DECIMAL(15,4)
AS
BEGIN TRANSACTION
	IF (@MoneyAmount < 0 OR @MoneyAmount IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount!', 16, 1)
		RETURN
	END

	IF (NOT EXISTS (SELECT Id 
			FROM Accounts 
			WHERE @AccountId = Id) OR 
		@AccountId IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid Account ID!', 16, 2)
		RETURN
	END

	UPDATE Accounts
		SET Balance +=  @MoneyAmount
		WHERE Id = @AccountId
COMMIT