CREATE OR ALTER PROC CreateDatabase
AS
BEGIN
	DROP TABLE IF EXISTS UserRoles;
	DROP TABLE IF EXISTS Roles;
	DROP TABLE IF EXISTS EmployeesSales;
	DROP TABLE IF EXISTS ProductRewards;
	DROP TABLE IF EXISTS Products;
	DROP TABLE IF EXISTS Dates;
	DROP TABLE IF EXISTS Users;
	exec CreateUsersTable;
	exec CreateRoles;
	exec CreateUserRolesTabel;
	exec CreateDateTable;
	exec CreateProductsTable;
	exec CreateProductRewardTable;
	exec CreateEmployeesSales;

	
DECLARE @managerRoleId UNIQUEIDENTIFIER;
SET @managerRoleId = NEWID();

INSERT INTO ROLES
	(Id, Name, CreatedAt)
VALUES( NEWID(), 'Employee', GETUTCDATE());
INSERT INTO ROLES
	(Id, Name, CreatedAt)
VALUES( @managerRoleId, 'Manager', GETUTCDATE());
INSERT INTO ROLES
	(Id, Name, CreatedAt)
VALUES( NEWID(), 'Admin', GETUTCDATE());


DECLARE @userId UNIQUEIDENTIFIER;
SET @userId = NEWID();


INSERT INTO Users
	(Id, FirstName, LastName, Email, PasswordHashed, CreatedAt)
VALUES(@userId, 'Test', 'Manager', 'manager@mailinator.com',
		'$2a$11$8bnfPq09SFVnNFWnCW.3EeIjyRZYJuVLhQNYAwnLapIDDwewHu3N2', GETUTCDATE())

INSERT INTO UserRoles
	(Id, UserId, RoleId)
VALUES
	(NEWID(), @userId, @managerRoleId);

	DECLARE @n INT = 100;
	DECLARE @i INT = 0;

	DECLARE @startDate DATETIME2 = '01-01-2020';

	WHILE @i < @n
BEGIN
		INSERT INTO Dates
			(Id, Month, Year)
		VALUES(@i+1, MONTH(@startDate), YEAR(@startDate))
		SET @startDate = DATEADD(MONTH, 1, @startDate)
		SET @i = @i + 1;
	END
END