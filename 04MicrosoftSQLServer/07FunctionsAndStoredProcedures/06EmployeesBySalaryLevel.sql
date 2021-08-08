CREATE PROCEDURE usp_EmployeesBySalaryLevel (@salaryLevel NVARCHAR(10))
AS
	SELECT [First Name], [Last Name]
		FROM (SELECT 
			FirstName AS [First Name], 
			LastName AS [Last Name], 
			[dbo].[ufn_GetSalaryLevel](Salary) AS SalaryLevel
		FROM Employees) AS SubQuery
	WHERE SalaryLevel = @salaryLevel