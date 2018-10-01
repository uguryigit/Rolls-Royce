
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/18/2018 17:09:07
-- Generated from EDMX file: C:\Users\uyigit.admin\source\repos\RB199_RSAF\RSAF_Forms\RSAFModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RSAF_Prod];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RSAF_ARCHIVE_DETAIL]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RSAF_ARCHIVE] DROP CONSTRAINT [FK_RSAF_ARCHIVE_DETAIL];
GO
IF OBJECT_ID(N'[dbo].[FK_RSAF_DETAIL_HIST]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RSAF_DETAIL_HIST] DROP CONSTRAINT [FK_RSAF_DETAIL_HIST];
GO
IF OBJECT_ID(N'[dbo].[FK_RSAF_DETAIL_MASTER]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RSAF_DETAIL] DROP CONSTRAINT [FK_RSAF_DETAIL_MASTER];
GO
IF OBJECT_ID(N'[dbo].[FK_RSAF_MASTER_HIST]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RSAF_MASTER_HIST] DROP CONSTRAINT [FK_RSAF_MASTER_HIST];
GO
IF OBJECT_ID(N'[dbo].[FK_RSAF_MASTER_SITE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RSAF_MASTER] DROP CONSTRAINT [FK_RSAF_MASTER_SITE];
GO
IF OBJECT_ID(N'[dbo].[FK_RSAF_MASTER_TYPE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RSAF_MASTER] DROP CONSTRAINT [FK_RSAF_MASTER_TYPE];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[RSAF_ARCHIVE]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RSAF_ARCHIVE];
GO
IF OBJECT_ID(N'[dbo].[RSAF_DETAIL]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RSAF_DETAIL];
GO
IF OBJECT_ID(N'[dbo].[RSAF_DETAIL_HIST]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RSAF_DETAIL_HIST];
GO
IF OBJECT_ID(N'[dbo].[RSAF_MASTER]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RSAF_MASTER];
GO
IF OBJECT_ID(N'[dbo].[RSAF_MASTER_HIST]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RSAF_MASTER_HIST];
GO
IF OBJECT_ID(N'[dbo].[RSAF_SITE]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RSAF_SITE];
GO
IF OBJECT_ID(N'[dbo].[RSAF_TYPE]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RSAF_TYPE];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RSAF_ARCHIVE'
CREATE TABLE [dbo].[RSAF_ARCHIVE] (
    [DETAIL_ID] bigint  NOT NULL,
    [X] bigint  NOT NULL,
    [RECDOC] nvarchar(24)  NULL,
    [DESPPART] nvarchar(12)  NULL,
    [RVREF] nvarchar(14)  NULL,
    [ANSPSI] nvarchar(14)  NULL,
    [ANSRVREF] nvarchar(14)  NULL,
    [SCRPREF] nvarchar(16)  NULL,
    [DESPARDT] datetime  NULL,
    [RECDPART] datetime  NULL,
    [INTOROS] datetime  NULL,
    [ANSPSIDT] datetime  NULL,
    [REF] nvarchar(34)  NULL,
    [PROMDATE] datetime  NULL,
    [RCD] decimal(19,4)  NULL,
    [ACC_DM] decimal(19,4)  NULL,
    [DESCRIPTION] nvarchar(510)  NULL
);
GO

-- Creating table 'RSAF_MASTER'
CREATE TABLE [dbo].[RSAF_MASTER] (
    [CREATE_DATE] datetime  NOT NULL,
    [UPDATE_DATE] datetime  NULL,
    [STATUS] bit  NOT NULL,
    [MASTER_ID] bigint IDENTITY(1,1) NOT NULL,
    [BAEPO] nvarchar(24)  NOT NULL,
    [BAEPART] nvarchar(30)  NOT NULL,
    [SITE] nvarchar(2)  NOT NULL,
    [TYPE] nvarchar(2)  NOT NULL,
    [DESCRIPTION] nvarchar(510)  NULL,
    [ROID_NO] nvarchar(25)  NULL
);
GO

-- Creating table 'RSAF_MASTER_HIST'
CREATE TABLE [dbo].[RSAF_MASTER_HIST] (
    [CREATE_DATE] datetime  NOT NULL,
    [UPDATE_DATE] datetime  NOT NULL,
    [STATUS] bit  NOT NULL,
    [MASTER_ID] bigint  NOT NULL,
    [BAEPO] nvarchar(24)  NOT NULL,
    [BAEPART] nvarchar(30)  NOT NULL,
    [SITE] nvarchar(2)  NOT NULL,
    [TYPE] nvarchar(2)  NOT NULL,
    [MDR] nvarchar(24)  NOT NULL,
    [DESCRIPTION] nvarchar(510)  NULL,
    [ROID_NO] nvarchar(25)  NULL
);
GO

-- Creating table 'RSAF_SITE'
CREATE TABLE [dbo].[RSAF_SITE] (
    [SITE_CODE] nvarchar(2)  NOT NULL,
    [SITE] nvarchar(20)  NULL
);
GO

-- Creating table 'RSAF_TYPE'
CREATE TABLE [dbo].[RSAF_TYPE] (
    [TYPE_CODE] nvarchar(2)  NOT NULL,
    [TYPE] nvarchar(20)  NULL
);
GO

-- Creating table 'RSAF_DETAIL'
CREATE TABLE [dbo].[RSAF_DETAIL] (
    [CREATE_DATE] datetime  NOT NULL,
    [UPDATE_DATE] datetime  NULL,
    [STATUS] bit  NOT NULL,
    [MASTER_ID] bigint  NOT NULL,
    [DETAIL_ID] bigint IDENTITY(1,1) NOT NULL,
    [POITEM] nvarchar(8)  NOT NULL,
    [MDR] nvarchar(24)  NOT NULL,
    [PART_NO] nvarchar(30)  NULL,
    [SERIAL] nvarchar(20)  NULL,
    [QTYREC] smallint  NULL,
    [WARR] bit  NOT NULL,
    [OONUM] nvarchar(30)  NULL,
    [PSIREF] nvarchar(34)  NULL,
    [DESPTOBA] nvarchar(16)  NULL,
    [QTYSCRP] smallint  NULL,
    [REMARKS] nvarchar(max)  NULL,
    [RECDATE] datetime  NULL,
    [PSIDATE] datetime  NULL,
    [DESPDATE] datetime  NULL,
    [BAEQTY] smallint  NULL,
    [BAESER] nvarchar(30)  NULL,
    [BAESENT] datetime  NULL,
    [OUTPART] nvarchar(30)  NULL,
    [PROMISE] datetime  NULL,
    [POIC] bit  NULL,
    [RCP] decimal(19,4)  NULL,
    [ARCHIVE] bit  NOT NULL,
    [CTRT_DATE] datetime  NULL,
    [QUOTE_REF] nvarchar(50)  NULL,
    [QUOTE_REF_DATE] datetime  NULL,
    [INVOICE_PAID] bit  NOT NULL,
    [INVOICE_REQUESTED] datetime  NULL,
    [ENG_MARK] int  NULL,
    [HOURS_NEW] int  NULL,
    [HOURS_REP] nvarchar(20)  NULL,
    [RFR] nvarchar(500)  NULL,
    [EX_ENGINE] int  NULL,
    [MODULE_TEXT] nvarchar(510)  NULL,
    [ACC_STG] decimal(19,4)  NULL,
    [EURO] decimal(19,4)  NULL,
    [PAEURO] decimal(19,4)  NULL,
    [PREVIOUS_PROMISE_DATE] datetime  NULL,
    [INVOICE_NO] nvarchar(20)  NULL,
    [SALES_DOCUMENT] bigint  NULL,
    [VENDOR] nvarchar(150)  NULL,
    [VENDOR_COFC] nvarchar(50)  NULL,
    [VENDOR_MATERIAL_COST] decimal(19,4)  NULL,
    [VENDOR_LABOR_COST] decimal(19,4)  NULL,
    [PO_REQ] bigint  NULL,
    [RR_PO] bigint  NULL,
    [QUALITY_NO] nvarchar(25)  NULL,
    [SAP_SES] bigint  NULL,
    [AWB_DETAILS] nvarchar(100)  NULL,
    [FLEX1] nvarchar(255)  NULL,
    [FLEX2] nvarchar(255)  NULL,
    [FLEX3] nvarchar(255)  NULL,
    [FLEX4] nvarchar(255)  NULL
);
GO

-- Creating table 'RSAF_DETAIL_HIST'
CREATE TABLE [dbo].[RSAF_DETAIL_HIST] (
    [CREATE_DATE] datetime  NOT NULL,
    [UPDATE_DATE] datetime  NOT NULL,
    [STATUS] bit  NOT NULL,
    [MASTER_ID] bigint  NOT NULL,
    [DETAIL_ID] bigint  NOT NULL,
    [POITEM] nvarchar(8)  NOT NULL,
    [MDR] nvarchar(24)  NOT NULL,
    [PART_NO] nvarchar(30)  NULL,
    [SERIAL] nvarchar(20)  NULL,
    [QTYREC] smallint  NULL,
    [WARR] bit  NOT NULL,
    [OONUM] nvarchar(30)  NULL,
    [PSIREF] nvarchar(34)  NULL,
    [DESPTOBA] nvarchar(16)  NULL,
    [QTYSCRP] smallint  NULL,
    [REMARKS] nvarchar(max)  NULL,
    [RECDATE] datetime  NULL,
    [PSIDATE] datetime  NULL,
    [DESPDATE] datetime  NULL,
    [BAEQTY] smallint  NULL,
    [BAESER] nvarchar(30)  NULL,
    [BAESENT] datetime  NULL,
    [OUTPART] nvarchar(30)  NULL,
    [PROMISE] datetime  NULL,
    [POIC] bit  NULL,
    [RCP] decimal(19,4)  NULL,
    [ARCHIVE] bit  NOT NULL,
    [CTRT_DATE] datetime  NULL,
    [QUOTE_REF] nvarchar(50)  NULL,
    [QUOTE_REF_DATE] datetime  NULL,
    [INVOICE_PAID] bit  NOT NULL,
    [INVOICE_REQUESTED] datetime  NULL,
    [ENG_MARK] int  NULL,
    [HOURS_NEW] int  NULL,
    [HOURS_REP] nvarchar(20)  NULL,
    [RFR] nvarchar(500)  NULL,
    [EX_ENGINE] int  NULL,
    [MODULE_TEXT] nvarchar(510)  NULL,
    [ACC_STG] decimal(19,4)  NULL,
    [EURO] decimal(19,4)  NULL,
    [PAEURO] decimal(19,4)  NULL,
    [PREVIOUS_PROMISE_DATE] datetime  NULL,
    [INVOICE_NO] nvarchar(20)  NULL,
    [SALES_DOCUMENT] bigint  NULL,
    [VENDOR] nvarchar(150)  NULL,
    [VENDOR_COFC] nvarchar(50)  NULL,
    [VENDOR_MATERIAL_COST] decimal(19,4)  NULL,
    [VENDOR_LABOR_COST] decimal(19,4)  NULL,
    [PO_REQ] bigint  NULL,
    [RR_PO] bigint  NULL,
    [QUALITY_NO] nvarchar(25)  NULL,
    [SAP_SES] bigint  NULL,
    [AWB_DETAILS] nvarchar(100)  NULL,
    [FLEX1] nvarchar(255)  NULL,
    [FLEX2] nvarchar(255)  NULL,
    [FLEX3] nvarchar(255)  NULL,
    [FLEX4] nvarchar(255)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [DETAIL_ID] in table 'RSAF_ARCHIVE'
ALTER TABLE [dbo].[RSAF_ARCHIVE]
ADD CONSTRAINT [PK_RSAF_ARCHIVE]
    PRIMARY KEY CLUSTERED ([DETAIL_ID] ASC);
GO

-- Creating primary key on [MASTER_ID] in table 'RSAF_MASTER'
ALTER TABLE [dbo].[RSAF_MASTER]
ADD CONSTRAINT [PK_RSAF_MASTER]
    PRIMARY KEY CLUSTERED ([MASTER_ID] ASC);
GO

-- Creating primary key on [UPDATE_DATE], [MASTER_ID] in table 'RSAF_MASTER_HIST'
ALTER TABLE [dbo].[RSAF_MASTER_HIST]
ADD CONSTRAINT [PK_RSAF_MASTER_HIST]
    PRIMARY KEY CLUSTERED ([UPDATE_DATE], [MASTER_ID] ASC);
GO

-- Creating primary key on [SITE_CODE] in table 'RSAF_SITE'
ALTER TABLE [dbo].[RSAF_SITE]
ADD CONSTRAINT [PK_RSAF_SITE]
    PRIMARY KEY CLUSTERED ([SITE_CODE] ASC);
GO

-- Creating primary key on [TYPE_CODE] in table 'RSAF_TYPE'
ALTER TABLE [dbo].[RSAF_TYPE]
ADD CONSTRAINT [PK_RSAF_TYPE]
    PRIMARY KEY CLUSTERED ([TYPE_CODE] ASC);
GO

-- Creating primary key on [DETAIL_ID] in table 'RSAF_DETAIL'
ALTER TABLE [dbo].[RSAF_DETAIL]
ADD CONSTRAINT [PK_RSAF_DETAIL]
    PRIMARY KEY CLUSTERED ([DETAIL_ID] ASC);
GO

-- Creating primary key on [UPDATE_DATE], [DETAIL_ID] in table 'RSAF_DETAIL_HIST'
ALTER TABLE [dbo].[RSAF_DETAIL_HIST]
ADD CONSTRAINT [PK_RSAF_DETAIL_HIST]
    PRIMARY KEY CLUSTERED ([UPDATE_DATE], [DETAIL_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MASTER_ID] in table 'RSAF_MASTER_HIST'
ALTER TABLE [dbo].[RSAF_MASTER_HIST]
ADD CONSTRAINT [FK_RSAF_MASTER_HIST]
    FOREIGN KEY ([MASTER_ID])
    REFERENCES [dbo].[RSAF_MASTER]
        ([MASTER_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RSAF_MASTER_HIST'
CREATE INDEX [IX_FK_RSAF_MASTER_HIST]
ON [dbo].[RSAF_MASTER_HIST]
    ([MASTER_ID]);
GO

-- Creating foreign key on [SITE] in table 'RSAF_MASTER'
ALTER TABLE [dbo].[RSAF_MASTER]
ADD CONSTRAINT [FK_RSAF_MASTER_SITE]
    FOREIGN KEY ([SITE])
    REFERENCES [dbo].[RSAF_SITE]
        ([SITE_CODE])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RSAF_MASTER_SITE'
CREATE INDEX [IX_FK_RSAF_MASTER_SITE]
ON [dbo].[RSAF_MASTER]
    ([SITE]);
GO

-- Creating foreign key on [TYPE] in table 'RSAF_MASTER'
ALTER TABLE [dbo].[RSAF_MASTER]
ADD CONSTRAINT [FK_RSAF_MASTER_TYPE]
    FOREIGN KEY ([TYPE])
    REFERENCES [dbo].[RSAF_TYPE]
        ([TYPE_CODE])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RSAF_MASTER_TYPE'
CREATE INDEX [IX_FK_RSAF_MASTER_TYPE]
ON [dbo].[RSAF_MASTER]
    ([TYPE]);
GO

-- Creating foreign key on [DETAIL_ID] in table 'RSAF_ARCHIVE'
ALTER TABLE [dbo].[RSAF_ARCHIVE]
ADD CONSTRAINT [FK_RSAF_ARCHIVE_DETAIL]
    FOREIGN KEY ([DETAIL_ID])
    REFERENCES [dbo].[RSAF_DETAIL]
        ([DETAIL_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [DETAIL_ID] in table 'RSAF_DETAIL_HIST'
ALTER TABLE [dbo].[RSAF_DETAIL_HIST]
ADD CONSTRAINT [FK_RSAF_DETAIL_HIST]
    FOREIGN KEY ([DETAIL_ID])
    REFERENCES [dbo].[RSAF_DETAIL]
        ([DETAIL_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RSAF_DETAIL_HIST'
CREATE INDEX [IX_FK_RSAF_DETAIL_HIST]
ON [dbo].[RSAF_DETAIL_HIST]
    ([DETAIL_ID]);
GO

-- Creating foreign key on [MASTER_ID] in table 'RSAF_DETAIL'
ALTER TABLE [dbo].[RSAF_DETAIL]
ADD CONSTRAINT [FK_RSAF_DETAIL_MASTER]
    FOREIGN KEY ([MASTER_ID])
    REFERENCES [dbo].[RSAF_MASTER]
        ([MASTER_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RSAF_DETAIL_MASTER'
CREATE INDEX [IX_FK_RSAF_DETAIL_MASTER]
ON [dbo].[RSAF_DETAIL]
    ([MASTER_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------