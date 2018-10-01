
/*
--Droping Database
drop database Data_Profiling
GO
*/

create database [RSAF_Staging]
go
use [RSAF_Staging]
go

-------------------------  DATA PROFILING/LINEAGE TABLES AND PROCEDURES ------------

/*
-- DROP TABLE STATEMENTS

USE [RSAF_Staging]
GO
drop table [RSAF_Staging].[dbo].[DP_Table_RowCount]
GO
drop table [RSAF_Staging].[dbo].[DP_RSAF2]
GO
drop table [RSAF_Staging].[dbo].[DP_rsaf_dev]
GO
drop table [RSAF_Staging].[dbo].[DP_All_Queries]
GO
drop table [RSAF_Staging].[dbo].[DP_Used_Queries]
GO
drop table [RSAF_Staging].[dbo].[DP_RSAF2QueriesParse]
GO
drop table [RSAF_Staging].[dbo].[DP_Data_Lineage]
GO
drop table [RSAF_Staging].[dbo].[DP_Usage_Frequency]
GO
drop table [RSAF_Staging].[dbo].[DP_Data_Quality]
GO
drop table [RSAF_Staging].[dbo].[DP_Type]
GO
drop table [RSAF_Staging].[dbo].[DP_Description]
GO

USE [RSAF2]
GO
drop proc [dbo].[is_null]
GO
drop proc [dbo].[is_unique]
GO
drop proc [dbo].[find_null_uniq]
GO
drop proc [dbo].[min_max_val]
GO
drop proc [dbo].[find_min_max_val]
GO
drop proc [dbo].[upd_enum]
GO
drop proc [dbo].[enum_list]
GO
drop proc [dbo].[find_enum_list]
GO
drop proc [dbo].[CountRecord]
GO
drop proc [dbo].[find_record_count]
GO

USE [rsaf_dev]
GO
drop proc [dbo].[is_null]
GO
drop proc [dbo].[is_unique]
GO
drop proc [dbo].[find_null_uniq]
GO
drop proc [dbo].[min_max_val]
GO
drop proc [dbo].[find_min_max_val]
GO
drop proc [dbo].[upd_enum]
GO
drop proc [dbo].[enum_list]
GO
drop proc [dbo].[find_enum_list]
GO
drop proc [dbo].[CountRecord]
GO
drop proc [dbo].[find_record_count]
GO

*/


---------------- RSAF_Staging CREATE TABLES -------------

USE [RSAF_Staging]
GO

CREATE TABLE [RSAF_Staging].[dbo].[DP_Table_RowCount](
	[DbName] [varchar](20) NULL,
	[TableName] [varchar](50) NULL,
	[RecordCount] [int] NULL
)
GO

create table [RSAF_Staging].[dbo].[DP_RSAF2]
( table_id bigint,
  column_id bigint,
  table_name nvarchar(255),
  column_name nvarchar(255),
  data_type varchar(255),
  min_value decimal(24,6),
  max_value decimal(24,6),
  is_nullable smallint,
  is_unique smallint,
  is_enum smallint,
  enum_list nvarchar(MAX),
  is_flag smallint,
  is_reference smallint
);
GO

create table [RSAF_Staging].[dbo].[DP_rsaf_dev]
( table_id bigint,
  column_id bigint,
  table_name nvarchar(255),
  column_name nvarchar(255),
  data_type varchar(255),
  min_value decimal(24,6),
  max_value decimal(24,6),
  is_nullable smallint,
  is_unique smallint,
  is_enum smallint,
  enum_list nvarchar(MAX),
  is_flag smallint,
  is_reference smallint
)
go

create table [RSAF_Staging].[dbo].[DP_All_Queries](
DbName varchar(20),
QueryID int,
QueryName nvarchar(255),
RecordCount bigint,
State char(1))
GO

create table [RSAF_Staging].[dbo].[DP_Used_Queries]
(
QueryName nvarchar(255) not null primary key,
isGaryM smallint,
isGaryL smallint
)
go

create table [RSAF_Staging].[dbo].[DP_RSAF2QueriesParse]
(
RowNo bigint not null primary key,
RowText nvarchar(MAX)
)
go

CREATE TABLE [RSAF_Staging].[dbo].[DP_Data_Lineage](
	[queryname] [nvarchar](255) NOT NULL,
	[RowNo] [bigint] NOT NULL,
	[RowType] [varchar](2) NULL,
	[RowText] [nvarchar](max) NULL,
	[ColumnId] [int] NOT NULL,
	[ColumnName] [nvarchar](128) NULL
)
GO

CREATE TABLE [RSAF_Staging].[dbo].[DP_Usage_Frequency](
	[name] [nvarchar](128) NULL,
	[isBinding] [int] NOT NULL,
	[inReport] [int] NOT NULL,
	[inSelect] [int] NOT NULL,
	[inWhere] [int] NOT NULL,
	[inOrder] [int] NOT NULL,
	[inGroup] [int] NOT NULL
)
GO

CREATE TABLE [RSAF_Staging].[dbo].[DP_Data_Quality](
dqBaepo	varchar(24) not null,
dqBaepart varchar(30) not null,	
dqPoitem varchar(8) not null,	
dqSite	varchar(4) not null,
dqType varchar(4) not null,	
dqX bigint,
dqSelector varchar(1) not null,
dqValue nvarchar(510) not null
)
GO

CREATE TABLE [RSAF_Staging].[dbo].[DP_Type](
TYPE_CODE NVARCHAR(2) NOT NULL,
TYPE NVARCHAR(20)
)
GO

CREATE TABLE [RSAF_Staging].[dbo].[DP_Description](
dqDescription nvarchar(510),
dqReplacedBy nvarchar(510)
)
GO
---------------------------- RSAF2 CREATE PROCEDURES ------------------

use [RSAF2]
go

create proc [dbo].[is_null](@ptn varchar(250),@pcn varchar(250)) 
as
begin
  declare @i int;
  declare @str nvarchar(255);
  set @i=0;
  set @str='select @x=count(*) from dbo.['+@ptn+'] where ['+@pcn+'] is null';
  execute sp_executesql @str, N'@x int out', @i out;
  if @i>0 
  begin
    set @str='update RSAF_Staging.dbo.DP_RSAF2 set is_nullable=1 '+
	         'where replace(table_name,'''''''',''QQ'')='''+
			  replace(@ptn,'''','QQ')+''' and replace(column_name,'''''''',''QQ'')='''+
			  replace(@pcn,'''','QQ')+'''';
    execute sp_executesql @str;
  end
end
go

create proc [dbo].[is_unique](@ptn varchar(250),@pcn varchar(250)) 
as
begin
  declare @i int;
  declare @str nvarchar(255);
  set @i=0;
  set @str='select @x=iif(count(['+@pcn+'])=count(distinct['+@pcn+']) and count(['+@pcn+'])<>0 ,1,0) '+
           'from dbo.['+@ptn+'] where ['+@pcn+'] is not null';
  execute sp_executesql @str, N'@x int out', @i out;
  if @i>0 
  begin
    set @str='update RSAF_Staging.dbo.DP_RSAF2 set is_unique=1 '+
	         'where replace(table_name,'''''''',''QQ'')='''+
			  replace(@ptn,'''','QQ')+''' and replace(column_name,'''''''',''QQ'')='''+
			  replace(@pcn,'''','QQ')+'''';
    execute sp_executesql @str;
  end
end
go

create proc [dbo].[find_null_uniq] as 
begin
  declare db_cursor cursor for 
  select table_name,column_name,data_type 
  from RSAF_Staging.dbo.DP_RSAF2 
  order by table_name,column_id;

  declare @vtname nvarchar(255);
  declare @vcname nvarchar(255);
  declare @vdtype nvarchar(255);

  open db_cursor;
  fetch next from db_cursor into @vtname, @vcname, @vdtype;
  while @@FETCH_STATUS = 0  
  begin  
    exec dbo.is_null @vtname, @vcname;
	if @vdtype <> 'ntext'
      exec dbo.is_unique @vtname, @vcname;
    fetch next from db_cursor into @vtname, @vcname, @vdtype;
  end;
  close db_cursor;
  deallocate db_cursor;
end
GO

create proc [dbo].[min_max_val](@ptn varchar(250),@pcn varchar(250),@pdt varchar(250)) as
begin
  declare @imin decimal(24,6);
  declare @imax decimal(24,6);
  declare @str nvarchar(255);
  declare @casting nvarchar(255);
  set @imin=0;
  set @imax=0;
  if @pdt in ('datetime','datetime2')
    set @str='select @xmax=cast(format(max(['+@pcn+
	         ']),''yyyyMMdd.hhmss'') as decimal(24,6)),@xmin=cast(format(min(['+@pcn+
			 ']),''yyyyMMdd.hhmss'') as decimal(24,6)) from dbo.['+@ptn+']';
  else 
    set @str='select @xmax=max(['+@pcn+']),@xmin=min(['+@pcn+']) from dbo.['+@ptn+']';
  execute sp_executesql @str, N'@xmin int out, @xmax int out', @imin out, @imax out;
  if @imax>0
  begin   
    set @str='update RSAF_Staging.dbo.DP_RSAF2 '+
	         'set max_value='+cast(@imax as varchar(200))+
			  ' where replace(table_name,'''''''',''QQ'')='''+
			  replace(@ptn,'''','QQ')+''' and replace(column_name,'''''''',''QQ'')='''+
			  replace(@pcn,'''','QQ')+'''';
    execute sp_executesql @str;
  end;
  if @imin>0
  begin   
    set @str='update RSAF_Staging.dbo.DP_RSAF2 '+
	         'set min_value='+cast(@imin as varchar(200))+
			  ' where replace(table_name,'''''''',''QQ'')='''+
			  replace(@ptn,'''','QQ')+''' and replace(column_name,'''''''',''QQ'')='''+
			  replace(@pcn,'''','QQ')+'''';
    execute sp_executesql @str;
  end
end
go

create proc [dbo].[find_min_max_val] as 
begin
  declare db_cursor cursor for 
  select table_name,column_name,data_type
  from RSAF_Staging.dbo.DP_RSAF2 
 where max_value is null or min_value is null
  order by table_name,column_id;

  declare @vtname nvarchar(255);
  declare @vcname nvarchar(255);
  declare @vdtype nvarchar(255);

  open db_cursor;
  fetch next from db_cursor into @vtname, @vcname, @vdtype;
  while @@FETCH_STATUS = 0  
  begin  
    exec dbo.min_max_val @vtname, @vcname, @vdtype;
    fetch next from db_cursor into @vtname, @vcname, @vdtype;
  end;
  close db_cursor;
  deallocate db_cursor;
end
go

create proc [dbo].[upd_enum](@ptn nvarchar(250),@pcn nvarchar(250),@penumlist nvarchar(255)) as 
begin
  declare @str nvarchar(MAX);
  set @str='update RSAF_Staging.dbo.DP_RSAF2 '+
	       'set enum_list='''+@penumlist+
	       ''' where replace(table_name,'''''''',''QQ'')='''+
    	   replace(@ptn,'''','QQ')+''' and replace(column_name,'''''''',''QQ'')='''+
		   replace(@pcn,'''','QQ')+'''';
  execute sp_executesql @str;
end
go

create proc [dbo].[enum_list](@ptn varchar(250),@pcn varchar(250),@pdt varchar(250)) 
as
begin
  declare @str nvarchar(MAX);
  declare @c1 nvarchar(MAX);
  declare @c2 nvarchar(MAX);
  declare @c3 nvarchar(MAX);
  if @pdt = 'nvarchar' 
  begin
	set @c1='declare @item nvarchar(MAX); ';
	set @c2='set @str=@item; ';
	set @c3='set @str=@str+'',''+@item; ';
  end
  else 
  begin
    set @c1='declare @item bigint; ';
	set @c2='set @str=cast(@item as nvarchar(50)); ';
	set @c3='set @str=@str+'',''+cast(@item as nvarchar(50)); ';
  end
  set @str='declare in_cursor cursor for '+
           'select distinct ['+@pcn+'] '+
           'from dbo.['+@ptn+'] where ['+@pcn+'] is not null; '+
		   'declare @str nvarchar(MAX); '+@c1+
		   'open in_cursor; '+
		   'fetch next from in_cursor into @item; '+@c2+
		   'while @@FETCH_STATUS = 0 '+ 
		   'begin '+  
		   'fetch next from in_cursor into @item; '+
		   'if @@FETCH_STATUS = 0 ' +@c3+
		   'end; '+
		   'exec upd_enum '''+@ptn+''','''+@pcn+''',@str;' +
		   'close in_cursor; '+
		   'deallocate in_cursor;';
  execute sp_executesql @str;
end
go

create proc [dbo].[find_enum_list] as 
begin
  declare db_cursor cursor for 
  select table_name,column_name,data_type 
  from RSAF_Staging.dbo.DP_RSAF2 
  where is_enum=1
  order by table_name,column_id;

  declare @vtname nvarchar(255);
  declare @vcname nvarchar(255);
  declare @vdtype nvarchar(255);

  open db_cursor;
  fetch next from db_cursor into @vtname, @vcname, @vdtype;
  while @@FETCH_STATUS = 0  
  begin  
    exec dbo.enum_list @vtname, @vcname, @vdtype;
    fetch next from db_cursor into @vtname, @vcname, @vdtype;
  end;
  close db_cursor;
  deallocate db_cursor;
end;
go
use RSAF2
go

create proc [dbo].[CountRecord](@ptn varchar(255)) 
as
begin
  declare @i int;
  declare @str nvarchar(255);
  set @i=0;
  set @str='select @x=count(*) from dbo.['+@ptn+']';
  execute sp_executesql @str, N'@x int out', @i out;
  set @str='update RSAF_Staging.dbo.DP_All_Queries 
               set SQLRecordCount= '+cast(@i as varchar) +
           'where DbName=''RSAF2'' and replace(QueryName,'''''''',''QQ'')='''+ replace(@ptn,'''','QQ')+'''';
    execute sp_executesql @str;
end
go

create proc [dbo].[find_record_count] as 
begin
  declare db_cursor cursor for 
  select QueryName 
  from RSAF_Staging.dbo.DP_All_Queries
  where DbName='RSAF2'
    and State='R'
  order by QueryID;

  declare @vqname nvarchar(255);
  update RSAF_Staging.dbo.DP_All_Queries set SQLRecordCount=null where DbName='RSAF2';

  open db_cursor;
  fetch next from db_cursor into @vqname;
  while @@FETCH_STATUS = 0  
  begin  
    exec dbo.CountRecord @vqname;
    fetch next from db_cursor into @vqname;
  end;
  close db_cursor;
  deallocate db_cursor;
end
GO

------------- rsaf_dev CREATE PROCEDURES  -----------------------

use [rsaf_dev]
go

create proc [dbo].[is_null](@ptn varchar(250),@pcn varchar(250)) 
as
begin
  declare @i int;
  declare @str nvarchar(255);
  set @i=0;
  set @str='select @x=count(*) from dbo.['+@ptn+'] where ['+@pcn+'] is null';
  execute sp_executesql @str, N'@x int out', @i out;
  if @i>0 
  begin
    set @str='update RSAF_Staging.dbo.DP_rsaf_dev set is_nullable=1 '+
	         'where replace(table_name,'''''''',''QQ'')='''+
			  replace(@ptn,'''','QQ')+''' and replace(column_name,'''''''',''QQ'')='''+
			  replace(@pcn,'''','QQ')+'''';
    execute sp_executesql @str;
  end;
end
go

create proc [dbo].[is_unique](@ptn varchar(250),@pcn varchar(250)) 
as
begin
  declare @i int;
  declare @str nvarchar(255);
  set @i=0;
  set @str='select @x=iif(count(['+@pcn+'])=count(distinct['+@pcn+']) and count(['+@pcn+'])<>0 ,1,0) '+
           'from dbo.['+@ptn+'] where ['+@pcn+'] is not null';
  execute sp_executesql @str, N'@x int out', @i out;
  if @i>0 
  begin
    set @str='update RSAF_Staging.dbo.DP_rsaf_dev set is_unique=1 '+
	         'where replace(table_name,'''''''',''QQ'')='''+
			  replace(@ptn,'''','QQ')+''' and replace(column_name,'''''''',''QQ'')='''+
			  replace(@pcn,'''','QQ')+'''';
    execute sp_executesql @str;
  end;
end
go

create proc [dbo].[find_null_uniq] as 
begin
  declare db_cursor cursor for 
  select table_name,column_name,data_type 
  from RSAF_Staging.dbo.DP_rsaf_dev
  order by table_name,column_id;

  declare @vtname nvarchar(255);
  declare @vcname nvarchar(255);
  declare @vdtype nvarchar(255);

  open db_cursor;
  fetch next from db_cursor into @vtname, @vcname, @vdtype;
  while @@FETCH_STATUS = 0  
  begin  
    exec dbo.is_null @vtname, @vcname;
	if @vdtype <> 'ntext'
      exec dbo.is_unique @vtname, @vcname;
    fetch next from db_cursor into @vtname, @vcname, @vdtype;
  end;
  close db_cursor;
  deallocate db_cursor;
end
go

create proc [dbo].[min_max_val](@ptn varchar(250),@pcn varchar(250),@pdt varchar(250)) as
begin
  declare @imin decimal(24,6);
  declare @imax decimal(24,6);
  declare @str nvarchar(255);
  declare @casting nvarchar(255);
  set @imin=0;
  set @imax=0;
  if @pdt in ('datetime','datetime2')
    set @str='select @xmax=cast(format(max(['+@pcn+
	         ']),''yyyyMMdd.hhmss'') as decimal(24,6)),@xmin=cast(format(min(['+@pcn+
			 ']),''yyyyMMdd.hhmss'') as decimal(24,6)) from dbo.['+@ptn+']';
  else 
    set @str='select @xmax=max(['+@pcn+']),@xmin=min(['+@pcn+']) from dbo.['+@ptn+']';
  execute sp_executesql @str, N'@xmin int out, @xmax int out', @imin out, @imax out;
  if @imax>0
  begin   
    set @str='update RSAF_Staging.dbo.DP_rsaf_dev '+
	         'set max_value='+cast(@imax as varchar(200))+
			  ' where replace(table_name,'''''''',''QQ'')='''+
			  replace(@ptn,'''','QQ')+''' and replace(column_name,'''''''',''QQ'')='''+
			  replace(@pcn,'''','QQ')+'''';
    execute sp_executesql @str;
  end;
  if @imin>0
  begin   
    set @str='update RSAF_Staging.dbo.DP_rsaf_dev '+
	         'set min_value='+cast(@imin as varchar(200))+
			  ' where replace(table_name,'''''''',''QQ'')='''+
			  replace(@ptn,'''','QQ')+''' and replace(column_name,'''''''',''QQ'')='''+
			  replace(@pcn,'''','QQ')+'''';
    execute sp_executesql @str;
  end;
end
go

create proc [dbo].[find_min_max_val] as 
begin
  declare db_cursor cursor for 
  select table_name,column_name,data_type
  from RSAF_Staging.dbo.DP_rsaf_dev 
 where max_value is null or min_value is null
  order by table_name,column_id;

  declare @vtname nvarchar(255);
  declare @vcname nvarchar(255);
  declare @vdtype nvarchar(255);

  open db_cursor;
  fetch next from db_cursor into @vtname, @vcname, @vdtype;
  while @@FETCH_STATUS = 0  
  begin  
    exec dbo.min_max_val @vtname, @vcname, @vdtype;
    fetch next from db_cursor into @vtname, @vcname, @vdtype;
  end;
  close db_cursor;
  deallocate db_cursor;
end
go

create proc [dbo].[upd_enum](@ptn nvarchar(250),@pcn nvarchar(250),@penumlist nvarchar(255)) as 
begin
  declare @str nvarchar(MAX);
  set @str='update RSAF_Staging.dbo.DP_rsaf_dev '+
	       'set enum_list='''+@penumlist+
	       ''' where replace(table_name,'''''''',''QQ'')='''+
    	   replace(@ptn,'''','QQ')+''' and replace(column_name,'''''''',''QQ'')='''+
		   replace(@pcn,'''','QQ')+'''';
  execute sp_executesql @str;
end;
go

create proc dbo.enum_list(@ptn varchar(250),@pcn varchar(250),@pdt varchar(250)) 
as
begin
  declare @str nvarchar(MAX);
  declare @c1 nvarchar(MAX);
  declare @c2 nvarchar(MAX);
  declare @c3 nvarchar(MAX);
  if @pdt = 'nvarchar' 
  begin
	set @c1='declare @item nvarchar(MAX); ';
	set @c2='set @str=@item; ';
	set @c3='set @str=@str+'',''+@item; ';
  end
  else 
  begin
    set @c1='declare @item bigint; ';
	set @c2='set @str=cast(@item as nvarchar(50)); ';
	set @c3='set @str=@str+'',''+cast(@item as nvarchar(50)); ';
  end
  set @str='declare in_cursor cursor for '+
           'select distinct ['+@pcn+'] '+
           'from dbo.['+@ptn+'] where ['+@pcn+'] is not null; '+
		   'declare @str nvarchar(MAX); '+@c1+
		   'open in_cursor; '+
		   'fetch next from in_cursor into @item; '+@c2+
		   'while @@FETCH_STATUS = 0 '+ 
		   'begin '+  
		   'fetch next from in_cursor into @item; '+
		   'if @@FETCH_STATUS = 0 ' +@c3+
		   'end; '+
		   'exec upd_enum '''+@ptn+''','''+@pcn+''',@str;' +
		   'close in_cursor; '+
		   'deallocate in_cursor;';
  execute sp_executesql @str;
end
go

create proc [dbo].[find_enum_list] as 
begin
  declare db_cursor cursor for 
  select table_name,column_name,data_type 
  from RSAF_Staging.dbo.DP_rsaf_dev 
  where is_enum=1
  order by table_name,column_id;

  declare @vtname nvarchar(255);
  declare @vcname nvarchar(255);
  declare @vdtype nvarchar(255);

  open db_cursor;
  fetch next from db_cursor into @vtname, @vcname, @vdtype;
  while @@FETCH_STATUS = 0  
  begin  
    exec dbo.enum_list @vtname, @vcname, @vdtype;
    fetch next from db_cursor into @vtname, @vcname, @vdtype;
  end;
  close db_cursor;
  deallocate db_cursor;
end
go

create proc [dbo].[CountRecord](@ptn varchar(255)) 
as
begin
  declare @i int;
  declare @str nvarchar(255);
  set @i=0;
  set @str='select @x=count(*) from dbo.['+@ptn+']';
  execute sp_executesql @str, N'@x int out', @i out;
  set @str='update RSAF_Staging.dbo.DP_All_Queries 
               set SQLRecordCount= '+cast(@i as varchar) +
           'where DbName=''rsaf_dev'' and replace(QueryName,'''''''',''QQ'')='''+ replace(@ptn,'''','QQ')+'''';
    execute sp_executesql @str;
end
go

create proc [dbo].[find_record_count] as 
begin
  declare db_cursor cursor for 
  select QueryName 
  from RSAF_Staging.dbo.DP_All_Queries
  where DbName='rsaf_dev'
    and State='R'
  order by QueryID;

  declare @vqname nvarchar(255);
  update RSAF_Staging.dbo.DP_All_Queries set SQLRecordCount=null where DbName='rsaf_dev';

  open db_cursor;
  fetch next from db_cursor into @vqname;
  while @@FETCH_STATUS = 0  
  begin  
    exec dbo.CountRecord @vqname;
    fetch next from db_cursor into @vqname;
  end;
  close db_cursor;
  deallocate db_cursor;
end
go

--------------------------  LOAD TABLES --------------------------

/*
--DROP STATEMENTS
USE [RSAF_Staging]
GO
DROP TABLE [RSAF_Staging].[dbo].[LD_RSAF_ARCHIVE] 
GO
DROP TABLE [RSAF_Staging].[dbo].[LD_RSAF_DETAIL] 
GO
DROP TABLE [RSAF_Staging].[dbo].[LD_RSAF_MASTER] 
GO
DROP TABLE [RSAF_Staging].[dbo].[LD_RSAF_SITE] 
GO
DROP TABLE [RSAF_Staging].[dbo].[LD_RSAF_TYPE] 
GO
*/

CREATE TABLE [dbo].[LD_RSAF_ARCHIVE](
	[DETAIL_ID] [bigint] NOT NULL,
	[X] [bigint] NOT NULL,
	[RECDOC] [nvarchar](24) NULL,
	[DESPPART] [nvarchar](12) NULL,
	[RVREF] [nvarchar](14) NULL,
	[ANSPSI] [nvarchar](14) NULL,
	[ANSRVREF] [nvarchar](14) NULL,
	[SCRPREF] [nvarchar](16) NULL,
	[DESPARDT] [date] NULL,
	[RECDPART] [date] NULL,
	[INTOROS] [date] NULL,
	[ANSPSIDT] [date] NULL,
	[REF] [nvarchar](34) NULL,
	[PROMDATE] [date] NULL,
	[RCD] [money] NULL,
	[ACC_DM] [money] NULL,
	[DESCRIPTION] [nvarchar](510) NULL,
	[PREVIOUS_PROMISE_DATE] [date] NULL
)
GO

CREATE TABLE [dbo].[LD_RSAF_DETAIL](
	[CREATE_DATE] [datetime] NOT NULL,
	[UPDATE_DATE] [datetime] NULL,
	[STATUS] [bit] NOT NULL,
	[MASTER_ID] [bigint] NOT NULL,
	[DETAIL_ID] [bigint] NOT NULL,
	[POITEM] [nvarchar](8) NOT NULL,
	[MDR] [nvarchar](24) NOT NULL,
	[PART_NO] [nvarchar](30) NULL,
	[SERIAL] [nvarchar](20) NULL,
	[QTYREC] [smallint] NULL,
	[WARR] [bit] NOT NULL,
	[OONUM] [nvarchar](30) NULL,
	[PSIREF] [nvarchar](34) NULL,
	[DESPTOBA] [nvarchar](16) NULL,
	[QTYSCRP] [smallint] NULL,
	[REMARKS] [nvarchar](MAX) NULL,
	[RECDATE] [date] NULL,
	[PSIDATE] [date] NULL,
	[DESPDATE] [date] NULL,
	[BAEQTY] [smallint] NULL,
	[BAESER] [nvarchar](30) NULL,
	[BAESENT] [date] NULL,
	[OUTPART] [nvarchar](30) NULL,
	[PROMISE] [date] NULL,
	[POIC] [bit] NULL,
	[RCP] [money] NULL,
	[ARCHIVE] [bit] NOT NULL,
	[CTRT_DATE] [date] NULL,
	[QUOTE_REF] [nvarchar](50) NULL,
	[QUOTE_REF_DATE] [date] NULL,
	[INVOICE_PAID] [bit] NOT NULL,
	[INVOICE_REQUESTED] [date] NULL,
	[ENG_MARK] [int] NULL,
	[HOURS_NEW] [int] NULL,
	[HOURS_REP] [nvarchar](20) NULL,
	[RFR] [nvarchar](500) NULL,
	[EX_ENGINE] [int] NULL,
	[MODULE_TEXT] [nvarchar](510) NULL,
	[ACC_STG] [money] NULL,
	[EURO] [money] NULL,
	[PAEURO] [money] NULL,
	[FLEX_DATE] [date] NULL,
	[INVOICE_NO] [nvarchar](20) NULL,
	[SALES_DOCUMENT] BIGINT NULL,
	[VENDOR] [nvarchar](150) NULL,
	[VENDOR_COFC] [nvarchar](50) NULL,
	[VENDOR_MATERIAL_COST] [money] NULL,
    [VENDOR_LABOR_COST] [money] NULL,
	[PO_REQ] BIGINT NULL,
	[RR_PO] BIGINT NULL,
	[QUALITY_NO] [nvarchar](25) NULL,
	[SAP_SES] [bigint] NULL,
	[AWB_DETAILS] [nvarchar](100) NULL,
	[FLEX1] [nvarchar](255) NULL,
	[FLEX2] [nvarchar](255) NULL,
	[FLEX3] [nvarchar](255) NULL,
	[FLEX4] [nvarchar](255) NULL
)
GO

CREATE TABLE [dbo].[LD_RSAF_MASTER](
	[CREATE_DATE] [datetime] NOT NULL,
	[UPDATE_DATE] [datetime] NULL,
	[STATUS] [bit] NOT NULL,
	[MASTER_ID] [bigint] NOT NULL,
	[BAEPO] [nvarchar](24) NOT NULL,
	[BAEPART] [nvarchar](30) NOT NULL,
	[SITE] [nvarchar](2) NOT NULL,
	[TYPE] [nvarchar](2) NOT NULL,
	[DESCRIPTION] [nvarchar](510) NULL,
	[ROID_NO] [nvarchar](25) NULL
)
GO

CREATE TABLE [dbo].[LD_RSAF_SITE](
	[SITE_CODE] [nvarchar](2) NOT NULL,
	[SITE] [nvarchar](20) NULL
)
GO

CREATE TABLE [dbo].[LD_RSAF_TYPE](
	[TYPE_CODE] [nvarchar](2) NOT NULL,
	[TYPE] [nvarchar](20) NULL
)
GO


--------------------------  TRANSFORMATION TABLES --------------------------

/*
--DROP STATEMENTS
USE [RSAF_Staging]
GO
DROP TABLE [RSAF_Staging].[dbo].[TR_DATA_QUALITY] 
GO
DROP TABLE [RSAF_Staging].[dbo].[TR_FIRST_PRIORITY]
GO
DROP TABLE [RSAF_Staging].[dbo].[TR_DETAIL]
GO
DROP TABLE [RSAF_Staging].[dbo].[TR_MASTER]
GO

*/

CREATE TABLE [RSAF_Staging].[dbo].[TR_DATA_QUALITY](
	[BAEPO] [nvarchar](12) NULL,
	[POITEM] [nvarchar](8) NULL,
	[X] [bigint] NULL,
	[PART_NO] [nvarchar](15) NULL,
	[SERIAL] [nvarchar](10) NULL,
	[QTYREC] [decimal](14, 2) NULL,
	[WARR] [nvarchar](1) NULL,
	[RECDOC] [nvarchar](12) NULL,
	[OONUM] [nchar](15) NULL,
	[PSIREF] [nvarchar](17) NULL,
	[SITE] [nvarchar](1) NULL,
	[DESPPART] [nvarchar](6) NULL,
	[RVREF] [nvarchar](7) NULL,
	[ANSPSI] [nvarchar](7) NULL,
	[ANSRVREF] [nvarchar](7) NULL,
	[DESPTOBA] [nvarchar](8) NULL,
	[QTYSCRP] [int] NULL,
	[SCRPREF] [nvarchar](8) NULL,
	[REMARKS] [nvarchar](MAX) NULL,
	[RECDATE] [datetime] NULL,
	[PSIDATE] [datetime2](7) NULL,
	[DESPARDT] [datetime] NULL,
	[RECDPART] [datetime] NULL,
	[INTOROS] [datetime] NULL,
	[ANSPSIDT] [datetime] NULL,
	[DESPDATE] [datetime2](7) NULL,
	[BAEPART] [nvarchar](15) NULL,
	[BAEQTY] [int] NULL,
	[BAESER] [nvarchar](15) NULL,
	[BAESENT] [datetime] NULL,
	[OUTPART] [nvarchar](15) NULL,
	[REF] [nvarchar](17) NULL,
	[TYPE] [nvarchar](2) NULL,
	[PROMISE] [datetime] NULL,
	[PROMDATE] [datetime] NULL,
	[POIC] [nvarchar](1) NULL,
	[RCP] [decimal](14, 2) NULL,
	[RCD] [decimal](14, 2) NULL,
	[ARCHIVE] [nvarchar](5) NULL,
	[CTRT DATE] [datetime] NULL,
	[MDR] [nvarchar](12) NULL,
	[QUOTE REF] [nvarchar](25) NULL,
	[QUOTE REF DATE] [datetime] NULL,
	[INVOICE PAID] [nvarchar](3) NULL,
	[INVOICE REQUESTED] [datetime] NULL,
	[ENG MARK] [int] NULL,
	[HOURS NEW] [int] NULL,
	[HOURS REP] [nvarchar](10) NULL,
	[DESCRIPTION] [nvarchar](255) NULL,
	[RFR] [nvarchar](250) NULL,
	[EX ENGINE] [int] NULL,
	[MODULE TEXT] [nvarchar](255) NULL,
	[ACC DM] [decimal](14, 2) NULL,
	[ACC STG] [decimal](14, 2) NULL,
	[EURO] [decimal](14, 2) NULL,
	[PAEURO] [decimal](14, 2) NULL,
	[PREVIOUS PROMISE DATE] [datetime2](7) NULL,
	[MASTER_DESCRIPTION] [nvarchar](510) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [RSAF_Staging].[dbo].[TR_FIRST_PRIORITY](
	[BAEPO] [nvarchar](12) NULL,
	[BAEPART] [nvarchar](15) NULL,
	[SITE] [nvarchar](1) NULL,
	[TYPE] [nvarchar](2) NULL
) ON [PRIMARY]
GO

CREATE TABLE [RSAF_Staging].[dbo].[TR_DETAIL](
	[DETAIL_ID] [bigint] NULL,
	[CREATE_DATE] [datetime] NOT NULL,
	[BAEPO] [nvarchar](12) NULL,
	[POITEM] [nvarchar](8) NULL,
	[X] [bigint] NULL,
	[PART_NO] [nvarchar](15) NULL,
	[SERIAL] [nvarchar](10) NULL,
	[QTYREC] [decimal](14, 2) NULL,
	[WARR] [nvarchar](1) NULL,
	[RECDOC] [nvarchar](12) NULL,
	[OONUM] [nchar](15) NULL,
	[PSIREF] [nvarchar](17) NULL,
	[SITE] [nvarchar](1) NULL,
	[DESPPART] [nvarchar](6) NULL,
	[RVREF] [nvarchar](7) NULL,
	[ANSPSI] [nvarchar](7) NULL,
	[ANSRVREF] [nvarchar](7) NULL,
	[DESPTOBA] [nvarchar](8) NULL,
	[QTYSCRP] [int] NULL,
	[SCRPREF] [nvarchar](8) NULL,
	[REMARKS] [nvarchar](MAX) NULL,
	[RECDATE] [datetime] NULL,
	[PSIDATE] [datetime2](7) NULL,
	[DESPARDT] [datetime] NULL,
	[RECDPART] [datetime] NULL,
	[INTOROS] [datetime] NULL,
	[ANSPSIDT] [datetime] NULL,
	[DESPDATE] [datetime2](7) NULL,
	[BAEPART] [nvarchar](15) NULL,
	[BAEQTY] [int] NULL,
	[BAESER] [nvarchar](15) NULL,
	[BAESENT] [datetime] NULL,
	[OUTPART] [nvarchar](15) NULL,
	[REF] [nvarchar](17) NULL,
	[TYPE] [nvarchar](2) NULL,
	[PROMISE] [datetime] NULL,
	[PROMDATE] [datetime] NULL,
	[POIC] [nvarchar](1) NULL,
	[RCP] [decimal](14, 2) NULL,
	[RCD] [decimal](14, 2) NULL,
	[ARCHIVE] [nvarchar](5) NULL,
	[CTRT DATE] [datetime] NULL,
	[MDR] [nvarchar](12) NULL,
	[QUOTE REF] [nvarchar](25) NULL,
	[QUOTE REF DATE] [datetime] NULL,
	[INVOICE PAID] [nvarchar](3) NULL,
	[INVOICE REQUESTED] [datetime] NULL,
	[ENG MARK] [int] NULL,
	[HOURS NEW] [int] NULL,
	[HOURS REP] [nvarchar](10) NULL,
	[DESCRIPTION] [nvarchar](255) NULL,
	[RFR] [nvarchar](250) NULL,
	[EX ENGINE] [int] NULL,
	[MODULE TEXT] [nvarchar](255) NULL,
	[ACC DM] [decimal](14, 2) NULL,
	[ACC STG] [decimal](14, 2) NULL,
	[EURO] [decimal](14, 2) NULL,
	[PAEURO] [decimal](14, 2) NULL,
	[PREVIOUS PROMISE DATE] [datetime2](7) NULL,
	[MASTER_DESCRIPTION] [nvarchar](510) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [RSAF_Staging].[dbo].[TR_MASTER](
	[CREATE_DATE] [datetime] NOT NULL,
	[UPDATE_DATE] [datetime] NULL,
	[STATUS] [bit] NULL,
	[MASTER_ID] [bigint] NULL,
	[BAEPO] [nvarchar](24) NULL,
	[BAEPART] [nvarchar](30) NULL,
	[SITE] [nvarchar](2) NULL,
	[TYPE] [nvarchar](2) NULL,
	[DESCRIPTION] [nvarchar](510) NULL
) ON [PRIMARY]
GO
