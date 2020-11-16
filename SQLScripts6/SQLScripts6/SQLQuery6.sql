CREATE PROCEDURE [dbo].[sp_crudCategory]
	@catname nvarchar(20) = null, --set default value to null
	@desc nvarchar(20) = null,
	@action nvarchar(20) = null,
	@catid int = null
AS
BEGIN
if (@action = 'select')
begin
select * from Production.Categories
end

if (@action = 'insert')
begin
insert into Production.Categories values(@catname,@desc)
end

if (@action = 'update')
begin
update Production.Categories set categoryname=@catname, description=@desc
where categoryid=@catid
end

if (@action = 'delete')
begin
delete from Production.Categories where categoryid=@catid
end

if (@action = 'byone')
begin
select * from Production.Categories where categoryid=@catid
end
END
