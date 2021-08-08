CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate DECIMAL(5, 2) NOT NULL,
	WeeklyRate DECIMAL(5, 2) NOT NULL,
	MontlyRate DECIMAL(5, 2) NOT NULL,
	WeekendRate DECIMAL(5, 2) NOT NULL
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MontlyRate, WeekendRate)
VALUES
	('Hatchback', 15, 80, 300, 30),
	('Minivan', 25, 120, 400, 50),
	('Coupe', 20, 100, 350, 40)

CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(10) NOT NULL,
	Manufacturer NVARCHAR(20) NOT NULL,
	Model NVARCHAR(20) NOT NULL,
	CarYear INT NOT NULL,
	CategotyId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Doors INT CHECK(DOORS = 4 OR DOORS = 5 OR DOORS = 2),
	Picture VARBINARY(MAX) CHECK(DATALENGTH(Picture) <= 2048 * 1024),
	Condition NVARCHAR(50),
	Available CHAR(1) CHECK(Available = 'y' OR Available = 'n') NOT NULL
)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategotyId, Available)
	VALUES
		('B2048TH', 'Toyota', 'Corola', 2007, 1, 'Y'),
		('CA4096CA', 'Dacia', 'Dokker', 2009, 2, 'Y'),
		('A1024B', 'Fiat', 'Coupe', 2011, 3, 'N')

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstsName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Title NVARCHAR(4), CHECK(Title = 'Miss' OR Title = 'Mrs.' OR Title = 'Ms.'),
	Notes NTEXT
)

INSERT INTO Employees(FirstsName, LastName)
	VALUES
	('Pesho', 'Peshev'),
	('Gosho', 'Goshev'),
	('Vanq', 'Tosheva')

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenNumber NVARCHAR(20),
	FullName NVARCHAR(30) NOT NULL,
	[Address] NVARCHAR(50),
	City NVARCHAR(20),
	ZIPCode INT,
	Note NTEXT,
)

INSERT INTO Customers(FullName)
	VALUES
	('Ivan Ivanov'),
	('Georgi Georgiev'),
	('Malin Todorov')


CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel DECIMAL(3, 1),
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied DECIMAL(5, 2),
	TaxRate DECIMAL(5, 2),
	OrderStatus NVARCHAR(10),
	Notes NTEXT,
)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, StartDate, EndDate, TotalDays)
	VALUES
	(1, 2, 3, '12.10.2020', '12.20.2020', 10),
	(2, 1, 1, '01.10.2021', '01.25.2021', 15),
	(3, 3, 2, '03.15.2021', '03.20.2021', 5)