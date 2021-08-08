USE Minions

CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
VALUES
	('Pesho0', '123456', '05.19.2020', 0),
	('Pesho1', '123456', '05.19.2020', 1),
	('Pesho2', '123456', '05.19.2020', 0),
	('Pesho3', '123456', '05.19.2020', 0),
	('Pesho4', '123456', '05.19.2020', 1)

	ALTER TABLE Users
	DROP CONSTRAINT [PK__Users__3214EC07755FD618]

	ALTER TABLE Users
	ADD CONSTRAINT PK_Users_CompositeIdUsername
	PRIMARY KEY(Id, Username)

	ALTER TABLE Users
	ADD CONSTRAINT CK_Users_PasswordLength
	CHECK(LEN([Password]) >= 5)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
VALUES
	('Pesho10', '124356', '05.19.2020', 0)

ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime 

INSERT INTO Users(Username, [Password], IsDeleted)
VALUES
	('PeshoNoTime', '124356', 0)

ALTER TABLE Users
DROP CONSTRAINT PK_Users_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_UsernameLength
CHECK(LEN(Username) >= 3)