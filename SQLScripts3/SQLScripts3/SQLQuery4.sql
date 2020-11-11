select 1 + '2' as result
select 1 + '300' as result
select 1 + 'ammar' as result
--------------------------------------
select CAST(1 as varchar(10)) + 'ammar' as result
---------------------------------------------------
select CONCAT('ammar' ,' ','yaser') as fullname
----------------------------------------------------
select SYSDATETIME() as [now]
select cast(SYSDATETIME() as date) as  [current date]
------------------------------------------------------
select cast(SYSDATETIME() as date)

select convert(date,SYSDATETIME())
-------------------------------------------------------
-- 20 oct 2020
-- oct 20 2020
-- 20.10.2020
select convert(datetime, '20080809',102) as [birth date] -- ansi STYLE
select convert(CHAR(12), CURRENT_TIMESTAMP,111) as [birth date] -- ansi STYLE
------------------------------------------------------------------------------
--https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql?view=sql-server-ver15

select parse('11/24/2020' as smalldatetime using 'en-US') as nowdate
select parse('23/11/2020' as date using 'en-GB') as nowdate
----------------------------------------------------------------
select TRY_PARSE('ammar yaser' as datetime)
