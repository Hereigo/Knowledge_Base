SELECT
    c.Commodity,
    ps.MaxPrice,
    ps.MinPrice
FROM
    Commodities c
    CROSS APPLY (
        SELECT
            MAX(Price) MaxPrice,
            MIN(Price) MinPrice
        FROM
            Prices p
        WHERE
            p.CommodityId = c.Id
    ) ps