CREATE OR ALTER PROC Sp_UpdateProductReward
    @id UNIQUEIDENTIFIER,
    @reward INT
AS
BEGIN
    UPDATE ProductRewards
    SET reward = @reward
    WHERE id = @id

END