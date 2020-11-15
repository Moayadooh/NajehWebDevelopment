
create FUNCTION fn_Getloginuser(@companyname nvarchar(50) ,@contactname nvarchar(50))
RETURNS int -- Scalar-valued Functions
AS
BEGIN
	-- Declare the return variable here
	DECLARE @result int  = 0

	-- Add the T-SQL statements to compute the return value here
	set @result  =  (select count(*) from Sales.Customers 
	where companyname=@companyname and contactname=@contactname)

	-- Return the result of the function
	RETURN @Result
END
GO

select dbo.fn_Getloginuser('Customer KBUDE', 'Peoples, John');
