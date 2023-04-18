CREATE OR ALTER PROC Sp_CheckIfUserExistsById
    @userId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT 1
    FROM Users u
    WHERE u.Id = @userId;
END