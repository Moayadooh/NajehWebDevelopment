CREATE PROCEDURE [dbo].[sp_AddCategory]
	@catname nvarchar(15),
	@description nvarchar(200)
AS
BEGIN
	insert into Production.Categories (categoryname,description)
	values(@catname,@description)
END

EXec dbo.sp_AddCategory @catname = 'testcat1', @description ='testdescription1' 

declare @v int;
EXec @v = dbo.sp_AddCategory -- value of @v will be 0
@catname='testcat4',
@description ='testdescription4' 
Select @v

select * from Production.Categories
