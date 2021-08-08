--2.	Employees with Salary Above Number
CREATE OR ALTER PROCEDURE usp_GetEmployeesSalaryAboveNumber (@salary decimal(18,4))
AS
	SELECT FirstName AS [First Name], LastName AS [Last Name]
	FROM Employees
	WHERE Salary >= @salary