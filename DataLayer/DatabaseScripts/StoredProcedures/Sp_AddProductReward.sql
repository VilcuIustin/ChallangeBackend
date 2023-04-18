CREATE OR ALTER PROC Sp_AddProductReward
    @Id UNIQUEIDENTIFIER,
    @ProductId UNIQUEIDENTIFIER,
    @Reward INT,
    @DateId SMALLINT,
    @CreatedAt DATETIME2
AS
BEGIN
    INSERT INTO ProductRewards
        (Id, ProductId, Reward, DateId, CreatedAt)
    VALUES(@Id, @ProductId, @Reward, @DateId, @CreatedAt)
END