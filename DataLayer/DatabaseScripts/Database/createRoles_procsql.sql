CREATE OR ALTER PROC CreateRoles
AS
BEGIN

	CREATE TABLE Roles
	(
		Id UNIQUEIDENTIFIER PRIMARY KEY,
		Name NVARCHAR(128) NOT NULL UNIQUE,
		DeletedAt DATETIME2,
		ModifiedAt DATETIME2,
		CreatedAt DATETIME2 NOT NULL
	)

END


