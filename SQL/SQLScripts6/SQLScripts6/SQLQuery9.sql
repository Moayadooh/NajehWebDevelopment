Declare @sqlstatment nvarchar(1000);
set @sqlstatment = 'select * from hr.employees'
EXEC(@sqlstatment)
----------------------------------------------------------------------
Declare @sqlcode  nvarchar(1000);
set @sqlcode = 'select Getdate() as dateofbirth'
EXEC sys.sp_executesql @sqlcode 
----------------------------------------------------------------------
declare @sqlstring as nvarchar(1000);
declare @empid int;
set @sqlstring = N'select * from hr.employees where empid = @empid'
--set @sqlstring  = 'select * from hr.employees where empid' + @empid
Exec sys.sp_executesql 
			@statement = @sqlstring,
			@params = N'@empid as int',
			@empid = 5
			