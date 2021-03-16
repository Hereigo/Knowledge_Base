-- @ TABLE VARIABLE
-- lives inside the running scope or until 'GO'
DECLARE @MyTableVar TABLE (Id int,...) 
GO


-- # LOCAL TEMP TABLE  ( ## GLOBAL TEMP TABLE )
-- lives until user that created is connected
-- (nevertheless, it is recommended to drop them manually)
CREATE TABLE #LocalTempTable ( id int,  ... )
-- or
SELECT
    Aaa,
    Bbb INTO #LocalTempTable 
FROM
    (
        SELECT
            Aaa,
            Bbb
    )


-- CTE - Common Table Expression
-- Define CTE name and columns :
;WITH Commodity_CTE (id, Price, UpdatedAt) AS 
-- Define CTE query :
(
    SELECT
        c.Id,
        c.Price,
        GETDATE() UpdatedAt
    FROM
        Commodities c
        LEFT JOIN Prices ps ON p.CommodityId == ps.Id
) 
-- Define the outer query referencing to CTE name :
SELECT
    *
FROM
    Commodity_CTE