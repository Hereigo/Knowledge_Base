# EXAMPLES :
```sql

---- DATE-TIME FORMAT BY CONVERT :

PRINT CONVERT(datetime, CONVERT (varchar(10), GETDATE(), 105), 105);
-- >> Feb 17 2022 12:00AM

---- FIND FUNCTION OR PROCEDURE :

DECLARE @SEARCH_PATTERN varchar(50) = '%' + 'User' + '%'; -- (for example)
SELECT TOP 10 * FROM information_schema.tables WHERE table_name LIKE @SEARCH_PATTERN;
SELECT TOP 10 last_altered, routine_schema, routine_type, routine_name, *
    FROM information_schema.routines WHERE routine_name LIKE @SEARCH_PATTERN;

---- TO SEE THE BODY OF SELECTED FUNCTION OR PROCEDURE :

DECLARE @SEARCH_PATTERN varchar(50) = '%' + 'User' + '%'; -- (for example)
DECLARE @x varchar(max);
SET @x = (SELECT TOP 1 routine_definition
	FROM information_schema.routines
	WHERE routine_name LIKE @SEARCH_PATTERN);
PRINT @x;

---- FIND BY NAME WHERE COLUMN EXISTS :
DECLARE @SEARCH_PATTERN varchar(50) = '%' + 'User' + '%'; -- (for example)
SELECT column_name, table_name
FROM information_schema.columns
WHERE column_name LIKE @SEARCH_PATTERN;

```
