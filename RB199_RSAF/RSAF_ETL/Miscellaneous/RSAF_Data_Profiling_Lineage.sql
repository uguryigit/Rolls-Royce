--+is nullable
--is identity key
--+is unique key
--+is computed
--+actual data type
--+is flag (true/false)
--+is reference key
--+is enumeration
--+Value interval (min,max)
--+Enumeration values
--+is binding with a in-use reports and frquency of usage
go
select b.name as table_name, 
       a.name as column_name,
	   a.column_id,
	   c.name as datatype,
	   c.max_length,
	   c.precision,
	   c.scale
  from sys.all_columns a
  join sys.tables b
    on a.object_id = b.object_id
  join sys.types c
    on a.user_type_id = c.user_type_id
order by b.name,a.column_id;
go
--Table record numbers
use [rsaf_dev]
go

select 'select ''rsaf_dev'' as DbName,''['+name+']'' as TableName,count(*) as RecordCount from dbo.['+name+']' 
from sys.tables 
order by name
go
delete [RSAF_Staging].[dbo].[DP_Table_RowCount]
go
insert into [RSAF_Staging].[dbo].[DP_Table_RowCount](DbName,TableName,RecordCount)
select 'rsaf_dev' as DbName,'[module TRT --2]' as TableName,count(*) as RecordCount from dbo.[module TRT --2]
union all
select 'rsaf_dev' as DbName,'[Paste Errors]' as TableName,count(*) as RecordCount from dbo.[Paste Errors]
union all
select 'rsaf_dev' as DbName,'[tblTableList]' as TableName,count(*) as RecordCount from dbo.[tblTableList]
go

use [RSAF2]
go

select 'select ''RSAF2'' as DbName,''['+name+']'' as TableName,count(*) as RecordCount from dbo.['+name+']' 
from sys.tables 
order by name
go

insert into [RSAF_Staging].[dbo].[DP_Table_RowCount](DbName,TableName,RecordCount)
select 'RSAF2' as DbName,'[Conversion Errors]' as TableName,count(*) as RecordCount from dbo.[Conversion Errors]
union all
select 'RSAF2' as DbName,'[CTRT_LOOKUP_TABLE]' as TableName,count(*) as RecordCount from dbo.[CTRT_LOOKUP_TABLE]
union all
select 'RSAF2' as DbName,'[LUCAS TRT]' as TableName,count(*) as RecordCount from dbo.[LUCAS TRT]
union all
select 'RSAF2' as DbName,'[module TRT]' as TableName,count(*) as RecordCount from dbo.[module TRT]
union all
select 'RSAF2' as DbName,'[REPAIR QUOTES]' as TableName,count(*) as RecordCount from dbo.[REPAIR QUOTES]
union all
select 'RSAF2' as DbName,'[REPAIR QUOTES 30 DAYS]' as TableName,count(*) as RecordCount from dbo.[REPAIR QUOTES 30 DAYS]
union all
select 'RSAF2' as DbName,'[R-S-A-F REPAIRABLE LISTING (ISSUE 4)]' as TableName,count(*) as RecordCount from dbo.[R-S-A-F REPAIRABLE LISTING (ISSUE 4)]
union all
select 'RSAF2' as DbName,'[RSAF TABLE]' as TableName,count(*) as RecordCount from dbo.[RSAF TABLE]
union all
select 'RSAF2' as DbName,'[SITE CODES]' as TableName,count(*) as RecordCount from dbo.[SITE CODES]
union all
select 'RSAF2' as DbName,'[TOTLUCASTRT]' as TableName,count(*) as RecordCount from dbo.[TOTLUCASTRT]
union all
select 'RSAF2' as DbName,'[totmodtrt]' as TableName,count(*) as RecordCount from dbo.[totmodtrt]
union all
select 'RSAF2' as DbName,'[TRANSIENT]' as TableName,count(*) as RecordCount from dbo.[TRANSIENT]
union all
select 'RSAF2' as DbName,'[TRT CALCULATIONS]' as TableName,count(*) as RecordCount from dbo.[TRT CALCULATIONS]
go

use RSAF2
go
delete RSAF_Staging.dbo.DP_RSAF2;
insert into RSAF_Staging.dbo.DP_RSAF2(
  table_id,
  column_id,
  table_name,
  column_name,
  data_type)
select b.object_id as table_id,
	   a.column_id,
       b.name as table_name, 
       a.name as column_name,
	   case when c.name in('bigint','int','smallint','datetime','datetime2','ntext') then
	     c.name
		 else
		   case when c.name in ('decimal') then
		     c.name + '('+cast(a.precision as varchar(20))+','+cast(a.scale as varchar(20))+')'
           else
		     c.name+ '('+cast(a.max_length as varchar(20))+')'
		   end
		end as data_type
  from sys.all_columns a
  join sys.tables b
    on a.object_id = b.object_id
  join sys.types c
    on a.user_type_id = c.user_type_id
order by b.name,a.column_id;
go
use rsaf_dev
go
delete RSAF_Staging.dbo.DP_rsaf_dev;
insert into RSAF_Staging.dbo.DP_rsaf_dev(
  table_id,
  column_id,
  table_name,
  column_name,
  data_type)
select b.object_id as table_id,
	   a.column_id,
       b.name as table_name, 
       a.name as column_name,
	   case when c.name in('bigint','int','smallint','datetime','datetime2','ntext') then
	     c.name
		 else
		   case when c.name in ('decimal') then
		     c.name + '('+cast(a.precision as varchar(20))+','+cast(a.scale as varchar(20))+')'
           else
		     c.name+ '('+cast(a.max_length as varchar(20))+')'
		   end
		end as data_type
  from sys.all_columns a
  join sys.tables b
    on a.object_id = b.object_id
  join sys.types c
    on a.user_type_id = c.user_type_id
order by b.name,a.column_id;
go

update RSAF_Staging.dbo.DP_RSAF2
set 
is_nullable=0,
is_unique=0,
is_enum=0,
is_flag=0,
is_reference=0;
go

update RSAF_Staging.dbo.DP_rsaf_dev
set 
is_nullable=0,
is_unique=0,
is_enum=0,
is_flag=0,
is_reference=0;
go
--N/A min/max value for character based 
use RSAF2
go
update RSAF_Staging.dbo.DP_RSAF2
set min_value=0,
    max_value=-1
where (cast(table_id as nvarchar)+'-'+cast(column_id as nvarchar)) in 
(select cast(b.object_id as nvarchar)+'-'+cast(a.column_id as nvarchar)
  from sys.all_columns a
  join sys.tables b
    on a.object_id = b.object_id
 where a.user_type_id in(34,35,99,129,130,167,173,175,231,239,241));
go

use rsaf_dev
go
update RSAF_Staging.dbo.DP_rsaf_dev
set min_value=0,
    max_value=-1
where (cast(table_id as nvarchar)+'-'+cast(column_id as nvarchar)) in 
(select cast(b.object_id as nvarchar)+'-'+cast(a.column_id as nvarchar)
  from sys.all_columns a
  join sys.tables b
    on a.object_id = b.object_id
 where a.user_type_id in(34,35,99,129,130,167,173,175,231,239,241));
go
--N/A Enumaration
use RSAF2
go
update RSAF_Staging.dbo.DP_RSAF2
set is_enum=-1
where (cast(table_id as nvarchar)+'-'+cast(column_id as nvarchar)) in 
(select cast(b.object_id as nvarchar)+'-'+cast(a.column_id as nvarchar)
  from sys.all_columns a
  join sys.tables b
    on a.object_id = b.object_id
 where a.user_type_id in(34,35,40,41,42,43,58,60,61,62,106,122,128,129,130,165,173,189,241));
go

use rsaf_dev
go

update RSAF_Staging.dbo.DP_rsaf_dev
set is_enum=-1
where (cast(table_id as nvarchar)+'-'+cast(column_id as nvarchar)) in 
(select cast(b.object_id as nvarchar)+'-'+cast(a.column_id as nvarchar)
  from sys.all_columns a
  join sys.tables b
    on a.object_id = b.object_id
 where a.user_type_id in(34,35,40,41,42,43,58,60,61,62,106,122,128,129,130,165,173,189,241));

--Enumarated columns
update RSAF_Staging.dbo.DP_RSAF2
set is_enum=1
where (cast(table_id as nvarchar)+'-'+cast(column_id as nvarchar)) in 
(select cast(table_id as nvarchar)+'-'+cast(column_id as nvarchar)
   from RSAF_Staging.dbo.DP_RSAF2
  where is_enum <> -1
    and (
	       (table_name='Conversion Errors' and column_id in (1)) OR
		   (table_name='CTRT_LOOKUP_TABLE' and column_id in (3)) OR
		   (table_name='LUCAS TRT' and column_id in (20,21)) OR
		   (table_name='R-S-A-F REPAIRABLE LISTING (ISSUE 4)' and column_id in (3,4,6,7)) OR
		   (table_name='RSAF TABLE' and column_id in (34,47))
		)
);
go

update RSAF_Staging.dbo.DP_rsaf_dev
set is_enum=1
where (cast(table_id as nvarchar)+'-'+cast(column_id as nvarchar)) in 
(select cast(table_id as nvarchar)+'-'+cast(column_id as nvarchar)
   from RSAF_Staging.dbo.DP_rsaf_dev
  where is_enum <> -1
    and (
	       (table_name='tblTableList' and column_id in (2))
		)
);
go

--Reference columns
update RSAF_Staging.dbo.DP_RSAF2
set is_reference=1
where (cast(table_id as nvarchar)+'-'+cast(column_id as nvarchar)) in 
(select cast(table_id as nvarchar)+'-'+cast(column_id as nvarchar)
   from RSAF_Staging.dbo.DP_RSAF2
  where (
		   (table_name='RSAF TABLE' and column_id in (12)) OR
		   (table_name='TRANSIENT' and column_id in (6))
		)
);
goo

update RSAF_Staging.dbo.DP_rsaf_dev
set is_reference=1
where (cast(table_id as nvarchar)+'-'+cast(column_id as nvarchar)) in 
(select cast(table_id as nvarchar)+'-'+cast(column_id as nvarchar)
   from RSAF_Staging.dbo.DP_rsaf_dev
  where (
		   (table_name='tblTableList' and column_id in (1)) 
		)
);
go

--Flag columns
update RSAF_Staging.dbo.DP_RSAF2
set is_flag=1
where (cast(table_id as nvarchar)+'-'+cast(column_id as nvarchar)) in 
(select cast(table_id as nvarchar)+'-'+cast(column_id as nvarchar)
   from RSAF_Staging.dbo.DP_RSAF2
  where (
		   (table_name='RSAF TABLE' and column_id in (8,37,40,45)) OR
		   (table_name='TRANSIENT' and column_id in (1,2,3,4,5))
		)
);
go

use RSAF2
go
exec find_null_uniq;
go
exec find_min_max_val;
go
exec find_enum_list;
go

use rsaf_dev
go
exec find_null_uniq;
go
exec find_min_max_val;
go
exec find_enum_list;
go
--------

use RSAF_Staging
GO

DELETE [DP_Description];
GO

bulk insert [DP_Description]
from 'C:\Users\uyigit.admin\source\repos\RB199_RSAF\RSAF_ETL\Miscellaneous\DescriptionQualification.csv'
with
(
firstrow=1,
fieldterminator=';',
rowterminator='\n'
);
GO



use RSAF_Staging
GO

DELETE DP_All_Queries;
GO

bulk insert DP_All_Queries
from 'C:\Users\uyigit.admin\source\repos\RB199_RSAF\RSAF_ETL\Miscellaneous\All_rsaf_dev_Queries.csv'
with
(
firstrow=1,
fieldterminator=';',
rowterminator='\n'
);
GO

bulk insert DP_All_Queries
from 'C:\Users\uyigit.admin\source\repos\RB199_RSAF\RSAF_ETL\Miscellaneous\All_RSAF2_Queries.csv'
with
(
firstrow=1,
fieldterminator=';',
rowterminator='\n'
);
GO

Alter table DP_All_Queries add SQLRecordCount int;
GO

use rsaf_dev
go

exec find_record_count;
go

use RSAF2
go

exec find_record_count;
go

--Compare to record counts between Access queries and SQL views
select * from RSAF_Staging.dbo.DP_All_Queries where state='R' and RecordCount<>SQLRecordCount and dbname='rsaf_dev' 
go
--Duplicate queries in boths DBs
select a.QueryName,a.State,
a.RecordCount as [rsaf_dev RecordNumber],
b.RecordCount as [RSAF2 RecordNumber]
from RSAF_Staging.dbo.DP_All_Queries a
join ( select *
from RSAF_Staging.dbo.DP_All_Queries
where DbName='RSAF2') b
on a.QueryName = b.QueryName
where a.DbName='rsaf_dev'

--rsaf_dev non duplicate queries
with duplicate_queries as
(
select a.QueryName,a.State,
a.RecordCount as [rsaf_dev RecordNumber],
b.RecordCount as [RSAF2 RecordNumber]
from RSAF_Staging.dbo.DP_All_Queries a
join ( select *
from RSAF_Staging.dbo.DP_All_Queries
where DbName='RSAF2') b
on a.QueryName = b.QueryName
where a.DbName='rsaf_dev')
select a.QueryName,a.State,a.RecordCount
from RSAF_Staging.dbo.DP_All_Queries a
where a.DbName='rsaf_dev'
and not exists(select 1 from duplicate_queries b where a.QueryName=b.QueryName)
order by a.QueryID

--RSAF2 non duplicate queries
with duplicate_queries as
(
select a.QueryName,a.State,
a.RecordCount as [rsaf_dev RecordNumber],
b.RecordCount as [RSAF2 RecordNumber]
from RSAF_Staging.dbo.DP_All_Queries a
join ( select *
from RSAF_Staging.dbo.DP_All_Queries
where DbName='RSAF2') b
on a.QueryName = b.QueryName
where a.DbName='rsaf_dev')
select a.QueryName,a.State,a.RecordCount
from RSAF_Staging.dbo.DP_All_Queries a
where a.DbName='RSAF2'
and not exists(select 1 from duplicate_queries b where a.QueryName=b.QueryName)
order by a.QueryID
go

use RSAF_Staging
GO

DELETE DP_Used_Queries;
GO

bulk insert DP_Used_Queries
from 'C:\Users\uyigit.admin\source\repos\RB199_RSAF\RSAF_ETL\Miscellaneous\UsedQueries.csv'
with
(
firstrow=1,
fieldterminator=';',
rowterminator='\n'
);
go

use RSAF_Staging
go

DELETE DP_RSAF2QueriesParse;
GO

bulk insert DP_RSAF2QueriesParse
from 'C:\Users\uyigit.admin\source\repos\RB199_RSAF\RSAF_ETL\Miscellaneous\RSAF2QueriesParse.csv'
with
(
firstrow=1,
fieldterminator=';',
rowterminator='\n'
);

alter table DP_RSAF2QueriesParse add QueryNo int;
go
alter table DP_RSAF2QueriesParse add SelectRowNo int;
go
alter table DP_RSAF2QueriesParse add FromRowNo int;
go
alter table DP_RSAF2QueriesParse add WhereRowNo int;
go
alter table DP_RSAF2QueriesParse add OrderRowNo int;
go
alter table DP_RSAF2QueriesParse add GroupRowNo int;
go
alter table DP_RSAF2QueriesParse add EOQRowNo int;
go
alter table DP_RSAF2QueriesParse add QueryName nvarchar(MAX);
go

with QueryNumbers as
(SELECT QueryNo
	  ,RowNo as FirstRowofQuery
	  ,LastRowofQuery 
	  ,LastRow
FROM ( SELECT [RowNo]
			  ,rank()Over(order by RowNo) as QueryNo
			  ,MAX(RowNo)Over() as LastRow
			  ,MAX(RowNo)Over(order by RowNo rows between 1 preceding and 1 following)-1 as LastRowofQuery
		  FROM [RSAF_Staging].[dbo].[DP_RSAF2QueriesParse]
		  WHERE RowText='GO') A
WHERE RowNo <> LastRow
--ORDER BY RowNo
)
update RSAF_Staging.dbo.DP_RSAF2QueriesParse
set QueryNo = b.QueryNo
from  QueryNumbers b
where RowNo between b.FirstRowofQuery and b.LastRowofQuery
go

alter table DP_RSAF2QueriesParse add RowType varchar(2);
go

update DP_RSAF2QueriesParse
set RowType = case RowText
                when 'SELECT' then 'S'
				when 'WHERE' then 'W'
				when 'ORDER BY' then 'O'
				when 'GROUP BY' then 'G'
				when 'GO' then 'I'
				else
				  case when RowText like '--%' then 'I'
				       when RowText like 'CREATE%' then 'C'
					   when RowText like 'FROM%' then 'F'
                  end
              end
go

with select_statement as
(select QueryNo QNo,RowNo   
from RSAF_Staging.dbo.DP_RSAF2QueriesParse
where rowtype='S') 
update RSAF_Staging.dbo.DP_RSAF2QueriesParse
set SelectRowNo = b.RowNo
from  select_statement b
where  QueryNo=b.QNo
go

with from_statement as
(select QueryNo QNo,RowNo   
from RSAF_Staging.dbo.DP_RSAF2QueriesParse
where rowtype='F') 
update RSAF_Staging.dbo.DP_RSAF2QueriesParse
set FromRowNo = b.RowNo
from  from_statement b
where  QueryNo=b.QNo
go


with where_statement as
(select QueryNo QNo,RowNo   
from RSAF_Staging.dbo.DP_RSAF2QueriesParse
where rowtype='W') 
update RSAF_Staging.dbo.DP_RSAF2QueriesParse
set WhereRowNo = b.RowNo
from  where_statement b
where  QueryNo=b.QNo
go

with orderby_statement as
(select QueryNo QNo,RowNo   
from RSAF_Staging.dbo.DP_RSAF2QueriesParse
where rowtype='O') 
update RSAF_Staging.dbo.DP_RSAF2QueriesParse
set OrderRowNo = b.RowNo
from  orderby_statement b
where  QueryNo=b.QNo
go

with groupby_statement as
(select QueryNo QNo,RowNo   
from RSAF_Staging.dbo.DP_RSAF2QueriesParse
where rowtype='G') 
update RSAF_Staging.dbo.DP_RSAF2QueriesParse
set GroupRowNo = b.RowNo
from  groupby_statement b
where  QueryNo=b.QNo
go

with EndOfQuery as
(select rank()over(order by case when QueryNo is null then 999 else QueryNo end)-1 as QNo,
RowNo -1  as RowNo
from RSAF_Staging.dbo.DP_RSAF2QueriesParse
where RowText='GO') 
update RSAF_Staging.dbo.DP_RSAF2QueriesParse
set EOQRowNo = b.RowNo
from  EndOfQuery b
where  QueryNo=b.QNo
go

with ViewName as
(select QueryNo as QNo,
substring(RowText,14,len(RowText)-17)  as QName
from RSAF_Staging.dbo.DP_RSAF2QueriesParse
where RowText  like 'CREATE VIEW % AS' )
update RSAF_Staging.dbo.DP_RSAF2QueriesParse
set QueryName = b.QName
from  ViewName b
where  QueryNo=b.QNo
go

update RSAF_Staging.dbo.DP_RSAF2QueriesParse set  RowType=null where RowType in('SC','WC','OC','GC')
go

update RSAF_Staging.dbo.DP_RSAF2QueriesParse
set RowType='SC'
where RowNo between SelectRowNo+1 and FromRowNo-1
go

update RSAF_Staging.dbo.DP_RSAF2QueriesParse
set RowType='WC'
where RowNo between WhereRowNo+1 and OrderRowNo-1
and RowType is null
go

update  RSAF_Staging.dbo.DP_RSAF2QueriesParse
set RowType='OC'
where RowNo between OrderRowNo+1 and EOQRowNo
and RowType is null
go

update RSAF_Staging.dbo.DP_RSAF2QueriesParse
set RowType='GC'
where RowNo between GroupRowNo+1 and EOQRowNo
and RowType is null
go

update RSAF_Staging.dbo.DP_RSAF2QueriesParse
set RowType='WC'
where RowNo between WhereRowNo+1 and GroupRowNo-1
and RowType is null
go

update RSAF_Staging.dbo.DP_RSAF2QueriesParse
set RowType='WC'
where RowNo between WhereRowNo+1 and EOQRowNo
and RowType is null
go

use RSAF2
go

delete RSAF_Staging.dbo.DP_Data_Lineage
go

insert into RSAF_Staging.dbo.DP_Data_Lineage
select b.queryname,a.RowNo,a.RowType,a.RowText,z.ColumnId,z.ColumnName
from  RSAF_Staging.dbo.DP_Used_Queries b
join RSAF_Staging.dbo.DP_RSAF2QueriesParse a
on a.QueryName=b.QueryName
join (select column_id as ColumnId,x.name as ColumnName
        from sys.all_columns x
	    join sys.all_objects y
		  on x.object_id =y.object_id
		where y.name='RSAF TABLE'   
	 ) z
on charindex('[RSAF TABLE].'+z.ColumnName,a.RowText)<>0 or
   charindex('[RSAF TABLE].['+z.ColumnName+']',a.RowText)<>0 or
   charindex('['+z.ColumnName+']',a.RowText)<>0
where a.RowType in('SC','WC','OC','GC')
order by z.ColumnId,a.RowNo
go

use RSAF2
go

delete from RSAF_Staging.dbo.DP_Usage_Frequency
go
insert into RSAF_Staging.dbo.DP_Usage_Frequency
select z.name,
IsNull(x.isBinding,0) as isBinding,
IsNull(x.inReport,0) as inReport,
IsNull(x.inSelect,0) as inSelect,
IsNull(x.inWhere,0) as inWhere,
IsNull(x.inOrder,0) as inOrder,
IsNull(x.inGroup,0) as inGroup
from
     (select column_id ,x.name 
        from sys.all_columns x
	    join sys.all_objects y
		  on x.object_id =y.object_id
		where y.name='RSAF TABLE'   
	 ) z
left join
(select a.ColumnName,a.ColumnId,
1 as isBinding,
count(distinct QueryName) as inReport,
sum(case when RowType='SC' then 1 else 0 end) as inSelect,
sum(case when RowType='WC' then 1 else 0 end) as inWhere,
sum(case when RowType='OC' then 1 else 0 end) as inOrder,
sum(case when RowType='GC' then 1 else 0 end) as inGroup
from RSAF_Staging.dbo.DP_Data_Lineage a
group by a.ColumnName,a.ColumnId) x
GO

DELETE [RSAF_Staging].[dbo].[DP_Data_Quality]
GO

bulk insert [RSAF_Staging].[dbo].[DP_Data_Quality]
from 'C:\Users\uyigit.admin\source\repos\RB199_RSAF\RSAF_ETL\Miscellaneous\DataQuality.csv'
with
(
firstrow=1,
fieldterminator=';',
rowterminator='\n'
);


DELETE [RSAF_Staging].[dbo].[DP_Type]
GO

INSERT INTO [RSAF_Staging].[dbo].[DP_Type](TYPE_CODE,TYPE)VALUES('A','ACCESSORY');
INSERT INTO [RSAF_Staging].[dbo].[DP_Type](TYPE_CODE,TYPE)VALUES('P','PIECE');
INSERT INTO [RSAF_Staging].[dbo].[DP_Type](TYPE_CODE,TYPE)VALUES('M','MODULE');

DELETE FROM [RSAF_STAGING].[DBO].[TR_DATA_QUALITY]
GO
INSERT  INTO [RSAF_STAGING].[DBO].[TR_DATA_QUALITY]
SELECT [BAEPO]
      ,COALESCE(I.[dqValue],A.[POITEM],'1/1') AS [POITEM]
      ,[X]
      ,[PART_NO]
      ,[SERIAL]
      ,[QTYREC]
      ,COALESCE([WARR],'N',[WARR]) AS [WARR]
      ,[RECDOC]
      ,[OONUM]
      ,[PSIREF]
      ,COALESCE([SITE],'S',[SITE]) AS [SITE]
      ,[DESPPART]
      ,[RVREF]
      ,[ANSPSI]
      ,[ANSRVREF]
      ,[DESPTOBA]
      ,[QTYSCRP]
      ,[SCRPREF]
      ,[REMARKS]
      ,[RECDATE]
      ,[PSIDATE]
      ,[DESPARDT]
      ,[RECDPART]
      ,[INTOROS]
      ,[ANSPSIDT]
      ,[DESPDATE]
      ,[BAEPART]
      ,[BAEQTY]
      ,[BAESER]
      ,[BAESENT]
      ,[OUTPART]
      ,[REF]
      ,COALESCE(T.[dqValue],A.[TYPE]) AS [TYPE]
      ,[PROMISE]
      ,[PROMDATE]
      ,[POIC]
      ,[RCP]
      ,[RCD]
      ,[ARCHIVE]
      ,[CTRT DATE]
      ,COALESCE([MDR],'N/A',[MDR]) AS [MDR]
      ,[QUOTE REF]
      ,[QUOTE REF DATE]
      ,[INVOICE PAID]
      ,[INVOICE REQUESTED]
      ,[ENG MARK]
      ,[HOURS NEW]
      ,[HOURS REP]
      ,[DESCRIPTION]
      ,[RFR]
      ,[EX ENGINE]
      ,[MODULE TEXT]
      ,[ACC DM]
      ,[ACC STG]
      ,[EURO]
      ,[PAEURO]
      ,[PREVIOUS PROMISE DATE]
	  ,D.[dqValue] AS MASTER_DESCRIPTION
  FROM [RSAF2].[dbo].[RSAF TABLE] A
LEFT JOIN [RSAF_Staging].[dbo].[DP_Data_Quality] T
  ON A.[BAEPO]=T.[dqBaepo] AND A.[BAEPART]=T.[dqBaepart] AND [POITEM]=T.[dqPoitem] AND T.[dqSelector]='T'
LEFT JOIN [RSAF_Staging].[dbo].[DP_Data_Quality] D
  ON A.[BAEPO]=D.[dqBaepo] AND A.[BAEPART]=D.[dqBaepart] AND A.[SITE]=D.[dqSite] AND  A.[TYPE]=D.[dqType] AND D.[dqSelector]='D'
LEFT JOIN [RSAF_Staging].[dbo].[DP_Data_Quality] I
  ON A.[BAEPO]=I.[dqBaepo] AND A.[BAEPART]=I.[dqBaepart] AND A.[SITE]=I.[dqSite] AND  A.[TYPE]=I.[dqType] AND A.[X]=I.[dqX] AND I.[dqSelector]='I'
GO

DELETE FROM [RSAF_STAGING].[DBO].[TR_FIRST_PRIORITY]
GO
INSERT  INTO [RSAF_STAGING].[DBO].[TR_FIRST_PRIORITY] 
SELECT DISTINCT BAEPO,BAEPART,SITE,TYPE
FROM [RSAF_STAGING].[DBO].[TR_DATA_QUALITY]
WHERE [X]<=1077
GO

DELETE  [RSAF_Staging].[dbo].[TR_DETAIL]
GO
INSERT INTO  [RSAF_Staging].[dbo].[TR_DETAIL]
SELECT 
       ROW_NUMBER()OVER(ORDER BY CASE WHEN FP.BAEPO IS NOT NULL THEN 0 ELSE 1 END,
								 A.BAEPO,
								 CASE WHEN FP.BAEPO IS NOT NULL THEN POITEM ELSE CAST(X AS NVARCHAR(10)) END,
								 A.BAEPART,
								 A.SITE,
								 A.TYPE
                       ) AS DETAIL_ID,
       ROW_NUMBER()OVER(PARTITION BY A.[BAEPO],A.[BAEPART],A.[SITE],A.[TYPE] ORDER BY [POITEM] ,[X]) AS MASTER_ORDER,
	   GETDATE() AS CREATE_DATE,
	   A.[BAEPO]
      ,[POITEM]
      ,[X]
      ,[PART_NO]
      ,[SERIAL]
      ,[QTYREC]
      ,[WARR]
      ,[RECDOC]
      ,[OONUM]
      ,[PSIREF]
      ,A.[SITE]
      ,[DESPPART]
      ,[RVREF]
      ,[ANSPSI]
      ,[ANSRVREF]
      ,[DESPTOBA]
      ,[QTYSCRP]
      ,[SCRPREF]
      ,[REMARKS]
      ,[RECDATE]
      ,[PSIDATE]
      ,[DESPARDT]
      ,[RECDPART]
      ,[INTOROS]
      ,[ANSPSIDT]
      ,[DESPDATE]
      ,A.[BAEPART]
      ,[BAEQTY]
      ,[BAESER]
      ,[BAESENT]
      ,[OUTPART]
      ,[REF]
      ,A.[TYPE]
      ,[PROMISE]
      ,[PROMDATE]
      ,[POIC]
      ,[RCP]
      ,[RCD]
      ,[ARCHIVE]
      ,[CTRT DATE]
      ,[MDR]
      ,[QUOTE REF]
      ,[QUOTE REF DATE]
      ,[INVOICE PAID]
      ,[INVOICE REQUESTED]
      ,[ENG MARK]
      ,[HOURS NEW]
      ,[HOURS REP]
      ,[DESCRIPTION]
      ,[RFR]
      ,[EX ENGINE]
      ,[MODULE TEXT]
      ,[ACC DM]
      ,[ACC STG]
      ,[EURO]
      ,[PAEURO]
      ,[PREVIOUS PROMISE DATE]
	  ,[MASTER_DESCRIPTION]
  FROM [RSAF_STAGING].[DBO].[TR_DATA_QUALITY] A
LEFT JOIN [RSAF_STAGING].[DBO].[TR_FIRST_PRIORITY] FP
  ON A.[BAEPO]=FP.[BAEPO] AND A.[BAEPART]=FP.[BAEPART] AND A.[SITE]=FP.[SITE] AND A.[TYPE]=FP.[TYPE]
GO

DELETE [RSAF_Staging].[dbo].[TR_MASTER]
GO
INSERT INTO [RSAF_Staging].[dbo].[TR_MASTER]
SELECT CREATE_DATE,
CAST(NULL AS DATETIME) AS UPDATE_DATE,
CAST(1 AS BIT) AS STATUS,
ROW_NUMBER()OVER(ORDER BY DETAIL_ID) AS MASTER_ID,
BAEPO,
BAEPART,
SITE,
TYPE,
COALESCE(MASTER_DESCRIPTION,DESCRIPTION) AS DESCRIPTION
FROM [RSAF_Staging].[dbo].[TR_DETAIL]
WHERE MASTER_ORDER=1
GO
