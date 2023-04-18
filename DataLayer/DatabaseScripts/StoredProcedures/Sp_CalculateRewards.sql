CREATE OR ALTER PROC Sp_CalculateRewards
    @dateId SMALLINT
AS
BEGIN
    SELECT u.id, u.firstName, u.lastName, p.id productId, p.Name productName, es.ProductsSold * pr.Reward AS RewardAmount
    FROM ((ProductRewards pr JOIN EmployeesSales es
        ON pr.productId = es.productId AND es.DateId = pr.DateId)
        JOIN Products p ON pr.ProductId = p.Id
        JOIN Users u ON es.userId = u.Id)
    WHERE pr.DateId = @dateId
    ORDER BY RewardAmount DESC, u.FirstName, u.LastName
END
