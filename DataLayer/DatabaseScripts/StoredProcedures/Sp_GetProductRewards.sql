CREATE OR ALTER PROC Sp_GetProductRewards
    @productId UNIQUEIDENTIFIER,
    @startMonth TINYINT,
    @startYear SMALLINT,
    @endMonth TINYINT,
    @endYear SMALLINT
AS
BEGIN
    SELECT pr.Id, Month, Year, Reward
    FROM ProductRewards pr JOIN Dates d
        ON pr.DateId = d.Id
    WHERE pr.ProductId = @productId
        AND @startYear <= Year AND Year <= @endYear
        AND ((@startMonth <= Month AND @startYear = Year) OR
        (@endMonth >= Month AND @endYear = Year))
    ORDER BY Year, Month

END
