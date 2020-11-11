SELECT GETDATE() AS [getDATE],
CURRENT_TIMESTAMP AS [CURRENT TIMESTAMP],
GETUTCDATE() AS [utc],
SYSDATETIME() AS [SYS TIME],
SYSUTCDATETIME() AS [SYS UTC TIME],
SYSDATETIMEOFFSET() AS [SYS OFFSET TIME]
--------------------------------------------------------------
SELECT DATENAME(DAY,'20201111') AS [CURRENT DAY]
SELECT DATENAME(MONTH,'20201111') AS [CURRENT MONTH]
SELECT DATENAME(YEAR,'20201111') AS [CURRENT YEAR]
----------------------------------------------------------
SELECT DAY('20201122') AS [DAY]
SELECT mONTH('20201122') AS [MONTH]
-----------------------------------------------------
SELECT DATETIMEFROMPARTS(2012,2,12,8,33,2,.2) AS [date]
SELECT DATETIME2FROMPARTS(2012,2,12,8,33,7,1,3) AS [date]
SELECT DATEFromparts(2012,12,8) AS [date]
----------------------------------------------------------------
select DATEDIFF(MONTH,getdate(),'20201010')
select DATEDIFF(MONTH,'20201010', getdate())
select DATEDIFF(MILLISECOND,GETDATE() ,SYSDATETIME())
----------------------------------------------------------------
select ISDATE('20190229') -- false
select ISDATE('20190329') -- true
----------------------------------------------------------------





