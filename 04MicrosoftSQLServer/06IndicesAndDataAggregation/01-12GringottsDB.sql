--1. Records� Count
SELECT COUNT(*) AS [Count]
	FROM WizzardDeposits

--2. Longest Magic Wand
SELECT MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits

--3. Longest Magic Wand Per Deposit Groups
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits
	GROUP BY DepositGroup

--4. * Smallest Deposit Group Per Magic Wand Size
SELECT TOP(2) DepositGroup
	FROM WizzardDeposits
	GROUP BY DepositGroup
	ORDER BY AVG(MagicWandSize)

--5. Deposits Sum
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	GROUP BY DepositGroup

--6. Deposits Sum for Ollivander Family
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup

--7. Deposits Filter
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
	HAVING SUM(DepositAmount) < 150000
	ORDER BY TotalSum DESC

--8.  Deposit Charge
SELECT DepositGroup, 
	MagicWandCreator, 
	MIN(DepositCharge) AS MinDepositCharge
	FROM WizzardDeposits
	GROUP BY DepositGroup, MagicWandCreator
	ORDER BY MagicWandCreator, DepositGroup

--9. Age Groups
SELECT AgeGroup, Count(AgeGroup)
	FROM
		(SELECT
		CASE 
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS AgeGroup
		FROM WizzardDeposits) AS SubQuery
	GROUP BY AgeGroup

--10. First Letter
SELECT LEFT(wd.FirstName, 1)  AS FirstLetter
	FROM WizzardDeposits AS wd
	WHERE wd.DepositGroup = 'Troll Chest'
	GROUP BY LEFT(wd.FirstName, 1)

--11. Average Interest 
SELECT wd.DepositGroup, wd.IsDepositExpired, AVG(wd.DepositInterest) AS [AverageInterest]
	FROM WizzardDeposits AS wd
	WHERE wd.DepositStartDate > '1985-01-01'
	GROUP BY wd.DepositGroup, wd.IsDepositExpired
	ORDER BY wd.DepositGroup DESC, wd.IsDepositExpired

--12. * Rich Wizard, Poor Wizard (1)
SELECT 
	(SELECT TOP(1) wd.DepositAmount 
	FROM WizzardDeposits AS wd) 
	- (SELECT TOP (1) wd.DepositAmount
	FROM WizzardDeposits AS wd
	ORDER BY wd.Id DESC)  AS [SumDifference]

--12. * Rich Wizard, Poor Wizard (2)
SELECT (t1.DepositAmount - t2.DepositAmount) AS [SumDifference]
	FROM WizzardDeposits t1 
	CROSS JOIN WizzardDeposits t2
	WHERE t1.Id = 1 AND t2.Id = (SELECT COUNT(*) FROM WizzardDeposits AS wd)

