CREATE OR ALTER PROC Sp_GetDateIdByMonthAndYear
    @month TINYINT,
    @year SMALLINT
AS
BEGIN
    SELECT d.Id
    FROM Dates d
    WHERE d.Month = @month AND d.Year = @year

END