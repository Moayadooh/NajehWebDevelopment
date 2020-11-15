
CREATE FUNCTION fn_Getcatecogry() 

RETURNS int
AS
BEGIN
	
	-- Add the T-SQL statements to compute the return value here
	declare @v int = 0

	set @v  = (select count(*) from Production.Categories)

	-- Return the result of the function
	RETURN @v

END
GO

select dbo.fn_Getcatecogry()

