CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Title NVARCHAR(30) NOT NULL,
	Notes NTEXT
)

CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	PhoneNumber BIGINT NOT NULL,
	EmergencyName NVARCHAR(50),
	EmergencyNumber BIGINT,
	Notes NTEXT
	)

CREATE TABLE RoomStatus(
	RoomStatus NVARCHAR(20) PRIMARY KEY,
	Notes NTEXT
	)

CREATE TABLE RoomTypes(
	RoomType NVARCHAR(20) PRIMARY KEY,
	Notes NTEXT
	)

CREATE TABLE BedTypes(
	BedType NVARCHAR(20) PRIMARY KEY,
	Notes NTEXT
	)

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY IDENTITY,
	RoomType NVARCHAR(20) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
	BedType NVARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
	Rate DECIMAL(5,2),
	RoomStatus NVARCHAR(20) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
	Notes NTEXT
	)

CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	FirstDateOccupied DATE, 
	LastDateOccupied DATE, 
	TotalDays INT, 
	AmountCharged DECIMAL(5,2),
	TaxRate DECIMAL(5,2), 
	TaxAmount DECIMAL(5,2), 
	PaymentTotal DECIMAL(5,2) NOT NULL, 
	Notes NTEXT
	)

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	DateOccupied DATE,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
	RateApplied DECIMAL(5,2),
	PhoneCharge DECIMAL(5,2),
	Notes NTEXT
	)

INSERT INTO Employees(FirstName, LastName, Title)
	VALUES 
	('Sasho', 'Petkov', 'Bellboy'),
	('Georgi', 'Ivanov', 'Рeceptionist'),
	('Emili', 'Todorova', 'Manager')

INSERT INTO Customers(FirstName, LastName, PhoneNumber)
	VALUES
	('Todor', 'Todorov', 883300),
	('Georgi', 'Georgiev', 883300),
	('Ivan', 'Ivanov', 883300)

INSERT INTO RoomStatus(RoomStatus)
	VALUES
	('Free'),
	('Occupied'),
	('Reserved')

INSERT INTO RoomTypes(RoomType)
	VALUES
	('Single'),
	('Double'),
	('Studio')

INSERT INTO BedTypes(BedType)
	VALUES
	('Standart'),
	('King Size'),
	('Two beds')

INSERT INTO Rooms(RoomType, BedType, Rate, RoomStatus)
	VALUES	
	('Single', 'Standart', 20, 'Free'),
	('Double', 'Two beds', 30, 'Free'),
	('Studio', 'King Size', 40, 'Occupied')

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, PaymentTotal)
	VALUES
	(1, '03.12.2020', 3, 100),
	(2, '05.12.2020', 1, 90),
	(3, '07.12.2020', 2, 160)

INSERT INTO Occupancies(EmployeeId, AccountNumber, RoomNumber)
	VALUES
	(1, 3, 1),
	(2, 1, 2),
	(3, 2, 3)