--8.	Employees with Three Projects
CREATE PROCEDURE usp_AssignProject (@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
	IF(@emloyeeId IS NULL OR
		NOT EXISTS(SELECT EmployeeID FROM Employees))
	BEGIN
		ROLLBACK
		RAISERROR('Invalid employee ID', 16, 2)
		RETURN
	END

	IF(@projectID IS NULL OR
		NOT EXISTS(SELECT ProjectID FROM Projects))
	BEGIN
		ROLLBACK
		RAISERROR('Invalid project ID', 16, 3)
		RETURN
	END

	DECLARE @projectsCount INT
	SET @projectsCount = (SELECT COUNT(ep.EmployeeID)
							FROM EmployeesProjects AS ep
							WHERE @emloyeeId = ep.EmployeeID)
	IF(@projectsCount >= 3)
	BEGIN
		ROLLBACK
		RAISERROR('The employee has too many projects!', 16, 1)
		RETURN
	END

	INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
	VALUES (@emloyeeId, @projectID)
COMMIT