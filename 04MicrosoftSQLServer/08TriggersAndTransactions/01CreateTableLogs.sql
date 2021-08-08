--01. Create Table Logs
CREATE TRIGGER tr_AccountChanges ON Accounts FOR UPDATE
AS
	DECLARE @newSum DECIMAL (15, 2) = (SELECT Balance FROM inserted)
	DECLARE @oldSum DECIMAL (15, 2) = (SELECT Balance FROM deleted)
	DECLARE @accoundId INT = (SELECT Id FROM inserted)

	INSERT INTO Logs (AccountId, OldSum, NewSuM) 
	VALUES (@accoundId, @oldSum, @newSum)