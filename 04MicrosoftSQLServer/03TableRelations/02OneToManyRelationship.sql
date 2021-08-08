CREATE TABLE Models(
	ModelID INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(50) NOT NULL,
	ManufacturerID INT NOT NULL
	)

CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	EstablishedOn DATE NOT NULL
	)

INSERT INTO Models([Name], ManufacturerID)
	VALUES
	('X1', 1),
	('I6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3)

INSERT INTO Manufacturers([Name], EstablishedOn)
	VALUES
	('BMW', '03/07/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '05/01/1966')

ALTER TABLE Models
ADD CONSTRAINT FK_Models_Manufacturers
FOREIGN KEY (ManufacturerID)
REFERENCES Manufacturers(ManufacturerID)