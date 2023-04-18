CREATE OR ALTER PROC Sp_UpdateEmployeesSales
    @Id UNIQUEIDENTIFIER,
    @ProductsSold INT
AS
BEGIN
    UPDATE EmployeesSales
    SET ProductsSold = @ProductsSold
    WHERE Id = @Id
END