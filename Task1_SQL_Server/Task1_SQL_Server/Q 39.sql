
SELECT TABLE_NAME, TABLE_SCHEMA
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA LIKE '[c,d]%'