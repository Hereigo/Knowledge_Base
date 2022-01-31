-- Create Function :
CREATE FUNCTION dbo.fnMyFunction(@DateParam datetime,@CharParam char(1))
RETURNS INT
AS BEGIN
	DECLARE @Result INT
    -- Some Logic here...
	RETURN @Result
END

-- Call Function :
DECLARE @Rez int;
EXEC @Rez = dbo.fnMyFunction
 	@DateParam = '2022.12.31',
 	@CharParam = 'A'
PRINT @Rez
