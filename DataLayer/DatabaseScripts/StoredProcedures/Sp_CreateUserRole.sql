CREATE OR ALTER PROC Sp_CreateUserRole
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @RoleId UNIQUEIDENTIFIER
AS
BEGIN
    INSERT INTO UserRoles
        (Id, UserId, RoleId)
    VALUES(@Id, @UserId, @RoleId);
END
