CREATE OR ALTER PROC Sp_GetEmployeesSalesById
    @id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT 1
    FROM EmployeesSales es
    WHERE es.Id = @id
END