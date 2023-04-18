CREATE OR ALTER PROC Sp_GetProductsPaginated
    @name NVARCHAR(256) = NULL,
    @page INT = 0,
    @size INT = 10
AS
BEGIN
    SELECT p.Id, p.Name
    FROM Products p
    WHERE (@name IS NULL) OR (p.Name LIKE '%'+@name+'%')
    ORDER BY p.Name
    OFFSET @page * @size ROWS FETCH NEXT @size ROWS ONLY
END
