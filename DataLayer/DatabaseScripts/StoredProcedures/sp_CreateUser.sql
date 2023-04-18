CREATE OR ALTER PROC Sp_CreateUser
    @Id UNIQUEIDENTIFIER,
    @FirstName NVARCHAR(128),
    @LastName NVARCHAR(128),
    @Email NVARCHAR(320),
    @PasswordHash NVARCHAR(MAX),
    @CreatedAt DATETIME2
AS
BEGIN
    INSERT INTO Users
        (Id, FirstName, LastName, Email, PasswordHashed, CreatedAt)
    VALUES(@Id, @FirstName, @LastName, @Email, @PasswordHash, @CreatedAt);
END

