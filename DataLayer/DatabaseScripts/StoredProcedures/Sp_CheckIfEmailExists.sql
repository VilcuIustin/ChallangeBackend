CREATE OR ALTER PROC Sp_CheckIfEmailExists
    @email NVARCHAR(320)
AS
BEGIN
    SELECT COALESCE((SELECT 1 FROM Users u WHERE u.Email = @email), 0) as UserExists
END
