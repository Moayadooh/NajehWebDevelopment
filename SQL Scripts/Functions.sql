
ISNUMERIC('1E3')
IIF(num > 50,'high','low') -- return high if more than 50, otherwise return low
CHOOSE(3,'Beverages','condiments','confections') -- return 'confections'

Declare
  @v1 as int = NULL,
  @v2 as int = 50,
  @v3 as int = 100

  select isnull(@v1 , @v3)
  select COALESCE(@v1 , @v2 , @v3)
  
NullIF(col1,col2) -- if both are equal return null else return col2 value