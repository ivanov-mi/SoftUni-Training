--1.	Employee Address
SELECT TOP(5) EmployeeID, JobTitle, a.AddressID, AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	ORDER BY a.AddressID

--2.	Addresses with Towns
SELECT TOP(50) FirstName, 
	LastName, 
	t.Name AS [Town], 
	AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	ORDER BY FirstName, LastName 

--3.	Sales Employee
SELECT EmployeeID, FirstName, LastName, d.Name AS [DepartmentName]
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	ORDER BY EmployeeID

--4.	Employee Departments
SELECT TOP(5) EmployeeID, 
	FirstName, 
	Salary, 
	d.Name AS [DepartmentName]
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary > 15000
	ORDER BY d.DepartmentID

--5.	Employees Without Project
SELECT TOP(3) e.EmployeeID, e.FirstName
	FROM Employees AS e
	LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	WHERE ep.EmployeeID IS NULL
	ORDER BY  e.EmployeeID

--6.	Employees Hired After
SELECT e.FirstName, 
	e.LastName,
	e.HireDate, 
	d.Name AS [DeptName]
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE HireDate > '1999-01-01' 
		AND d.Name IN ('Sales', 'Finance')
	ORDER BY HireDate 

--7.	Employees with Project
SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name AS [ProjectName]
	FROM Employees AS e
	LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
	WHERE p.StartDate >= '2002-08-12' AND p.EndDate IS NULL
	ORDER BY e.EmployeeID

--8.	Employee 24
SELECT e.EmployeeID, 
	e.FirstName, 
	CASE 
		WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL   
		ELSE p.Name
	END AS [ProjectName]
	FROM Employees AS e
	LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID 
	WHERE	e.EmployeeID = 24

--9.	Employee Manager
SELECT e.EmployeeID, 
	e.FirstName, 
	e.ManagerID, 
	m.FirstName AS [ManagerName]
	FROM Employees AS e
	JOIN Employees AS m ON e.ManagerID = m.EmployeeID
	WHERE e.ManagerID IN (3, 7)
	ORDER BY e.EmployeeID
	
--10. Employee Summary
SELECT TOP(50) e.EmployeeID,
	(e.FirstName + ' ' + e.LastName) AS [EmployeeName],
	(m.FirstName + ' ' + m.LastName) AS [ManagerName],
	d.Name AS [DepartmentName]
	FROM Employees AS e
	JOIN Employees AS m ON e.ManagerID = m.EmployeeID
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	ORDER BY e.EmployeeID

--11. Min Average Salary
SELECT TOP(1) AVG(e.Salary) AS [MinAverageSalary]
	FROM Employees AS e
	GROUP BY e.DepartmentID
	ORDER BY MinAverageSalary