--Must login as database owner
-- REG_DWORD, 1  Windows Authentication
-- REG_DWORD, 2 Mix Mode
-- Windows Authentication is preferable


USE [master]
GO
EXEC xp_instance_regwrite N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'LoginMode', REG_DWORD, 1
GO
--Restart Database Server

--Info about Builtin\Administrators
EXEC master..xp_logininfo
@acctname = 'BUILTIN\Administrators',
@option = 'members'

--Drop Builtin\Administrators login if exists
USE MASTER
IF EXISTS (SELECT * FROM sys.server_principals
WHERE NAME = N'BUILTIN\Administrators')
DROP LOGIN [BUILTIN\Administrators]

--To Add Builtin\Administrators
--EXEC sp_grantlogin 'BUILTIN\Administrators'
--EXEC sp_addsrvrolemember 'BUILTIN\Administrators','sysadmin'


SELECT NAME AS LoginName, TYPE, TYPE_DESC As AccountType 
FROM sys.server_principals
WHERE TYPE in('U','S','G')
ORDER BY NAME

-- Disable sa account
ALTER LOGIN [sa] disable
GO

-- To enable sa account
--ALTER LOGIN [sa] enable
--GO


USE [master]
GO
--drop database [RSAF_Prod];
create database [RSAF_Prod];
GO
--drop database [RSAF_Adhoc;
create database [RSAF_Adhoc]
GO
--drop database [RSAF_Staging];
create database [RSAF_Staging];
GO
--drop database [rsaf_dev;
create database [rsaf_dev]
GO
--drop database [RSAF2];
create database [RSAF2]
GO

/*
--Drop logins
DROP LOGIN [RR\User1];
DROP LOGIN [RR\User2];
DROP LOGIN [RR\User3];
*/

--
--Create Login for RR Windows Domain users who are User1, User2,User3
CREATE LOGIN [RR\User1] FROM WINDOWS WITH DEFAULT_DATABASE=[master];  
CREATE LOGIN [RR\User2] FROM WINDOWS WITH DEFAULT_DATABASE=[master];  
CREATE LOGIN [RR\User3] FROM WINDOWS WITH DEFAULT_DATABASE=[master];   


--CREATE LOGIN [User1] WITH PASSWORD=N'P@ssword01', DEFAULT_DATABASE=[MASTER], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
--CREATE LOGIN [User2] WITH PASSWORD=N'P@ssword01', DEFAULT_DATABASE=[MASTER], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
--CREATE LOGIN [User3] WITH PASSWORD=N'P@ssword01', DEFAULT_DATABASE=[MASTER], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF

USE [RSAF_Prod]
GO
CREATE USER [User1] FOR LOGIN [RR\User1] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [User2] FOR LOGIN [RR\User2] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [User3] FOR LOGIN [RR\User3] WITH DEFAULT_SCHEMA=[dbo]
GO

USE [RSAF_Adhoc]
GO
CREATE USER [User1] FOR LOGIN [RR\User1] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [User2] FOR LOGIN [RR\User2] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE USER [User3] FOR LOGIN [RR\User3] WITH DEFAULT_SCHEMA=[dbo]
GO

USE [RSAF2]
GO
CREATE USER [User1] FOR LOGIN [[RR\User1] WITH DEFAULT_SCHEMA=[dbo]
GO

USE [rsaf_dev]
GO
CREATE USER [User1] FOR LOGIN [[RR\User1] WITH DEFAULT_SCHEMA=[dbo]
GO

USE [RSAF_Adhoc]
GO
ALTER ROLE [db_datareader] ADD MEMBER [User1]
GO
USE [RSAF_Adhoc]
GO
ALTER ROLE [db_datareader] ADD MEMBER [User2]
GO
USE [RSAF_Adhoc]
GO
ALTER ROLE [db_datareader] ADD MEMBER [User3]
GO

USE [RSAF_Prod]
GO
ALTER ROLE [db_datareader] ADD MEMBER [User1]
GO
USE [RSAF_Prod]
GO
ALTER ROLE [db_datareader] ADD MEMBER [User2]
GO

USE [RSAF_Prod]
GO
ALTER ROLE [db_datareader] ADD MEMBER [User3]
GO

USE [RSAF2]
GO
ALTER ROLE [db_datareader] ADD MEMBER [User1]
GO

USE [rsaf_dev]
GO
ALTER ROLE [db_datareader] ADD MEMBER [User1]
GO

USE [RSAF_Adhoc]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [User1]
GO

USE [RSAF_Prod]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [User1]
GO