CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NTEXT
)

INSERT INTO Directors(DirectorName)
VALUES
	('CHRISTOPHER NOLAN'),
	('PETER JACKSON'),
	('DAVID FINCHER'),
	('QUENTIN TARANTINO'),
	('JAMES CAMERON')

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NTEXT
)

INSERT INTO Genres(GenreName)
VALUES
	('Action'),
	('Science fiction '),
	('Adventure'),
	('Drama'),
	('Thriller')

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NTEXT
)

INSERT INTO Categories(CategoryName)
VALUES
	('Movie'),
	('TV series'),
	('Movie-short'),
	('Independent film'),
	('Black&White')

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear INT,
	[Length] INT,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating DECIMAL(2,1),
	Notes NTEXT
)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, GenreId, CategoryId)
VALUES
	('The Dark Knight', 1, 2005, 1, 1),
	('The Lord of the Rings', 2, 2001, 3, 1),
	('Fight Club', 3, 1995, 5, 1),
	('Pulp Fiction', 4, 1993, 4, 1),
	('Avatar', 5, 2009, 2, 1)

SELECT * FROM Movies