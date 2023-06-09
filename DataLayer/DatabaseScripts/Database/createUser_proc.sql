CREATE OR ALTER PROC CreateUsersTable
AS
BEGIN
	CREATE TABLE Users
	(
		Id UNIQUEIDENTIFIER PRIMARY KEY,
		FirstName NVARCHAR(128) NOT NULL,
		LastName NVARCHAR(128) NOT NULL,
		Email NVARCHAR(320) UNIQUE NOT NULL ,
		PasswordHashed NVARCHAR(MAX),
		DeletedAt DATETIME2,
		ModifiedAt DATETIME2,
		CreatedAt DATETIME2 NOT NULL
	)

END

--ALTER TABLE Users
--ALTER COLUMN PasswordHashed NVARCHAR(MAX)