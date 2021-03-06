--DATA QUALITY ISSUES


--1.There are 2records SITE or TYPE is null value
SELECT baepo,baepart, poitem,part_no, site,type,recdate 
FROM [RSAF2].[dbo].[RSAF TABLE] A
WHERE [SITE] IS NULL
SELECT baepo,baepart, poitem,part_no, site,type,recdate 
FROM [RSAF2].[dbo].[RSAF TABLE] A
where (baepo='65633' and baepart='JJ114437') or (baepo='197174' and baepart='JJ73147')
order by baepo,baepart,x
GO

--2.There is 1 record POITEM is null value
SELECT baepo,baepart, poitem,part_no, site,type,recdate
FROM [RSAF2].[dbo].[RSAF TABLE] A
WHERE [POITEM] IS NULL
SELECT baepo,baepart, poitem,part_no, site,type,recdate 
FROM [RSAF2].[dbo].[RSAF TABLE] A
where (baepo='4329' and baepart='01TV30100-04'
order by baepo,baepart,x
GO

--3.There is 1 record WARR is null value and 142 dependant records.
SELECT baepo,baepart, poitem,part_no, site,type,recdate,warr
FROM [RSAF2].[dbo].[RSAF TABLE] A
where (baepo='167141' and baepart='JJ49781')
order by baepo,baepart,x
SELECT baepo,baepart, poitem,part_no, site,type,recdate,warr
FROM [RSAF2].[dbo].[RSAF TABLE] A
WHERE [WARR] IS NULL
GO

--4.There are 197 records MDR is null value
SELECT baepo,baepart, poitem,part_no, site,type,recdate,MDR
FROM [RSAF2].[dbo].[RSAF TABLE] A
WHERE [MDR] IS NULL
GO

--5.There are 230  duplicates and 1422 dependant records in DETAIL. 
WITH UKEY AS(
SELECT DISTINCT
       [BAEPO]
      ,[BAEPART]
      ,[SITE]
      ,[TYPE]
      ,COALESCE([MDR],'N/A',[MDR]) AS MDR
  FROM [RSAF2].[dbo].[RSAF TABLE]),
BYDESC AS(
SELECT DISTINCT
       [BAEPO]
      ,[BAEPART]
      ,[SITE]
      ,[TYPE]
      ,COALESCE([MDR],'N/A',[MDR]) AS MDR
      ,[DESCRIPTION]
  FROM [RSAF2].[dbo].[RSAF TABLE]),
DUPLICATES AS(
SELECT U.[BAEPO]
      ,U.[BAEPART]
      ,U.[SITE]
      ,U.[TYPE]
      ,U.[MDR]
FROM UKEY U
JOIN BYDESC T
ON U.[BAEPO] = T.[BAEPO]
AND U.[BAEPART]= T.[BAEPART]
AND U.[SITE]= T.[SITE]
AND U.[TYPE]= T.[TYPE]
AND U.[MDR]=T.[MDR]
GROUP BY  U.[BAEPO],U.[BAEPART],U.[SITE],U.[TYPE],U.[MDR]
HAVING COUNT(*)>1)
--SELECT * FROM DUPLICATES
SELECT A.[BAEPO]
,A.[BAEPART]
,POITEM
,A.[SITE]
,A.[TYPE]
,RECDATE
,BAESER
,A.MDR
,DESCRIPTION
FROM [RSAF2].[dbo].[RSAF TABLE] A
JOIN DUPLICATES D
ON D.[BAEPO]=A.[BAEPO] 
AND D.[BAEPART]=A.[BAEPART]
AND D.[SITE]= A.[SITE]
AND D.[TYPE]= A.[TYPE] 
AND D.[MDR] = A.[MDR]
ORDER BY D.[BAEPO], D.[BAEPART], D.[SITE], D.[TYPE],A.[POITEM]
GO

--6.There are 36 duplicates and 414 dependant records in SITEWITH UKEY AS(
SELECT DISTINCT
       [BAEPO]
      ,[BAEPART]
  FROM [RSAF2].[dbo].[RSAF TABLE]),
BYDESC AS(
SELECT DISTINCT
       [BAEPO]
      ,[BAEPART]
	  ,[SITE]
  FROM [RSAF2].[dbo].[RSAF TABLE]),
DUPLICATES AS(
SELECT U.[BAEPO]
      ,U.[BAEPART]
FROM UKEY U
JOIN BYDESC T
ON U.[BAEPO] = T.[BAEPO]
AND U.[BAEPART]= T.[BAEPART]
GROUP BY  U.[BAEPO],U.[BAEPART]
HAVING COUNT(*)>1)
--SELECT * FROM DUPLICATES
SELECT A.[BAEPO]
,A.[BAEPART]
,POITEM
,A.[SITE]
,A.[TYPE]
,RECDATE
,BAESER
,A.MDR
,DESCRIPTION
FROM [RSAF2].[dbo].[RSAF TABLE] A
JOIN DUPLICATES D
ON D.[BAEPO]=A.[BAEPO] 
AND D.[BAEPART]=A.[BAEPART]
AND D.[SITE]= A.[SITE]
ORDER BY D.[BAEPO], D.[BAEPART], D.[SITE],A.X
GO

--7.There are 7 duplicates and 113 dependant records in TYPE
WITH UKEY AS(
SELECT DISTINCT
       [BAEPO]
      ,[BAEPART]
  FROM [RSAF2].[dbo].[RSAF TABLE]),
BYDESC AS(
SELECT DISTINCT
       [BAEPO]
      ,[BAEPART]
	  ,[TYPE]
  FROM [RSAF2].[dbo].[RSAF TABLE]),
DUPLICATES AS(
SELECT U.[BAEPO]
      ,U.[BAEPART]
FROM UKEY U
JOIN BYDESC T
ON U.[BAEPO] = T.[BAEPO]
AND U.[BAEPART]= T.[BAEPART]
GROUP BY  U.[BAEPO],U.[BAEPART]
HAVING COUNT(*)>1)
--SELECT * FROM DUPLICATES
SELECT A.[BAEPO]
,A.[BAEPART]
,POITEM
,A.[SITE]
,A.[TYPE]
,RECDATE
,BAESER
,A.MDR
,DESCRIPTION
FROM [RSAF2].[dbo].[RSAF TABLE] A
JOIN DUPLICATES D
ON D.[BAEPO]=A.[BAEPO] 
AND D.[BAEPART]=A.[BAEPART]
ORDER BY D.[BAEPO], D.[BAEPART],A.X
GO

--8.There are 162 duplicates and 708 dependant records in MDR
WITH UKEY AS(
SELECT DISTINCT
       [BAEPO]
      ,[BAEPART]
  FROM [RSAF2].[dbo].[RSAF TABLE]),
BYDESC AS(
SELECT DISTINCT
       [BAEPO]
      ,[BAEPART]
	  ,[TYPE]
  FROM [RSAF2].[dbo].[RSAF TABLE]),
DUPLICATES AS(
SELECT U.[BAEPO]
      ,U.[BAEPART]
FROM UKEY U
JOIN BYDESC T
ON U.[BAEPO] = T.[BAEPO]
AND U.[BAEPART]= T.[BAEPART]
GROUP BY  U.[BAEPO],U.[BAEPART]
HAVING COUNT(*)>1)
--SELECT * FROM DUPLICATES
SELECT A.[BAEPO]
,A.[BAEPART]
,POITEM
,A.[SITE]
,A.[TYPE]
,RECDATE
,BAESER
,A.MDR
,DESCRIPTION
FROM [RSAF2].[dbo].[RSAF TABLE] A
JOIN DUPLICATES D
ON D.[BAEPO]=A.[BAEPO] 
AND D.[BAEPART]=A.[BAEPART]
ORDER BY D.[BAEPO], D.[BAEPART],A.X