CREATE OR ALTER PROC Sp_CheckIfProductRewardExistByNameAndDate
    @productId UNIQUEIDENTIFIER,
    @dateId SMALLINT
AS
BEGIN
    SELECT 1
    FROM ProductRewards pr
    WHERE pr.ProductId = @productId AND
        pr.DateId = @dateId
END