-- 10 information
-- 11 - 19 fatal error but user can fix it
-- 20 - 25 from server as shut down server
sp_addmessage 50003,10, N'%s %d %s' -- string digit string
sp_addmessage 50004,18, N'%s %d %s' 
raiserror(50004,18,1,'Error number',123,'your action needed')
-----------------------------------------------------------------------
begin try
select 1/0
end try

begin catch
select ERROR_NUMBER() as errornumber,
	   ERROR_SEVERITY() as errorseverity,
	   ERROR_STATE() as errorstate,
	   ERROR_PROCEDURE() as errorproc,
	   ERROR_MESSAGE() as errormsg
end catch
GO
-------------------------------------------------------------------------
declare @num varchar(20) = '0'
begin try
print 5 / cast(@num as numeric(4,2))
end try
begin catch
print 'error number:' + cast(error_number() as varchar(10))
print 'error message:' + error_message()
end catch
