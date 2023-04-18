CREATE OR ALTER PROC Sp_AddProduct
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(256),
    @CreatedAt DATETIME2
AS
BEGIN

    INSERT INTO PRODUCTS
        (Id, Name, CreatedAt)
    VALUES(@Id, @Name, @CreatedAt);

END