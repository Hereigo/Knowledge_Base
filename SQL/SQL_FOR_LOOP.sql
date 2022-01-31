DECLARE @Counter INT 
SET @Counter=1
WHILE ( @Counter <= 48)
BEGIN
	DECLARE @SUM INT;
    SET @SUM = (SELECT sum(Amount) from Payments where CatogoryId = @Counter);

	IF(@SUM > 0)
		INSERT into PaysSummary (ID, CategoryId, Amount, LastUpdated)
    	VALUES (@Counter, @Counter, @SUM, GETDATE())
    ELSE
		PRINT 'nothing'
    
    SET @Counter  = @Counter  + 1;
END