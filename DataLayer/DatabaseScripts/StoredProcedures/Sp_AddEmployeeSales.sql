CREATE OR ALTER PROC Sp_AddEmployeeSales
    @Id UNIQUEIDENTIFIER,
    @ProductId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @DateId INT,
    @ProductsSold INT
AS
BEGIN
    INSERT INTO EmployeesSales
        (Id, ProductId, UserId, DateId, ProductsSold)
    VALUES(@Id, @ProductId, @UserId, @DateId, @ProductsSold)
END