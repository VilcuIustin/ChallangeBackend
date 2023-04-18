CREATE OR ALTER PROC Sp_GetRoleIdByName
    @name NVARCHAR(128)
AS
BEGIN
    SELECT Id
    FROM Roles r
    WHERE r.Name = name;
END