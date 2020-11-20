
-- Date & Time
GETDATE()
CURRENT_TIMESTAMP
GETUTCDATE()
SYSDATETIME()
SYSUTCDATETIME()
SYSDATETIMEOFFSET()

DATENAME(DAY,'20201111')
DATENAME(MONTH,'20201111')
DATENAME(YEAR,'20201111')
DAY('20201122')
MONTH('20201122')
YEAR('20201122')

DATETIMEFROMPARTS(2012,2,12,8,33,2,.2)
DATETIME2FROMPARTS(2012,2,12,8,33,7,1,3)
DATEFromparts(2012,12,8)

ISDATE('20190229') --return false
ISDATE('20190329') --return true

-- Different between dates
DATEDIFF(MONTH,'20181010', GETDATE())
DATEDIFF(MILLISECOND,GETDATE() ,SYSDATETIME())

-- Date after 3 months
DATEADD(MONTH,3,SYSDATETIME())
