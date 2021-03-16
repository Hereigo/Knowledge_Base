
;WITH My_CommonTableExpression_Countries 
	(Country_ID, Country, Country_Code) 
	AS (
		SELECT
			TOP (300) [id],[Name],[Code]
		FROM
			[SomeProjectDatabase].[dbo].[Country]
	)
SELECT
	*
FROM
	My_CommonTableExpression_Countries