CREATE OR ALTER PROC Sp_CheckIfProductExistByName
    @Name NVARCHAR(256)
AS
BEGIN

    SELECT 1
    FROM Products p
    WHERE p.Name = @Name

END