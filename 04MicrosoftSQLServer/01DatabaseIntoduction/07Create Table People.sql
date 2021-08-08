USE Minions

CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) CHECK(DATALENGTH(Picture) <= 2048 * 1024),
	Height DECIMAL(5, 2),
	[Weight] DECIMAL(5, 2),
	Gender CHAR(1) CHECK(Gender = 'm' OR Gender = 'f' ) NOT NULL,
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name], Gender, Birthdate)
	VALUES
		('Pesho', 'm', '05.28.2000'),
		('Mariq', 'f', '10.12.1980'),
		('Petq', 'f', '01.10.1990'),
		('Tosho', 'm', '05.28.2001'),
		('Vasko', 'm', '12.28.2000')

SELECT * FROM PEOPLE