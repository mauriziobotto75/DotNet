USE NSRFrontendWebMultiRete
GO

DELETE [dbo].[PbTargetOverSviluppo] WHERE DOMAIN_CODE = 1 AND COMPANY_CODE = 2

DECLARE @maxId INT
SELECT @maxId = MAX(ID) FROM [dbo].[PbTargetOverSviluppo]

DBCC CHECKIDENT ('[dbo].[PbTargetOverSviluppo]', RESEED, @maxId)

INSERT INTO [dbo].[PbTargetOverSviluppo]
(
	[MisuraId], 
	[AnnoIngresso], 
	[MeseDa], 
	[MeseA], 
	[FasciaDa], 
	[FasciaA], 
	[Cancello], 
	[DataInizio], 
	[DataFine], 
	[DOMAIN_CODE], 
	[COMPANY_CODE]
)
SELECT
	mIws.Id AS MisuraId, --tar.[MisuraId], 
	tar.[AnnoIngresso], 
	tar.[MeseDa], 
	tar.[MeseA], 
	tar.[FasciaDa], 
	tar.[FasciaA], 
	-99999999.99 AS Cacenllo, --tar.[Cancello], 
	tar.[DataInizio], 
	tar.[DataFine], 
	tar.[DOMAIN_CODE], 
	2 AS COMPANY_CODE --tar.[COMPANY_CODE]
FROM
	[dbo].[PbTargetOverSviluppo] tar
	INNER JOIN dbo.Misure m ON	tar.MisuraId = m.Id
	INNER JOIN dbo.Misure mIws ON	m.Codice = mIws.Codice
									AND mIws.DOMAIN_CODE = 1
									AND mIws.COMPANY_CODE = 2
WHERE
	'2022-01-01' BETWEEN tar.DataInizio AND tar.DataFine
	AND tar.DOMAIN_CODE = 1
	AND tar.COMPANY_CODE = 1
ORDER BY
	tar.AnnoIngresso
GO