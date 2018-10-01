--drop database [rsaf_dev];
create database [rsaf_dev]
go
--drop database [RSAF2];
create database [RSAF2]
go
use rsaf_dev
go
--drop table [tblTableList];
create table [tblTableList](
[Table Name] nvarchar(40),
[Source] nvarchar(20));
--drop table [Paste Errors];
create table [Paste Errors](
[Field0] ntext
);
--drop table [module TRT --2];
create table [module TRT --2](
[Year] bigint,
[M01] decimal(14,2),
[LPC] decimal(14,2),
[M02] decimal(14,2),
[IPC] decimal(14,2),
[M03] decimal(14,2),
[HPC] decimal(14,2),
[M04] decimal(14,2),
[Int Case] decimal(14,2),
[M05] decimal(14,2),
[BPD] decimal(14,2),
[M06] decimal(14,2),
[Can] decimal(14,2),
[M10] decimal(14,2),
[IPTR] decimal(14,2),
[M11] decimal(14,2),
[LPTS] decimal(14,2),
[M12] decimal(14,2),
[LPTR] decimal(14,2),
[M13] decimal(14,2),
[TC] decimal(14,2),
[M14] decimal(14,2),
[ED] decimal(14,2),
[M16] decimal(14,2),
[G/Box] decimal(14,2)
);
use RSAF2
go
--drop table [Conversion Errors];
create table [Conversion Errors] 
([Object Type] nvarchar(255),
[Object Name] nvarchar(255),
[Error Description] ntext);
--drop table [SITE CODES];
create table [SITE CODES](
[SITE] nvarchar(10),
[SITE CODE] nvarchar(1)
);
--drop table [CTRT_LOOKUP_TABLE];
create table [CTRT_LOOKUP_TABLE](
[MODULE NUMBER] INTEGER,
[DESCRIPTION] NVARCHAR(20),
[DAYS] INTEGER
);
--drop table [TRT CALCULATIONS];
CREATE TABLE [TRT CALCULATIONS](
[MODULE NO] INTEGER,
[3 Mdl Avge] INTEGER,
[LATEST TRT] INTEGER
);
--drop table [LUCAS TRT];
create table [LUCAS TRT](
[Month] datetime ,
[Cards] decimal(14,2),
[CardsAV] decimal(14,2),
[BS Act] decimal(14,2),
[BS ActAV] decimal(14,2),
[NCU] decimal(14,2),
[NCUAV] decimal(14,2),
[R/H FCU] decimal(14,2),
[R/H FCUAV] decimal(14,2),
[MFCU] decimal(14,2),
[MFCUAV] decimal(14,2),
[SOPDV] decimal(14,2),
[SOPDVAV] decimal(14,2),
[Noz G/Box] decimal(14,2),
[Noz G/BoxAV] decimal(14,2),
[Noz Act] decimal(14,2),
[Noz ActAV] decimal(14,2),
[T/R AM] decimal(14,2),
[T/R AMAV] decimal(14,2),
[120 DAY] decimal(14,2),
[90 DAY TARGET] decimal(14,2));
--drop table [module TRT];
create table [module TRT](
[Month] datetime,
[M01] decimal(14,2),
[LPC] decimal(14,2),
[M02] decimal(14,2),
[IPC] decimal(14,2),
[M03] decimal(14,2),
[HPC] decimal(14,2),
[M04]  decimal(14,2),
[Int Case]  decimal(14,2),
[M05]  decimal(14,2),
[BPD]  decimal(14,2),
[M06]  decimal(14,2),
[Can]  decimal(14,2),
[M10]  decimal(14,2),
[IPTR]  decimal(14,2),
[M11]  decimal(14,2),
[LPTS]  decimal(14,2),
[M12]  decimal(14,2),
[LPTR]  decimal(14,2),
[M13]  decimal(14,2),
[TC]  decimal(14,2),
[M14]  decimal(14,2),
[ED]  decimal(14,2),
[M16]  decimal(14,2),
[G/Box]  decimal(14,2)
);
--drop table [REPAIR QUOTES];
create table [REPAIR QUOTES](
[MONTH] datetime,
[DUE] decimal(14,2),
[ACH'D] decimal(14,2),
[QUOTED] decimal(14,2),
[DUE_CUM] decimal(14,2),
[ACH_CUM] decimal(14,2),
[ALL SITES QUOTED IN 60 DAYS %] decimal(14,2),
[BDUE] decimal(14,2),
[BACH'D] decimal(14,2),
[BQUOTED] decimal(14,2),
[BDUEC] decimal(14,2),
[BACHC] decimal(14,2),
[BRISTOL QUOTED IN 60 DAYS %] decimal(14,2),
[ADUE] decimal(14,2),
[AACH'D] decimal(14,2),
[AQUOTED] decimal(14,2),
[ADUEC] decimal(14,2),
[AACHC] decimal(14,2),
[ANSTY QUOTED IN 60 DAYS %] decimal(14,2),
[MDUE] decimal(14,2),
[MACH'D] decimal(14,2),
[MQUOTED] decimal(14,2),
[MDUEC] decimal(14,2),
[MACHC] decimal(14,2),
[MTU QUOTED IN 60 DAYS %] decimal(14,2),
[FDUE] decimal(14,2),
[FACH'D] decimal(14,2),
[FQUOTED] decimal(14,2),
[FDUEC] decimal(14,2),
[FACHC] decimal(14,2),
[FIAT QUOTED IN 60 DAYS %] decimal(14,2),
[SDUE] decimal(14,2),
[SACH'D] decimal(14,2),
[SQUOTED] decimal(14,2),
[SDUEC] decimal(14,2),
[SACHC] decimal(14,2),
[SUPPLIER QUOTED IN 60 DAYS %] decimal(14,2)
);
--drop table [REPAIR QUOTES 30 DAYS];
create table [REPAIR QUOTES 30 DAYS](
[MONTH] datetime,
[DUE] decimal(14,2),
[ACH'D] decimal(14,2),
[QUOTED] decimal(14,2),
[DUE_CUM] decimal(14,2),
[ACH_CUM] decimal(14,2),
[QUOTED IN 30 DAYS %] decimal(14,2)
);
--drop table [R-S-A-F REPAIRABLE LISTING (ISSUE 4)];
create table [R-S-A-F REPAIRABLE LISTING (ISSUE 4)](
[Part No] nvarchar(255),
[Description] nvarchar(255),
[Project] nvarchar(255),
[Fig] nvarchar(255),
[Ind] nvarchar(255),
[Fit] nvarchar(255),
[SDR] nvarchar(255)
);
--drop table [RSAF TABLE];
create table [RSAF TABLE](
[BAEPO] nvarchar(12),
[POITEM]nvarchar(8),
[X] bigint,
[dummy] nvarchar(3),
[PART_NO] nvarchar(15),
[SERIAL] nvarchar(10),
[QTYREC] decimal(14,2),
[WARR] nvarchar(1),
[RECDOC] nvarchar(12),
[OONUM] nchar(15),
[PSIREF]  nvarchar(17),
[SITE]  nvarchar(1),
[DESPPART] nvarchar(6),
[RVREF] nvarchar(7),
[ANSPSI] nvarchar(7),
[ANSRVREF] nvarchar(7),
[DESPTOBA] nvarchar(8),
[QTYSCRP] integer,
[SCRPREF] nvarchar(8),
[REMARKS] nvarchar(max),
[RECDATE] datetime,
[PSIDATE] datetime2,
[DESPARDT] datetime,
[RECDPART] datetime,
[INTOROS] datetime,
[ANSPSIDT] datetime,
[DESPDATE] datetime2,
[BAEPART] nvarchar(15),
[BAEQTY] integer,
[BAESER] nvarchar(15),
[BAESENT] datetime,
[OUTPART] nvarchar(15),
[REF] nvarchar(17),
[TYPE] nvarchar(1),
[PROMISE] datetime,
[PROMDATE] datetime,
[POIC] nvarchar(1),
[RCP] decimal(14,2),
[RCD] decimal(14,2),
[ARCHIVE]  nvarchar(5),
[CTRT DATE] datetime,
[MDR] nvarchar(12),
[QUOTE REF] nvarchar(25),
[QUOTE REF DATE] datetime,
[INVOICE PAID]  nvarchar(3),
[INVOICE REQUESTED] datetime,
[ENG MARK] integer,
[HOURS NEW] integer,
[HOURS REP] nvarchar(10),
[DESCRIPTION] nvarchar(255),
[RFR] nvarchar(250),
[EX ENGINE] integer,
[MODULE TEXT] nvarchar(255),
[ACC DM] decimal(14,2),
[ACC STG] decimal(14,2),
[EURO] decimal(14,2),
[PAEURO] decimal(14,2),
[PREVIOUS PROMISE DATE] datetime2
);
--drop table [TOTLUCASTRT];
create table [TOTLUCASTRT](
[Month] datetime,
[Cards] decimal(14,2),
[CardsAV] decimal(14,2),
[BS Act] decimal(14,2),
[BS ActAV] decimal(14,2),
[NCU] decimal(14,2),
[NCUAV] decimal(14,2),
[R/H FCU] decimal(14,2),
[R/H FCUAV] decimal(14,2),
[MFCU] decimal(14,2),
[MFCUAV] decimal(14,2),
[SOPDV] decimal(14,2),
[SOPDVAV] decimal(14,2),
[Noz G/Box] decimal(14,2),
[Noz G/BoxAV] decimal(14,2),
[Noz Act] decimal(14,2),
[Noz ActAV] decimal(14,2),
[T/R AM] decimal(14,2),
[T/R AMAV] decimal(14,2));
--drop table [totmodtrt];
create table[totmodtrt](
[Month] datetime,
[M01] decimal(14,2),
[LPC] decimal(14,2),
[M02] decimal(14,2),
[IPC] decimal(14,2),
[M03] decimal(14,2),
[HPC] decimal(14,2),
[M04] decimal(14,2),
[Int Case] decimal(14,2),
[M05] decimal(14,2),
[BPD] decimal(14,2),
[M06] decimal(14,2),
[Can] decimal(14,2),
[M10] decimal(14,2),
[IPTR] decimal(14,2),
[M11] decimal(14,2),
[LPTS] decimal(14,2),
[M12] decimal(14,2),
[LPTR] decimal(14,2),
[M13] decimal(14,2),
[TC] decimal(14,2),
[M14] decimal(14,2),
[ED] decimal(14,2),
[M16] decimal(14,2),
[G/Box] decimal(14,2)
);
-- drop table [TRANSIENT];
create table [TRANSIENT](
[TOTAL DESP] bigint,
[DESP LATE] bigint,
[TOTAL HELD] bigint,
[THIS MONTH] bigint,
[O/DUE] bigint,
[MODULE No] nvarchar(255),
[DESPDATE] datetime,
[TRT] decimal(14,2)
);