--5.	Money Transfer
CREATE PROCEDURE usp_TransferMoney 
	(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15, 4)) 
AS
BEGIN TRANSACTION
	IF (@Amount < 0 OR @Amount IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount!', 16, 1)
		RETURN
	END

	IF (@SenderId IS NULL OR
			NOT EXISTS (SELECT Id 
			FROM Accounts 
			WHERE @SenderId = Id))
	BEGIN
		ROLLBACK
		RAISERROR('Invalid Sender Account ID!', 16, 2)
		RETURN
	END

	IF (@ReceiverId IS NULL OR
			NOT EXISTS (SELECT Id 
			FROM Accounts 
			WHERE @ReceiverId = Id))
	BEGIN
		ROLLBACK
		RAISERROR('Invalid Receiver Account ID!', 16, 3)
		RETURN
	END

	DECLARE @availableAmount DECIMAL(15,4)
	SET @availableAmount = (SELECT Balance
							FROM Accounts
							WHERE Id = @SenderId)

	IF(@availableAmount IS NULL OR @availableAmount < @Amount)
	BEGIN
		ROLLBACK
		RAISERROR('Insufficient amount!', 16, 4)
		RETURN 
	END

	UPDATE Accounts
		SET Balance -=  @Amount
		WHERE Id = @SenderId

	UPDATE Accounts
		SET Balance += @Amount
		WHERE Id = @ReceiverId
COMMIT