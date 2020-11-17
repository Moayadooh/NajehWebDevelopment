set statistics time on
set statistics time off
select * from [TSQL].[Sales].[OrderDetails]
-------------------------------------------------------------
select name, value, value_in_use, description
from sys.configurations
order by name
-------------------------------------------------------------
select name,
database_id,
create_date,
collation_name,
user_access,
user_access_desc,
state,
state_desc
from sys.databases
-------------------------------------------------------------
select session_id,
login_time,
host_name,
program_name,
login_name,
status,
cpu_time,
memory_usage,
last_request_start_time,
last_request_end_time,
reads,
writes,
logical_reads,
is_user_process,
language,
date_format,
row_count
from sys.dm_exec_sessions
where program_name is not null;
-------------------------------------------------------------
select s.name as schemaname,
t.name as tablename,
t.object_id,
type_desc,
create_date
from sys.tables as t
join sys.schemas as s
on t.schema_id = s.schema_id
order by schemaname, tablename
