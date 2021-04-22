;
WITH unioned AS (
    SELECT
        1 AS isHistory,
        'TFH' AS source,
        Quality AS CommodityQuality,
        SubQuality AS CommoditySubQuality,
        HistoryId AS IdentityId,
        HistoryId,
        Id,
        ISNULL(IsProcessedAtprice, 0) AS IsProcessed,
        ISNULL(DeletedDate, ValidFrom) AS Date,
        Event,
        Status,
        SourceCountry,
        DestinationCountry,
        Month,
        Year,
        Value
    FROM
        dbo.TradeFlow_History
    UNION
    ALL
    SELECT
        0 AS isHistory,
        'TF' AS source,
        Quality AS CommodityQuality,
        SubQuality AS CommoditySubQuality,
        Id AS IdentityId,
        -1 AS HistoryId,
        Id,
        ISNULL(IsProcessedAtprice, 0) AS IsProcessed,
        UpdatedDate AS Date,
        'Update' AS Event,
        Status,
        SourceCountry,
        DestinationCountry,
        Month,
        Year,
        Value
    FROM
        dbo.TradeFlow 
    UNION
    ALL
    SELECT
        0 AS isHistory,
        'TF' AS source,
        Quality AS CommodityQuality,
        SubQuality AS CommoditySubQuality,
        Id AS IdentityId,
        -1 AS HistoryId,
        Id,
        ISNULL(IsProcessedAtprice, 0) AS IsProcessed,
        UpdatedDate AS Date,
        'Update' AS Event,
        Status,
        SourceCountry,
        DestinationCountry,
        Month,
        Year,
        Value
    FROM
        (
            SELECT
                SourceCountry,
                DestinationCountry,
                Month,
                Year,
                Commodity,
                Quality,
                SubQuality,
                Id,
                IsProcessedAtprice,
                UpdatedDate,
                Value,
                Status,
                ROW_NUMBER() OVER(
                    PARTITION BY SourceCountry,
                    DestinationCountry,
                    Month,
                    Year,
                    Commodity,
                    Quality,
                    SubQuality,
                    IsExporter
                    ORDER BY
                        Status DESC
                ) AS rn
            FROM
                dbo.TradeFlow
            WHERE
                Status = 2
                OR Status = 4
        ) t
    WHERE
        t.rn = 1
),
evented AS (
    SELECT
        u.isHistory,
        u.source,
        u.CommodityQuality,
        u.CommoditySubQuality,
        u.IdentityId,
        u.HistoryId,
        u.Id,
        u.IsProcessed,
        u.Date,
        u.Event,
        CASE
            WHEN u.Event = 'Delete' THEN 0
            ELSE 1
        END isDelete,
        u.Status,
        u.SourceCountry,
        u.DestinationCountry,
        u.Month,
        u.Year,
        u.Value
    FROM
        unioned AS u
)
SELECT
    TOP 20 source as 'Oldest.Unproc.Part',
    IdentityId,
    Date,
    isHistory,
    Status,
    Month,
    Year,
    SourceCountry,
    DestinationCountry,
    Value,
    HistoryId,
    CommoditySubQuality
FROM
    evented
WHERE
    Date IS NOT NULL
    AND IsProcessed = 0
    AND CommodityQuality = 1
ORDER BY
    Date,
    isHistory DESC,
    isDelete,
    HistoryId;

----  -- AP-EXpected PAIRS :
----------------------------------------------
----------------------------------------------					 
----------------------------------------------
;

WITH unioned AS (
    SELECT
        1 AS isHistory,
        'TFH' AS source,
        Quality AS CommodityQuality,
        SubQuality AS CommoditySubQuality,
        HistoryId AS IdentityId,
        HistoryId,
        Id,
        ISNULL(IsProcessedAtprice, 0) AS IsProcessed,
        ISNULL(DeletedDate, ValidFrom) AS Date,
        Event,
        Status,
        SourceCountry,
        DestinationCountry,
        Month,
        Year,
        Value,
        IsExporter
    FROM
        dbo.TradeFlow_History
    UNION
    ALL
    SELECT
        0 AS isHistory,
        'TF' AS source,
        Quality AS CommodityQuality,
        SubQuality AS CommoditySubQuality,
        Id AS IdentityId,
        -1 AS HistoryId,
        Id,
        ISNULL(IsProcessedAtprice, 0) AS IsProcessed,
        UpdatedDate AS Date,
        'Update' AS Event,
        Status,
        SourceCountry,
        DestinationCountry,
        Month,
        Year,
        Value,
        IsExporter
    FROM
        dbo.TradeFlow
    WHERE
        Status != 2
        OR (
            Status = 2
            AND NOT EXISTS(
                SELECT
                    *
                FROM
                    (
                        SELECT
                            0 AS isHistory,
                            'TF' AS source,
                            Quality AS CommodityQuality,
                            SubQuality AS CommoditySubQuality,
                            Id AS IdentityId,
                            -1 AS HistoryId,
                            Id,
                            ISNULL(IsProcessedAtprice, 0) AS IsProcessed,
                            UpdatedDate AS Date,
                            'Update' AS Event,
                            Status,
                            SourceCountry,
                            DestinationCountry,
                            Month,
                            Year,
                            Value,
                            IsExporter
                        FROM
                            dbo.TradeFlow
                        WHERE
                            Status = 2
                            AND IsProcessedAtprice <> 1 --AND SubQuality=1 AND Month=11 AND Year=2020 --AND (SourceCountry=207 OR DestinationCountry=207 OR SourceCountry=152 OR DestinationCountry=152)
                        UNION
                        ALL
                        SELECT
                            1 AS isHistory,
                            'TFH' AS source,
                            Quality AS CommodityQuality,
                            SubQuality AS CommoditySubQuality,
                            HistoryId AS IdentityId,
                            HistoryId,
                            Id,
                            ISNULL(IsProcessedAtprice, 0) AS IsProcessed,
                            ISNULL(DeletedDate, ValidFrom) AS Date,
                            Event,
                            Status,
                            SourceCountry,
                            DestinationCountry,
                            Month,
                            Year,
                            Value,
                            IsExporter
                        FROM
                            dbo.TradeFlow_History
                        WHERE
                            Status = 2
                            AND IsProcessedAtprice <> 1 --AND SubQuality=1 AND Month=11 AND Year=2020 --AND (SourceCountry=207 OR DestinationCountry=207 OR SourceCountry=152 OR DestinationCountry=152)
                    ) ex
                    INNER JOIN (
                        SELECT
                            0 AS isHistory,
                            'TF' AS source,
                            Quality AS CommodityQuality,
                            SubQuality AS CommoditySubQuality,
                            Id AS IdentityId,
                            -1 AS HistoryId,
                            Id,
                            ISNULL(IsProcessedAtprice, 0) AS IsProcessed,
                            UpdatedDate AS Date,
                            'Update' AS Event,
                            Status,
                            SourceCountry,
                            DestinationCountry,
                            Month,
                            Year,
                            Value,
                            IsExporter
                        FROM
                            dbo.TradeFlow
                        WHERE
                            Status = 4
                        UNION
                        ALL
                        SELECT
                            1 AS isHistory,
                            'TFH' AS source,
                            Quality AS CommodityQuality,
                            SubQuality AS CommoditySubQuality,
                            HistoryId AS IdentityId,
                            HistoryId,
                            Id,
                            ISNULL(IsProcessedAtprice, 0) AS IsProcessed,
                            ISNULL(DeletedDate, ValidFrom) AS Date,
                            Event,
                            Status,
                            SourceCountry,
                            DestinationCountry,
                            Month,
                            Year,
                            Value,
                            IsExporter
                        FROM
                            dbo.TradeFlow_History
                        WHERE
                            Status = 4 --AND SubQuality=1 AND Month=11 AND Year=2020 --AND (SourceCountry=207 OR DestinationCountry=207 OR SourceCountry=152 OR DestinationCountry=152)
                    ) ap ON ap.Month = ex.Month
                    AND ap.Year = ex.Year
                    AND ap.CommoditySubQuality = ex.CommoditySubQuality
                    AND (
                        (
                            ap.SourceCountry = ex.SourceCountry
                            AND ap.DestinationCountry = ex.DestinationCountry
                            AND ex.IsExporter = 1
                        )
                        OR (
                            ap.DestinationCountry = ex.SourceCountry
                            AND ap.SourceCountry = ex.DestinationCountry
                            AND ex.IsExporter = 0
                        )
                    ) -- WHERE Status!=2 AND Status!=4
                    --   UNION ALL
                    --   SELECT
                    --       0 AS isHistory,
                    --       'TF' AS source,
                    --       Quality AS CommodityQuality,
                    --       SubQuality AS CommoditySubQuality, 
                    --       Id AS IdentityId,
                    --       -1 AS HistoryId,
                    --       Id, 
                    --       ISNULL(IsProcessedAtprice,0) AS IsProcessed, 
                    --       UpdatedDate AS Date,
                    --       'Update' AS Event,
                    --       Status,
                    --       SourceCountry,
                    --       DestinationCountry,
                    --       Month,
                    --       Year,
                    -- Value
                    --   FROM (
                    --   SELECT SourceCountry,DestinationCountry,Month,Year,Commodity,Quality,SubQuality,Id,IsProcessedAtprice,UpdatedDate,Value,Status,
                    --   ROW_NUMBER() OVER(
                    --       PARTITION BY SourceCountry,DestinationCountry,Month,Year,Commodity,Quality,SubQuality,IsExporter ORDER BY Status DESC) AS rn
                    --   FROM dbo.TradeFlow WHERE Status=2 OR Status=4
                    -- ) t
                    -- WHERE t.rn=1 
            )
        )
),
evented AS (
    SELECT
        u.isHistory,
        u.source,
        u.CommodityQuality,
        u.CommoditySubQuality,
        u.IdentityId,
        u.HistoryId,
        u.Id,
        u.IsProcessed,
        u.Date,
        u.Event,
        CASE
            WHEN u.Event = 'Delete' THEN 0
            ELSE 1
        END isDelete,
        u.Status,
        u.SourceCountry,
        u.DestinationCountry,
        u.Month,
        u.Year,
        u.Value
    FROM
        unioned AS u
)
SELECT
    TOP 20 source as 'Oldest.Unproc.Part',
    IdentityId,
    Date,
    isHistory,
    Status,
    Month,
    Year,
    SourceCountry,
    DestinationCountry,
    Value,
    HistoryId,
    CommoditySubQuality
FROM
    evented
WHERE
    Date IS NOT NULL
    AND IsProcessed = 0
    AND CommodityQuality = 1
ORDER BY
    Date,
    isHistory DESC,
    isDelete,
    HistoryId;

--SELECT * FROM 
--(
--	SELECT 0 as H, SourceCountry, DestinationCountry, Status, IsExporter, Value, Month, Year, UpdatedDate as Date, SubQuality FROM TradeFlow tfe 
--	WHERE Status=2 AND IsProcessedAtprice<>1 --AND SubQuality=1 AND Month=11 AND Year=2020 --AND (SourceCountry=207 OR DestinationCountry=207 OR SourceCountry=152 OR DestinationCountry=152)
--	UNION ALL
--	SELECT 1 as H, SourceCountry, DestinationCountry, Status, IsExporter, Value, Month, Year, ValidFrom as Date, SubQuality FROM TradeFlow_History tfhe
--	WHERE Status=2 AND IsProcessedAtprice<>1 --AND SubQuality=1 AND Month=11 AND Year=2020 --AND (SourceCountry=207 OR DestinationCountry=207 OR SourceCountry=152 OR DestinationCountry=152)
--) ex
--INNER JOIN 
--(
--	SELECT 0 as H, SourceCountry, DestinationCountry, Status, IsExporter, Value, Month, Year, UpdatedDate as Date, SubQuality FROM TradeFlow tfa 
--	WHERE Status=4 --AND SubQuality=1 AND Month=11 AND Year=2020 --AND (SourceCountry=207 OR DestinationCountry=207 OR SourceCountry=152 OR DestinationCountry=152) --AND Value !=350
--	UNION ALL
--	SELECT 1 as H, SourceCountry, DestinationCountry, Status, IsExporter, Value, Month, Year, ValidFrom as Date, SubQuality FROM TradeFlow_History tfha 
--	WHERE Status=4 --AND SubQuality=1 AND Month=11 AND Year=2020 --AND (SourceCountry=207 OR DestinationCountry=207 OR SourceCountry=152 OR DestinationCountry=152)
--) ap
--ON ap.Month=ex.Month AND ap.Year=ex.Year AND ap.SubQuality=ex.SubQuality
--AND (
--(ap.SourceCountry=ex.SourceCountry AND ap.DestinationCountry=ex.DestinationCountry AND ex.IsExporter=1)
--OR 
--(ap.DestinationCountry=ex.SourceCountry AND ap.SourceCountry=ex.DestinationCountry AND ex.IsExporter=0)
--)
SELECT
    *
FROM
    (
        SELECT
            0 AS isHistory,
            'TF' AS source,
            Quality AS CommodityQuality,
            SubQuality AS CommoditySubQuality,
            Id AS IdentityId,
            -1 AS HistoryId,
            Id,
            ISNULL(IsProcessedAtprice, 0) AS IsProcessed,
            UpdatedDate AS Date,
            'Update' AS Event,
            Status,
            SourceCountry,
            DestinationCountry,
            Month,
            Year,
            Value,
            IsExporter
        FROM
            dbo.TradeFlow
        WHERE
            Status = 2
            AND IsProcessedAtprice <> 1 --AND SubQuality=1 AND Month=11 AND Year=2020 --AND (SourceCountry=207 OR DestinationCountry=207 OR SourceCountry=152 OR DestinationCountry=152)
        UNION
        ALL
        SELECT
            1 AS isHistory,
            'TFH' AS source,
            Quality AS CommodityQuality,
            SubQuality AS CommoditySubQuality,
            HistoryId AS IdentityId,
            HistoryId,
            Id,
            ISNULL(IsProcessedAtprice, 0) AS IsProcessed,
            ISNULL(DeletedDate, ValidFrom) AS Date,
            Event,
            Status,
            SourceCountry,
            DestinationCountry,
            Month,
            Year,
            Value,
            IsExporter
        FROM
            dbo.TradeFlow_History
        WHERE
            Status = 2
            AND IsProcessedAtprice <> 1 --AND SubQuality=1 AND Month=11 AND Year=2020 --AND (SourceCountry=207 OR DestinationCountry=207 OR SourceCountry=152 OR DestinationCountry=152)
    ) ex
    INNER JOIN (
        SELECT
            0 AS isHistory,
            'TF' AS source,
            Quality AS CommodityQuality,
            SubQuality AS CommoditySubQuality,
            Id AS IdentityId,
            -1 AS HistoryId,
            Id,
            ISNULL(IsProcessedAtprice, 0) AS IsProcessed,
            UpdatedDate AS Date,
            'Update' AS Event,
            Status,
            SourceCountry,
            DestinationCountry,
            Month,
            Year,
            Value,
            IsExporter
        FROM
            dbo.TradeFlow
        WHERE
            Status = 4
        UNION
        ALL
        SELECT
            1 AS isHistory,
            'TFH' AS source,
            Quality AS CommodityQuality,
            SubQuality AS CommoditySubQuality,
            HistoryId AS IdentityId,
            HistoryId,
            Id,
            ISNULL(IsProcessedAtprice, 0) AS IsProcessed,
            ISNULL(DeletedDate, ValidFrom) AS Date,
            Event,
            Status,
            SourceCountry,
            DestinationCountry,
            Month,
            Year,
            Value,
            IsExporter
        FROM
            dbo.TradeFlow_History
        WHERE
            Status = 4 --AND SubQuality=1 AND Month=11 AND Year=2020 --AND (SourceCountry=207 OR DestinationCountry=207 OR SourceCountry=152 OR DestinationCountry=152)
    ) ap ON ap.Month = ex.Month
    AND ap.Year = ex.Year
    AND ap.CommoditySubQuality = ex.CommoditySubQuality
    AND (
        (
            ap.SourceCountry = ex.SourceCountry
            AND ap.DestinationCountry = ex.DestinationCountry
            AND ex.IsExporter = 1
        )
        OR (
            ap.DestinationCountry = ex.SourceCountry
            AND ap.SourceCountry = ex.DestinationCountry
            AND ex.IsExporter = 0
        )
    )