--13. Departments Total Salaries
SELECT e.DepartmentID, SUM(e.Salary) AS [TotalSalary]
	FROM Employees AS e
	GROUP BY e.DepartmentID

--14. Employees Minimum Salaries
SELECT e.DepartmentID, MIN(e.Salary) AS [MinimumSalary]
	FROM Employees AS e
	WHERE e.DepartmentID IN (2, 5, 7) AND e.HireDate > '2000-01-01'
	GROUP BY e.DepartmentID

--15. Employees Average Salaries
SELECT *
	INTO HigherSalaryEmployees
	FROM Employees AS e
	WHERE e.Salary > 30000
	DELETE FROM HigherSalaryEmployees 
		WHERE  HigherSalaryEmployees.ManagerID = 42
	UPDATE HigherSalaryEmployees
	SET HigherSalaryEmployees.Salary += 5000
	WHERE HigherSalaryEmployees.DepartmentID = 1
SELECT hse.DepartmentID, AVG(hse.Salary)
	FROM HigherSalaryEmployees AS hse
	GROUP BY hse.DepartmentID

--16. Employees Maximum Salaries
SELECT e.DepartmentID, MAX(e.Salary) AS [MaxSalary]
	FROM Employees AS e
	GROUP BY e.DepartmentID
	HAVING MAX(e.Salary) < 30000 OR MAX(e.Salary) > 70000

--17. Employees Count Salaries
SELECT Count(*) AS [Count]
	FROM Employees AS e
	GROUP BY e.ManagerID
	HAVING e.ManagerID IS NULL

--18. *3rd Highest Salary
SELECT DISTINCT DepartmentID, 
	Salary
	FROM (SELECT DepartmentID, 
		Salary,
		DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS DepartmentSalaryRank
		FROM Employees) AS Ranking
	WHERE DepartmentSalaryRank = 3

--19. **Salary Challenge
SELECT TOP(10) e1.FirstName, 
	e1.LastName,
	e1.DepartmentID
	FROM Employees AS e1
	WHERE Salary > (SELECT AVG(Salary) 
		FROM Employees AS e2
		WHERE e1.DepartmentID = e2.DepartmentID
		GROUP BY e2.DepartmentID)



	
