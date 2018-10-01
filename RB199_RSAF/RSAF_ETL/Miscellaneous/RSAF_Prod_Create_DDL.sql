USE [RSAF_Prod]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
--DROP STATEMENTS

USE [RSAF_Prod]
GO
DROP TABLE [dbo].[RSAF_ARCHIVE]
GO
DROP TABLE [dbo].[RSAF_DETAIL_HIST]
GO
DROP TABLE [dbo].[RSAF_DETAIL]
GO
DROP TABLE [dbo].[RSAF_MASTER_HIST]
GO
DROP TABLE [dbo].[RSAF_MASTER]
GO
DROP TABLE [dbo].[RSAF_TYPE]
GO
DROP TABLE [dbo].[RSAF_SITE]
GO
DROP VIEW [dbo].[RSAF_TABLE]
GO
*/
CREATE TABLE [dbo].[RSAF_SITE](
	[SITE_CODE] [nvarchar](2) NOT NULL,
	[SITE] [nvarchar](20) NULL,
 CONSTRAINT [PK_RSAF_SITE] PRIMARY KEY CLUSTERED 
( 
	[SITE_CODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Repair Agency Site Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_SITE', @level2type=N'COLUMN',@level2name=N'SITE_CODE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Repair Agency Site Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_SITE', @level2type=N'COLUMN',@level2name=N'SITE'
GO


CREATE TABLE [dbo].[RSAF_TYPE](
	[TYPE_CODE] [nvarchar](2) NOT NULL,
	[TYPE] [nvarchar](20) NULL,
 CONSTRAINT [PK_RSAF_TYPE] PRIMARY KEY CLUSTERED 
(
	[TYPE_CODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Part Type Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_TYPE', @level2type=N'COLUMN',@level2name=N'TYPE_CODE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Part Type Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_TYPE', @level2type=N'COLUMN',@level2name=N'TYPE'
GO

CREATE TABLE [dbo].[RSAF_MASTER](
	[CREATE_DATE] [datetime] NOT NULL,
	[UPDATE_DATE] [datetime] NULL,
	[STATUS] [bit] NOT NULL,
	[MASTER_ID] [bigint] IDENTITY (1, 1) NOT NULL,
	[BAEPO] [nvarchar](24) NOT NULL,
	[BAEPART] [nvarchar](30) NOT NULL,
	[SITE] [nvarchar](2) NOT NULL,
	[TYPE] [nvarchar](2) NOT NULL,
	[DESCRIPTION] [nvarchar](510) NULL,
	[ROID_NO] [nvarchar](25) NULL,
 CONSTRAINT [PK_RSAF_MASTER] PRIMARY KEY CLUSTERED 
(
	[MASTER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_RSAF_MASTER] UNIQUE NONCLUSTERED 
(
	[BAEPO] ASC,
	[BAEPART] ASC,
	[SITE] ASC,
	[TYPE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RSAF_MASTER]  WITH CHECK ADD  CONSTRAINT [FK_RSAF_MASTER_SITE] FOREIGN KEY([SITE])
REFERENCES [dbo].[RSAF_SITE] ([SITE_CODE])
GO

ALTER TABLE [dbo].[RSAF_MASTER] CHECK CONSTRAINT [FK_RSAF_MASTER_SITE]
GO

ALTER TABLE [dbo].[RSAF_MASTER]  WITH CHECK ADD  CONSTRAINT [FK_RSAF_MASTER_TYPE] FOREIGN KEY([TYPE])
REFERENCES [dbo].[RSAF_TYPE] ([TYPE_CODE])
GO

ALTER TABLE [dbo].[RSAF_MASTER] CHECK CONSTRAINT [FK_RSAF_MASTER_TYPE]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Master Record Creation Date and Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_MASTER', @level2type=N'COLUMN',@level2name=N'CREATE_DATE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Master Record Last Updated Date and Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_MASTER', @level2type=N'COLUMN',@level2name=N'UPDATE_DATE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Master Record Status: 1 =Active; 0 =Deleted' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_MASTER', @level2type=N'COLUMN',@level2name=N'STATUS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Master Record Unique Identifier' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_MASTER', @level2type=N'COLUMN',@level2name=N'MASTER_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BAE PO No: Purchase order number. One per part or multiple parts per PO.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_MASTER', @level2type=N'COLUMN',@level2name=N'BAEPO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BAE P/N: In olden days worked with BAE systems. SMSC -> middle man. P/N part number.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_MASTER', @level2type=N'COLUMN',@level2name=N'BAEPART'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SITE: Repair Agency. S =Supplier or Vendor ; A = Ansty of RR; B = Bristol; F = Fiat = Avio; M = M2U Germany' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_MASTER', @level2type=N'COLUMN',@level2name=N'SITE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TYPE: Type of Part. A = Accessory; P = Piece Part; M = Module' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_MASTER', @level2type=N'COLUMN',@level2name=N'TYPE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DESCRIPTION: Description of the part - also same over time.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_MASTER', @level2type=N'COLUMN',@level2name=N'DESCRIPTION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ROID No: Customer generated purchase order number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_MASTER', @level2type=N'COLUMN',@level2name=N'ROID_NO'
GO

CREATE TABLE [dbo].[RSAF_MASTER_HIST](
	[CREATE_DATE] [datetime] NOT NULL,
	[UPDATE_DATE] [datetime] NOT NULL,
	[STATUS] [bit] NOT NULL,
	[MASTER_ID] [bigint] NOT NULL,
	[BAEPO] [nvarchar](24) NOT NULL,
	[BAEPART] [nvarchar](30) NOT NULL,
	[SITE] [nvarchar](2) NOT NULL,
	[TYPE] [nvarchar](2) NOT NULL,
	[MDR] [nvarchar](24) NOT NULL,
	[DESCRIPTION] [nvarchar](510) NULL,
	[ROID_NO] [nvarchar](25) NULL,
 CONSTRAINT [PK_RSAF_MASTER_HIST] PRIMARY KEY CLUSTERED 
(
	[MASTER_ID] ASC,
	[UPDATE_DATE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RSAF_MASTER_HIST]  WITH CHECK ADD  CONSTRAINT [FK_RSAF_MASTER_HIST] FOREIGN KEY([MASTER_ID])
REFERENCES [dbo].[RSAF_MASTER] ([MASTER_ID])
GO

ALTER TABLE [dbo].[RSAF_MASTER_HIST] CHECK CONSTRAINT [FK_RSAF_MASTER_HIST]
GO

CREATE TABLE [dbo].[RSAF_DETAIL](
	[CREATE_DATE] [datetime] NOT NULL,
	[UPDATE_DATE] [datetime] NULL,
	[STATUS] [bit] NOT NULL,
	[MASTER_ID] [bigint] NOT NULL,
	[DETAIL_ID] [bigint] IDENTITY(1,1) NOT NULL,
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
	[REMARKS] [nvarchar](max) NULL,
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
	[FLEX4] [nvarchar](255) NULL,
 CONSTRAINT [PK_RSAF_DETAIL] PRIMARY KEY CLUSTERED 
(
	[DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
CONSTRAINT [UK_RSAF_DETAIL] UNIQUE NONCLUSTERED 
(
	[MASTER_ID] ASC,
	[POITEM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[RSAF_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_RSAF_DETAIL_MASTER] FOREIGN KEY([MASTER_ID])
REFERENCES [dbo].[RSAF_MASTER] ([MASTER_ID])
GO

ALTER TABLE [dbo].[RSAF_DETAIL] CHECK CONSTRAINT [FK_RSAF_DETAIL_MASTER]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Detail Record Creation Date and Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'CREATE_DATE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Detail Record Last Updated Date and Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'UPDATE_DATE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Record Status: 1 =Active; 0 =Deleted' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'STATUS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'''Master Record Unique Identifier' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'MASTER_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Detail Record Unique Identifier' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'DETAIL_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ITEM No: This is the Line item' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'POITEM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MDR No: Material Deficency Report number, defect investigation.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'MDR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'RR RECVD P/N: RR recieved part number - Mod standards. Import knowladge' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'PART_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'S/N: Serial number recieved is different or wrong miss type. Comments to the vendors' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'SERIAL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'REC QTY: Recieved quantity. = Sent Qt. Of the parts / of a shipment. Seperate record for every line item.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'QTYREC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'WARRANTY: drop down Y, N, Pending. Majority are no. Pending to decide. / Yes = Investigate. Wincantone. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'WARR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'RR SAP No: Network activity… Cost collecting purposes. Not involved. 1 NWA what costs / whats been used' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'OONUM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'RI REF: Repair instruction Reference. Every item, used to print a seperate repair instruction. Format depends on the type, accessory, has it''s different, basic stuff is the same. Populating. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'PSIREF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'RR R / NOTE: RR Release notes. Document for each part, from vendor COC. -> compulsory' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'DESPTOBA'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SCRAP: Quantity of scrap' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'QTYSCRP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'REMARKS: All sorts of information. Example name of the vendor / Vendor names, Item scrapped, issued reports, proof of delivery details. Could be usefull.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'REMARKS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'REC DATE:  Recieved Date - physical item recieve date by Repair Agent' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'RECDATE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DATE: Date of Launch. Date of recieved PO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'PSIDATE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DESPATCH DATE:  Date the item being repaired - Linked to RR/R Note- The date to release note. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'DESPDATE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SENT QNT: Quantity from the customer purchase order. Unique PO per Quantity. Constant flow of them.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'BAEQTY'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'S/N: Serial number of the part… Lots are serialised and unique. For Warrent purpose. Most are. Non serialised. Basic blade' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'BAESER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SENT DATE: Purchase order sent and raised. Items are at Wincantum. Handling agent. For UK repair basis.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'BAESENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'P/N EX ROS: Part numer X spares, can change to whats been sent in. If changed then that superceeds' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'OUTPART'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PROMISE DATE: Populated when been in repair for a while. Supplier handling the repair. RR chaising' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'PROMISE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PO ITEM CLOSED: Yes just to say it''s closed.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'POIC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'REPAIR COST (£): Fixed Price and traditional contract, price to customer. Fix price contract will have a fixed price.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'RCP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ARCHIVED: Tick flag -> closing, priced invoiced, for history.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'ARCHIVE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CTRT DATE: Contract turn around time / date. Required date from PO.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'CTRT_DATE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QUOTE No: Reference number, sent to the customer. Under fixed price. New Field -> Contract its applicable to… fixed price ended 2016. Under quarterly ITP (instructions to proceed) sometimes the field mean different things.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'QUOTE_REF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QUOTE DATE: Linked to the pricing' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'QUOTE_REF_DATE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'INV PAID:  Invoice paid, not used. Somtimes go to finance to check ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'INVOICE_PAID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'INVOICE DATE:  Date raise invoice for traditional items. In SAP actually raised. Last week of every month.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'INVOICE_REQUESTED'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ENG MARK: Engine mark, only used for Type M modules' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'ENG_MARK'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'HOURS NEW: Engine mark, only used for Type M modules' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'HOURS_NEW'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'HOURS REP: Engine mark, only used for Type M modules' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'HOURS_REP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'RFR: Reason for return. For Modules, Type M. Copies of Log card = record of what has been done to. Nice to have.  But useful to decide process. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'RFR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EX ENGINE: Engine mark, only used for Type M modules' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'EX_ENGINE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'R.I.: For Repair instructions. Adding to Repair Instruction report.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'MODULE_TEXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'P or A STG: Partner or Accessory GPB - Vendors costs.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'ACC_STG'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EURO: Price to customer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'EURO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'P or A EURO: Partner or accessory Euros - Vendors costs.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'PAEURO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FLEX DATE: Spare datetime field for future use.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'FLEX_DATE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'INVOICE NO: Invoice Number generated by SAP NWA System' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'INVOICE_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SALES DOCUMENT: Used later to create the invoice; Copied off of SAP Vendor Certification' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'SALES_DOCUMENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VENDOR: Vendor Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'VENDOR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VENDOR_COFC: Vendor Certificate of Confirmation' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'VENDOR_COFC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VENDOR_MATERIAL_COST: Vendor Material Cost' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'VENDOR_MATERIAL_COST'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VENDOR_LABOR_COST: Vendor Labor Cost' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'VENDOR_LABOR_COST'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PO REQ: Purchase Order Vendor Requisition number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'PO_REQ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'RR PO: Purchase requisition, then generate the PO number; entered into the Database' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'RR_PO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QUALITY No: Rolls-Royce quality number, once’s Received from the System' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'QUALITY_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SAP SES: Generated by SAP allows to vendor paid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'SAP_SES'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'AWB_DETAILS: Air way bill details. Courier reference number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'AWB_DETAILS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FLEX1: A Spare field in case of any need in the future instead of writing in Remarks field.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'FLEX1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FLEX2: A Spare field in case of any need in the future instead of writing in Remarks field.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'FLEX2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FLEX3: A Spare field in case of any need in the future instead of writing in Remarks field.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'FLEX3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FLEX4: A Spare field in case of any need in the future instead of writing in Remarks field.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_DETAIL', @level2type=N'COLUMN',@level2name=N'FLEX4'
GO

CREATE TABLE [dbo].[RSAF_DETAIL_HIST](
	[CREATE_DATE] [datetime] NOT NULL,
	[UPDATE_DATE] [datetime] NOT NULL,
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
 CONSTRAINT [PK_RSAF_DETAIL_HIST] PRIMARY KEY CLUSTERED 
(
	[DETAIL_ID] ASC,
	[UPDATE_DATE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[RSAF_DETAIL_HIST]  WITH CHECK ADD  CONSTRAINT [FK_RSAF_DETAIL_HIST] FOREIGN KEY([DETAIL_ID])
REFERENCES [dbo].[RSAF_DETAIL] ([DETAIL_ID])
GO

ALTER TABLE [dbo].[RSAF_DETAIL_HIST] CHECK CONSTRAINT [FK_RSAF_DETAIL_HIST]
GO

CREATE TABLE [dbo].[RSAF_ARCHIVE](
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
	[PREVIOUS_PROMISE_DATE] [date] NULL,
 CONSTRAINT [PK_RSAF_ARCHIVE] PRIMARY KEY CLUSTERED 
(
	[DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RSAF_ARCHIVE]  WITH CHECK ADD  CONSTRAINT [FK_RSAF_ARCHIVE_DETAIL] FOREIGN KEY([DETAIL_ID])
REFERENCES [dbo].[RSAF_DETAIL] ([DETAIL_ID])
GO

ALTER TABLE [dbo].[RSAF_ARCHIVE] CHECK CONSTRAINT [FK_RSAF_ARCHIVE_DETAIL]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Detail Record Unique Identifier' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'DETAIL_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A type of sequence number but not unique' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'X'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Received Document' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'RECDOC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Despatched Part, now P/N EX R.O.S.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'DESPPART'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'RV REF: Many years ago. Ansty to repair piece part items. Route Card -> machining operation. History is interesting. Look back over time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'RVREF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ansty PSI, now R.I. Ref' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'ANSPSI'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ansty PSI, now R.I. Ref' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'ANSRVREF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Scrap reference, not used anymore' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'SCRPREF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Despatch part date? Not used anymore' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'DESPARDT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Received Part, now RR Rec’d P/N' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'RECDPART'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Not known, Not used anymore' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'INTOROS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ansty PSI Date, now “Date”' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'ANSPSIDT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Not known, Not used anymore' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'REF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Promise date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'PROMDATE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DM: Cost as Deutche Mark' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'RCD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Partner or Accessory Deutche Mark - Vendors costs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'ACC_DM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PREVIOUS PROMISE DATE: Add-on for consistance in promised dates.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RSAF_ARCHIVE', @level2type=N'COLUMN',@level2name=N'PREVIOUS_PROMISE_DATE'
GO

USE [RSAF_Prod] 
GO
CREATE VIEW [dbo].[RSAF_TABLE] AS
	SELECT M.[BAEPO]
		  ,D.[POITEM]
		  ,A.[X]
		  ,CAST(NULL AS NVARCHAR(3)) AS [dummy]
		  ,D.[PART_NO]
		  ,D.[SERIAL]
		  ,D.[QTYREC]
		  ,D.[WARR]
		  ,A.[RECDOC]
		  ,D.[OONUM]
		  ,D.[PSIREF]
		  ,M.[SITE]
		  ,A.[DESPPART]
		  ,A.[RVREF]
		  ,A.[ANSPSI]
		  ,A.[ANSRVREF]
		  ,D.[DESPTOBA]
		  ,D.[QTYSCRP]
		  ,A.[SCRPREF]
		  ,D.[REMARKS]
		  ,D.[RECDATE]
		  ,D.[PSIDATE]
		  ,A.[DESPARDT]
		  ,A.[RECDPART]
		  ,A.[INTOROS]
		  ,A.[ANSPSIDT]
		  ,D.[DESPDATE]
		  ,M.[BAEPART]
		  ,D.[BAEQTY]
		  ,D.[BAESER]
		  ,D.[BAESENT]
		  ,D.[OUTPART]
		  ,A.[REF]
		  ,M.[TYPE]
		  ,D.[PROMISE]
		  ,A.[PROMDATE]
		  ,D.[POIC]
		  ,D.[RCP]
		  ,A.[RCD]
		  ,D.[ARCHIVE]
		  ,D.[CTRT_DATE]
		  ,D.[MDR]
		  ,D.[QUOTE_REF]
		  ,D.[QUOTE_REF_DATE]
		  ,D.[INVOICE_PAID]
		  ,D.[INVOICE_REQUESTED]
		  ,D.[ENG_MARK]
		  ,D.[HOURS_NEW]
		  ,D.[HOURS_REP]
		  ,COALESCE(A.[DESCRIPTION],M.[DESCRIPTION]) AS [DESCRIPTION] 
		  ,D.[RFR]
		  ,D.[EX_ENGINE]
		  ,D.[MODULE_TEXT]
		  ,A.[ACC_DM]
		  ,D.[ACC_STG]
		  ,D.[EURO]
		  ,D.[PAEURO]
		  ,A.[PREVIOUS_PROMISE_DATE]
		  ,M.[ROID_NO]
		  ,D.[INVOICE_NO]
		  ,D.[SALES_DOCUMENT]
		  ,D.[VENDOR]
		  ,D.[VENDOR_COFC]
		  ,D.[VENDOR_MATERIAL_COST]
		  ,D.[VENDOR_LABOR_COST]
		  ,D.[PO_REQ]
		  ,D.[RR_PO]
		  ,D.[QUALITY_NO]
		  ,D.[SAP_SES]
		  ,D.[AWB_DETAILS]
		  ,D.[FLEX_DATE]
		  ,D.[FLEX1]
		  ,D.[FLEX2]
		  ,D.[FLEX3]
		  ,D.[FLEX4]
	  FROM [RSAF_Prod].[dbo].[RSAF_DETAIL] D
	  JOIN [RSAF_Prod].[dbo].[RSAF_MASTER] M
		ON D.MASTER_ID = M.MASTER_ID
 LEFT JOIN [RSAF_Prod].[dbo].[RSAF_ARCHIVE] A
        ON D.DETAIL_ID = A.DETAIL_ID
GO