CREATE OR ALTER PROC Sp_ProductRewardsExistsById
  @id UNIQUEIDENTIFIER
AS
BEGIN
  SELECT 1
  FROM ProductRewards pr
  WHERE pr.id = @id
END

