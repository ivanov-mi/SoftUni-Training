--2.	Create Table Emails
CREATE TRIGGER tr_CreateEmail ON Logs FOR INSERT
AS
	DECLARE @Recipient INT
	DECLARE @Subject VARCHAR(50)
	DECLARE @Body VARCHAR(MAX)
	
	SET @Recipient = (SELECT TOP(1) AccountId FROM inserted)
	SET @Subject = 'Balance change for account: ' + CAST(@Recipient AS VARCHAR)
	SET @Body = 'On ' + 
		CAST(GETDATE() AS VARCHAR) + 
		' your balance was changed from ' + 
		CAST((SELECT TOP(1) OldSum FROM inserted) AS VARCHAR) + 
		' to ' + 
		CAST((SELECT TOP(1) NewSum FROM inserted) AS VARCHAR)

	INSERT INTO NotificationEmails (Recipient, [Subject], Body)
	VALUES (@Recipient, @Subject, @Body)