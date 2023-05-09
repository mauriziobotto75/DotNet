USE [COPIA_NSR_ATTIVAZIONE]
GO

/****** Object:  Schema [P2022]    Script Date: 20/10/2022 09:44:23 ******/
DROP SCHEMA [P2022]
GO

/****** Object:  Schema [P2022]    Script Date: 20/10/2022 09:44:23 ******/
CREATE SCHEMA [P2022]
GO

USE [NSR_INCENTIVAZIONE]
GO

/****** Object:  Table [P2022].[CONTEST_164_417_OUT]    Script Date: 02/08/2022 15:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[P2022].[CONTEST_164_417_OUT]') AND type in (N'U'))
DROP TABLE [P2022].[CONTEST_164_417_OUT]
GO

/****** Object:  Table [P2022].[CONTEST_164_417_OUT]    Script Date: 02/08/2022 15:20:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [P2022].[CONTEST_164_417_OUT](
	[DATA_RC] [int] NOT NULL,
	[INDICEAGGIORNAMENTO] [int] NOT NULL,
	[ANNO] [int] NOT NULL,
	[CODAGE] [varchar](6) NOT NULL,
	[NOMINATIVO_PB] [varchar](56) NULL,
	[AREA] [varchar](3) NULL,
	[GRADO] [varchar](4) NULL,
	[STATO] [varchar](1) NULL,
	[POSIZIONE] [int] NULL,
	[PUNTEGGIO] [int] NULL,
	[CODICEPREMIO] [varchar](100) NULL,
	[VALOREDENARO] [numeric](18, 2) NULL,
	[DATACALCOLO] [datetime] NULL,
	[OBIETTIVIRAGGIUNTI] [varchar](5) NULL,
	[CODICEGM] [varchar](6) NULL,
	[DESCRIZIONEGM] [varchar](56) NULL,
	[RNG_MNG] [numeric](38, 2) NULL,
	[PERC_CONF_MNG] [numeric](38, 2) NULL,
	[ObiettivoRNG_MNG] [numeric](38, 2) NULL,
	[ObiettivoPERC_CONF_MNG] [numeric](38, 2) NULL,
	[CancelloRNG_MNG] [numeric](38, 2) NULL,
	[CancelloPERC_CONF_MNG] [numeric](38, 2) NULL,
	[NUMEROCANCELLI] [int] NULL,
	[STATOCANCELLO] [varchar](5) NULL,
	[DataNascita] [int] NULL,
	[DataInizioProduzione] [int] NULL,
	[DataScadenzaIncentivazione] [int] NULL,
	[DataPreavviso] [int] NULL,
	[DataTerminazione] [int] NULL,
	[DataFine60Junior] [int] NULL,
	[TipoManager] [varchar](4) NOT NULL,
	[FlagHaAzienda] [varchar](1) NULL,
	[FlagHaArea] [varchar](1) NULL,
	[CodiceCategoria] [varchar](2) NULL,
	[NewMan] [int] NOT NULL,
	[NewTalent] [bit] NOT NULL,
	[Maglietta] [varchar](20) NULL,
	[RETE] [varchar](3) NOT NULL
) ON [PRIMARY]
GO

IF OBJECT_ID ('VW_CONTEST_NEVE_DM_2022','v') IS NOT NULL
BEGIN

	DROP VIEW VW_CONTEST_NEVE_DM_2022

END
GO
/****** Object:  View [dbo].[VW_CONTEST_NEVE_DM_2022]    Script Date: 30/06/2022 12:15:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/*
 ============================================================================
 Autore:			CAPGEMINI
 Data Creazione:	08/07/2022
 Descrizione:		Vista per SIMWEB contenente la classifica DM del
                    contest neve 2022
 ============================================================================
 Variazioni
 ============================================================================
 Ver.	Data        Autore  Descrizione
 ----	----------  ------  -------------------------------------------------
	1	08/07/2022	TDF		Primo rilascio
 ============================================================================
 Comando:

	SELECT * FROM dbo.VW_CONTEST_NEVE_DM_2022
	ORDER BY POSIZIONE_NAZIONALE
 ============================================================================
*/
CREATE VIEW [dbo].[VW_CONTEST_NEVE_DM_2022]
AS
	WITH dateRiferimento
	AS
	(
		SELECT 
			MAX(DATA_RC) AS DATA_RC 
		FROM 
			P2022.CONTEST_164_417_OUT
	),
	IndiceAggiornamento
	AS
	(
		SELECT 
			d.DATA_RC,
			MAX(INDICEAGGIORNAMENTO) AS INDICEAGGIORNAMENTO
		FROM 
			P2022.CONTEST_164_417_OUT o
			INNER JOIN dateRiferimento d ON	o.DATA_RC = d.DATA_RC
		GROUP BY
			d.DATA_RC
	)
	SELECT 
		CNT.CODAGE AS CODAGE,
		AGE.COGNOME,
		AGE.NOME,
		'DM' AS SIGLA_INCENTIVAZIONE,
		ROW_NUMBER() OVER(ORDER BY ISNULL(CNT.STATOCANCELLO,'KO') DESC,CNT.RNG_MNG DESC, AGE.DATINPRO , AGE.CODAGE )  AS POSIZIONE_NAZIONALE,
		CNT.POSIZIONE AS POSIZIONE_AREA,
		AGE.CODAREA AS AREA,
		CASE 
			WHEN ISNULL(CNT.CODICEPREMIO,'') <> '' THEN 'SI'
			ELSE 'NO'
		END AS PREMIO,
		CNT.ObiettivoRNG_MNG AS OBIETTIVO_RNG,
		CASE 
			WHEN ISNULL(CNT.STATOCANCELLO,'KO') = 'OK' THEN 'SI'
			ELSE 'NO'
		END AS CANCELLO_RNG,
		CNT.RNG_MNG AS INDICATORE_RNG,
		CAST(ISNULL(RAM_RNT.IMPORTO,0) AS NUMERIC(38, 2)) AS RNT,
		CAST(ISNULL(RAM_VAL.IMPORTO,0) AS NUMERIC(38, 2)) AS VAL,
		CNT.PERC_CONF_MNG AS PERC_CONF
	FROM
		P2022.CONTEST_164_417_OUT CNT 
		INNER JOIN IndiceAggiornamento i ON	CNT.DATA_RC = i.DATA_RC
											AND CNT.INDICEAGGIORNAMENTO = i.INDICEAGGIORNAMENTO
		LEFT OUTER JOIN MR_DataMart.AGENTE_2022 AS AGE	ON	CNT.CODAGE = AGE.CODAGE
															AND CNT.DATA_RC = AGE.DATA_RC
															AND CNT.INDICEAGGIORNAMENTO = AGE.INDICE_AGGIORNAMENTO
															AND CNT.RETE = AGE.RETE
		LEFT JOIN MR_DataMart.RACCOLTA_AGENTE_MISURE_2022 RAM_RNT ON	RAM_RNT.CODAGE = CNT.CODAGE
																		AND RAM_RNT.DATA_RC = CNT.DATA_RC
																		AND RAM_RNT.INDICE_AGGIORNAMENTO = CNT.INDICEAGGIORNAMENTO
																		AND RAM_RNT.COD_MISURA_CODIFICATA = 'RNT_EFF'  
																		AND RAM_RNT.RETE =  CNT.RETE
		LEFT JOIN MR_DataMart.RACCOLTA_AGENTE_MISURE_2022 RAM_VAL ON	RAM_VAL.CODAGE = CNT.CODAGE
																		AND RAM_VAL.DATA_RC = CNT.DATA_RC
																		AND RAM_VAL.INDICE_AGGIORNAMENTO = CNT.INDICEAGGIORNAMENTO
																		AND RAM_VAL.COD_MISURA_CODIFICATA = 'VAL'
																		AND RAM_VAL.RETE =  CNT.RETE
GO