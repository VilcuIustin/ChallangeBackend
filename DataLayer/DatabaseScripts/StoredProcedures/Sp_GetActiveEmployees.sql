CREATE OR ALTER PROC Sp_GetActiveEmployees
    @page int = 0,
    @size int = 10
AS
BEGIN
    SELECT Id, FirstName, LastName
    FROM Users
    WHERE DeletedAt IS NULL
    ORDER BY FirstName, LastName
OFFSET @page * @size ROWS FETCH NEXT @size ROWS ONLY
END