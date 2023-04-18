CREATE OR ALTER PROC Sp_GetEmployeesSalesByDate
    @employeeId UNIQUEIDENTIFIER,
    @dateId SMALLINT
AS
BEGIN
    SELECT es.Id, p.Name ProductName, es.ProductsSold
    FROM EmployeesSales es JOIN
        Products p ON es.ProductId = p.Id
    WHERE es.UserId = @employeeId AND dateId = @dateId
    ORDER BY ProductsSold, Name
END
