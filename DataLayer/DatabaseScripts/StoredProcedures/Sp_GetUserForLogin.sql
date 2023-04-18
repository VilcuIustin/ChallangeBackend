
CREATE OR ALTER PROC Sp_GetUserForLogin
    @email NVARCHAR(320)
AS
BEGIN
    SELECT u.Id, u.Email, u.PasswordHashed Password, r.Id RoleId, r.Name RoleName
    FROM Users u JOIN UserRoles ur ON u.Id = ur.UserId
        JOIN Roles r ON ur.RoleId = r.Id
    WHERE u.Email = @email
END