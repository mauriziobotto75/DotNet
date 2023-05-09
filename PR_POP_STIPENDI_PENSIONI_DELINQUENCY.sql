 USE [NSR_Operazionale_BF_2022]
GO
/****** Object:  StoredProcedure [Classifica].[PR_POP_STIPENDI_PENSIONI]    Script Date: 03/11/2022 09:40:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
============================================================================
Autore:			CADIT
Data Creazione:	22/06/2021
Descrizione:	Popolamento delle tabelle per l'INCENTIVAZIONE 
				CANALIZZAZIONE STIPENDI E PENSIONI
============================================================================
Parametri:
============================================================================
Tabelle Gestite:
============================================================================
Variazioni
============================================================================
Ver.  Data        Autore  Descrizione
----  ----------  ------  --------------------------------------------------
   1  22/06/2021  SB      Primo Rilascio
============================================================================
Comando: 
	EXEC Classifica.PR_POP_STIPENDI_PENSIONI
============================================================================
*/
ALTER PROCEDURE [Classifica].[PR_POP_STIPENDI_PENSIONI] 
AS
BEGIN
	SET NOCOUNT ON;

	/*******Recupero AnnoRc******/
	DECLARE 
		@AnnoRC INT,
		@DataRC INT,
		@IndiceAggiornamento INT,
		@DataInizioAnno INT,
		@DataInizioEsclusioni INT,
		@DataFineAnnoPrecedente INT,
		@DataFineMeseRC INT,
		@NomeDbAnnoPrecedente VARCHAR(100) = '',
		@NomeDbAnnoCorrente VARCHAR(100) = '',
		@ImportoMinimoRata NUMERIC(38,2)=1000,
		@Sql AS NVARCHAR(MAX),
		@Parameters AS NVARCHAR(MAX)='',
		@Rete AS VARCHAR(10),
		@SuffissoRete AS VARCHAR(10)='',
		@BFLinkAnnoPrecedente AS VARCHAR(200),
		@BFLinkAnnoCorrente AS VARCHAR(200),
		@SPILinkAnnoPrecedente AS VARCHAR(200),
		@SPILinkAnnoCorrente AS VARCHAR(200),
		@multiRete AS VARCHAR(3),
		@ambiente AS VARCHAR(100),
		@linkedServer VARCHAR(MAX) = ''

	SELECT 
		@Rete=CS.BANK_PREFIX, -- BF, SPI
		@AnnoRC = CS.ANNO_RC,
		@DataRC = CS.DATA_RC,
		@IndiceAggiornamento = CS.INDICE_AGGIORNAMENTO,
		@DataInizioAnno = CS.ANNO_RC * 10000 + 101,
		@DataInizioEsclusioni = (CS.ANNO_RC-1) * 10000 + 901,
		@DataFineAnnoPrecedente = (CS.ANNO_RC-1) * 10000 + 1231,
		@multiRete = LIRR.RETE,
		@ambiente = CS.AMBIENTE,
		@linkedServer = CS.LS_SPI_I2 
	FROM 
		dbo.CONFIGURAZIONE_SISTEMA AS CS (NOLOCK)
		CROSS APPLY dbo.LOCAL_ID_REG_RC AS LIRR (NOLOCK)

	SELECT @DataFineMeseRC = NSRFrontendWebMultiRete.COMUNE.fn_DATA_FINE_MESE(@DataRC)

	SELECT 
		@NomeDbAnnoPrecedente = ISNULL(DatabaseName,'')
	FROM 
		NSRFrontendWebMultiRete.LancioRC.RegoleRendicontazione RR (NOLOCK)
		INNER JOIN NSRFrontendWebMultiRete.dbo.JFTDOMAIN_COMPANY JC (NOLOCK)	ON	RR.DOMAIN_CODE = JC.DOMAIN_CODE	
																					AND RR.COMPANY_CODE = JC.CODE
																					AND JC.DESCRIPTION = @multiRete
	WHERE TipoRendicontazione='A'
		AND Anno=@AnnoRC - 1
		AND Usato=1

	SELECT 
		@NomeDbAnnoCorrente = ISNULL(DatabaseName,'')
	FROM 
		NSRFrontendWebMultiRete.LancioRC.RegoleRendicontazione RR (NOLOCK)
		INNER JOIN NSRFrontendWebMultiRete.dbo.JFTDOMAIN_COMPANY JC (NOLOCK)	ON	RR.DOMAIN_CODE = JC.DOMAIN_CODE	
																					AND RR.COMPANY_CODE = JC.CODE
																					AND JC.DESCRIPTION = @multiRete
	WHERE RR.TipoRendicontazione='A'
		AND RR.Anno=@AnnoRC
		AND RR.Usato=1

	IF @Rete='BF' 
	BEGIN
		SET @SuffissoRete = ''
	END
	ELSE IF @Rete='SPI' 
	BEGIN
		SET @SuffissoRete = 'SPI'
	END

	IF @Rete='BF' 
	BEGIN
		SELECT 
			@SPILinkAnnoCorrente = @linkedServer + '.' + REPLACE(@NomeDbAnnoCorrente, 'BF', 'SPI'),
			@SPILinkAnnoPrecedente = @linkedServer + '.' + REPLACE(@NomeDbAnnoPrecedente, 'BF', 'SPI'),
			@BFLinkAnnoCorrente = @NomeDbAnnoCorrente,
			@BFLinkAnnoPrecedente = @NomeDbAnnoPrecedente,
			@SuffissoRete = ''
	END
	ELSE IF @Rete='SPI' 
	BEGIN
		SELECT 
			@BFLinkAnnoCorrente = @linkedServer + '.' + REPLACE(@NomeDbAnnoCorrente, 'SPI', 'BF'),
			@BFLinkAnnoPrecedente = @linkedServer + '.' + REPLACE(@NomeDbAnnoPrecedente, 'SPI', 'BF'),
			@SPILinkAnnoCorrente = @NomeDbAnnoCorrente,
			@SPILinkAnnoPrecedente = @NomeDbAnnoPrecedente,
			@SuffissoRete = 'SPI'
	END

	PRINT '@Rete            		:' + ISNULL(@Rete,'')
	PRINT '@SuffissoRete      		:' + ISNULL(@SuffissoRete,'')
	PRINT '@AnnoRC 					:' + CAST(@AnnoRC 				  AS VARCHAR(10))
	PRINT '@DataRC 					:' + CAST(@DataRC 				  AS VARCHAR(10))
	PRINT '@IndiceAggiornamento 	:' + CAST(@IndiceAggiornamento 	  AS VARCHAR(10))
	PRINT '@DataInizioAnno 			:' + CAST(@DataInizioAnno 		  AS VARCHAR(10))
	PRINT '@DataInizioEsclusioni 	:' + CAST(@DataInizioEsclusioni   AS VARCHAR(10))
	PRINT '@DataFineAnnoPrecedente  :' + CAST(@DataFineAnnoPrecedente AS VARCHAR(10))
	PRINT '@NomeDbAnnoPrecedente	:' + ISNULL(@NomeDbAnnoPrecedente,'')
	PRINT '@NomeDbAnnoCorrente		:' + ISNULL(@NomeDbAnnoCorrente,'')
	--PRINT '@BFLink            		:' + ISNULL(@BFLink,'')
	--PRINT '@SPILink           		:' + ISNULL(@SPILink,'')
	--PRINT '@DataFineMeseRC			:' + CAST(@DataFineMeseRC		 AS VARCHAR(10))
	/****************************/

	/********************************Cancellazione tabelle temporanee*******************************/
	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Classifica.TEMP_MOVIMENTI_STIPENDI_PENSIONI') AND type in (N'U'))
		BEGIN
			DROP TABLE Classifica.TEMP_MOVIMENTI_STIPENDI_PENSIONI
		END 

	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Classifica.TEMP_STIPENDI_PENSIONI') AND type in (N'U'))
		BEGIN
			DROP TABLE Classifica.TEMP_STIPENDI_PENSIONI
		END 

	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Classifica.TEMP_ClientiConCanalizzazioneAnnoPrecedente') AND type in (N'U'))
		BEGIN
			DROP TABLE Classifica.TEMP_ClientiConCanalizzazioneAnnoPrecedente
		END 

	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Classifica.TEMP_ClientiConRataInsufficiente') AND type in (N'U'))
		BEGIN
			DROP TABLE Classifica.TEMP_ClientiConRataInsufficiente
		END 

	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Classifica.CLIENTI_AnagraficheModificate') AND type IN (N'U'))
		BEGIN
			DROP TABLE Classifica.CLIENTI_AnagraficheModificate
		END 

	PRINT '/********************************Aggiornamento dati cliente*******************************/'

	SELECT @Sql ='
		SELECT DISTINCT
			H.HANAG' + @SuffissoRete + '_ANAOLD AS CODANA_OLD,
			H.HANAG' + @SuffissoRete + '_ANANEW AS CODANA_NEW,
			C.COGNOME,
			C.NOME,
			C.DTNAS,
			C.ID_CLIENTE AS ID_CLIENTE_NEW,
			C.CDFIS AS CDFIS_NEW
		INTO Classifica.CLIENTI_AnagraficheModificate
		FROM
			NSR_STAGING.dbo.HANAG' + @SuffissoRete + ' AS H
			INNER JOIN 
			(
				SELECT
					ROW_NUMBER() OVER (PARTITION BY H.HANAG' + @SuffissoRete + '_ANAOLD ORDER BY H.HANAG' + @SuffissoRete + '_ANAOLD, H.HANAG' + @SuffissoRete + '_DATANEW DESC, H.HANAG' + @SuffissoRete + '_ORANEW DESC) AS ROW_ID,
					*
				FROM
					NSR_STAGING.dbo.HANAG' + @SuffissoRete + ' AS H
				WHERE
					H.HANAG' + @SuffissoRete + '_TAB = ''ANCLI''
					AND H.HANAG' + @SuffissoRete + '_ANANEW = ''''
					AND H.HANAG' + @SuffissoRete + '_DATANEW >= ' + CAST(@DataInizioAnno AS VARCHAR(10)) + '
			) AS B ON     B.HANAG' + @SuffissoRete + '_CODCONF = H.HANAG' + @SuffissoRete + '_CODCONF
			INNER JOIN dbo.CLIENTE AS C	ON C.CODANA = H.HANAG' + @SuffissoRete + '_ANANEW
		WHERE
			H.HANAG' + @SuffissoRete + '_TAB = ''ANCON''
			AND H.HANAG' + @SuffissoRete + '_DATANEW >= ' + CAST(@DataInizioAnno AS VARCHAR(10)) + '
			AND B.ROW_ID = 1
		'
	PRINT '@Sql = ' + @Sql
	EXECUTE (@Sql)

	UPDATE
		CSP 
	SET CSP.ID_CLIENTE = CAM.ID_CLIENTE_NEW,
		CSP.CODANA = CAM.CODANA_NEW,
		CSP.CDFIS = CAM.CDFIS_NEW,
		CSP.COGNOME = CAM.COGNOME,
		CSP.NOME = CAM.NOME,
		CSP.DTNAS = CAM.DTNAS
	FROM 
		Classifica.CLIENTI_AnagraficheModificate CAM
		INNER JOIN Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP ON CSP.CODANA=CAM.CODANA_OLD
																	AND CSP.DATA_RC=@DataRC
																	AND CSP.INDICE_AGGIORNAMENTO=@IndiceAggiornamento

	/********************************Popolamento tabella temporanea*******************************/
	-- Va capito se il popolamento deve valere solo per il 2021
	SELECT 
        C.ID_CLIENTE,
        C.CODANA,
        C.COGNOME,
        C.NOME,
        C.DTNAS,
        C.SEX,
        C.CMNAS,
        C.CDFIS,
        C.COD_TIPO_CLI,
	    SUM(RD.RCDMCC_IMPORTO) AS IMPORTO,
        VC.COAG_CODAGE AS CODAGE_ORIGINALE,
        VC.COAG_CODAGE AS CODAGE,
        '' AS TIPAGE,
		CAST(RD.RCDMCC_DTINCEN / 100 AS INT) AS DTMOV,
		0 AS ID_ESCLUSIONE,
		@AnnoRC AS ANNO,
		@DataRC AS DATA_RC,
		@IndiceAggiornamento AS INDICE_AGGIORNAMENTO
	INTO Classifica.TEMP_MOVIMENTI_STIPENDI_PENSIONI
	FROM
		dbo.RCDMCC_DIRETTA AS RD
		INNER JOIN dbo.CONTRATTI_RC AS CR ON    CR.CODCONF = RD.RCDMCC_CODCONF
		INNER JOIN dbo.CLIENTE AS C ON    C.ID_CLIENTE = CR.ID_CLIENTE
																AND C.SEX IN ('F', 'M')
		INNER JOIN dbo.VW_COAG AS VC ON   RD.RCDMCC_CODCONF = VC.COAG_CODCONF
																AND @DataRC BETWEEN VC.COAG_DVALINI AND VC.COAG_DVALFIN
																AND VC.COAG_TIPAGE IN (1, 3) -- ??????
		LEFT OUTER JOIN Classifica.PERIMETRO_PAC AS PP ON	C.CDFIS = PP.CODFIS -- Solo per CF del PB
															AND PP.ESCLUSO=0
	WHERE
		RD.RCDMCC_DTINCEN BETWEEN @DataInizioAnno AND @DataRC
		AND RD.RCDMCC_CAUSALE = '830'
		AND RD.RCDMCC_CACLI NOT IN ('49','31','40','41','46','54','65')
		AND PP.CODAGE IS NULL
	GROUP BY         
		C.ID_CLIENTE,
        C.CODANA,
        C.COGNOME,
        C.NOME,
        C.DTNAS,
        C.SEX,
        C.CMNAS,
        C.CDFIS,
        C.COD_TIPO_CLI,
        VC.COAG_CODAGE,
		CAST(RD.RCDMCC_DTINCEN / 100 AS INT)

	-- Aggiornamento del CODAGE assegnato tramite eccezione
	UPDATE A
	SET A.CODAGE = ISNULL(B.CODAGE_NUOVO,A.CODAGE) 
	FROM 
		Classifica.TEMP_MOVIMENTI_STIPENDI_PENSIONI A
		INNER JOIN Classifica.SEP_ECCEZIONI_CLIENTE B ON B.ID_CLIENTE = A.ID_CLIENTE
	WHERE 
		B.CODAGE_NUOVO IS NOT NULL 
	---------------------------------

	SELECT DISTINCT 
        ID_CLIENTE,
        CODANA,
        COGNOME,
        NOME,
        DTNAS,
        SEX,
        CMNAS,
        CDFIS,
        COD_TIPO_CLI,
        CODAGE_ORIGINALE,
        CODAGE,
        TIPAGE,
		@AnnoRC AS ANNO_1,
		@AnnoRC + 1 AS ANNO_2,
		@AnnoRC + 2 AS ANNO_3,
		CAST(0 AS INT) AS NUM_RATE_ANNO_1,
		CAST(0 AS INT) AS NUM_RATE_ANNO_2,
		CAST(0 AS INT) AS NUM_RATE_ANNO_3,
		CAST(0 AS INT) AS DATA_PRIMO_VERSAMENTO,
		CAST(0 AS INT) AS NUM_RATE_ATTESE_ANNO_1,
		CAST(0 AS INT) AS NUM_RATE_ATTESE_ANNO_2,
		CAST(0 AS INT) AS NUM_RATE_ATTESE_ANNO_3,
		CAST(0 AS INT) AS NUM_RATE_INSUFF_ANNO_2,
		CAST(0 AS INT) AS NUM_RATE_INSUFF_ANNO_3,
        ID_ESCLUSIONE,
		CAST(0 AS INT) AS FLAG_DELINQUENCY_ANNO_2,
		CAST(0 AS INT) AS FLAG_DELINQUENCY_ANNO_3,
        DATA_RC,
        INDICE_AGGIORNAMENTO
	INTO Classifica.TEMP_STIPENDI_PENSIONI	
	FROM
		Classifica.TEMP_MOVIMENTI_STIPENDI_PENSIONI
	
	/*
	DOMINIO ESCLUSIONI:
		0 : NON ESCLUSO
		1 : Cliente Con Canalizzazione Anno Precedente
		2 : Almeno una rata di importo inferiore al minimo stabilito
		3 : Il Numero di rate versate è insufficiente
	*/

	PRINT '/**********************Popolamento tabella temporanea esclusione anno prec*********************/'
	-- Da escludere perchè hanno iniziato a canalizzare dall'anno precedente
	IF ISNULL(@NomeDbAnnoPrecedente,'') <> ''
	BEGIN
		IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Classifica.SEP_ClientiConCanalizzazioneAnnoPrecedente') AND type in (N'U'))
		BEGIN
			DROP TABLE Classifica.SEP_ClientiConCanalizzazioneAnnoPrecedente
		END 

		SELECT @Sql ='
			SELECT DISTINCT
				CR.ID_CLIENTE,
				C.CDFIS AS CODFIS,
				' + CAST((@AnnoRC -1) AS VARCHAR(5)) + ' AS ANNO_PREC,
				' + CAST((@AnnoRC) AS VARCHAR(5)) + ' AS ANNO,
				' + CAST(@DataRC AS VARCHAR(10)) + ' AS DATA_RC
			INTO Classifica.SEP_ClientiConCanalizzazioneAnnoPrecedente
			FROM
				' + @BFLinkAnnoPrecedente + '.dbo.RCDMCC_DIRETTA AS RD
				INNER JOIN ' + @BFLinkAnnoPrecedente + '.dbo.CONTRATTI_RC AS CR ON CR.CODCONF = RD.RCDMCC_CODCONF
				--INNER JOIN ' + @BFLinkAnnoPrecedente + '.dbo.CLIENTE AS C ON C.ID_CLIENTE = CR.ID_CLIENTE
				INNER JOIN ' + @BFLinkAnnoCorrente + '.dbo.CLIENTE AS C ON C.ID_CLIENTE = CR.ID_CLIENTE
																			AND C.SEX IN (''F'', ''M'')
				INNER JOIN ' + @BFLinkAnnoPrecedente + '.dbo.VW_COAG AS VC ON RD.RCDMCC_CODCONF = VC.COAG_CODCONF
																AND ' + CAST(@DataFineAnnoPrecedente AS VARCHAR(10)) + ' BETWEEN VC.COAG_DVALINI AND VC.COAG_DVALFIN 
																AND VC.COAG_TIPAGE IN (1, 3) 
				/*LEFT OUTER JOIN ' + @BFLinkAnnoCorrente + '.Classifica.PERIMETRO_PAC AS PP ON C.CDFIS = PP.CODFIS 
																										AND PP.ESCLUSO = 0*/
			WHERE
				RD.RCDMCC_DTINCEN BETWEEN ' + CAST(@DataInizioEsclusioni AS VARCHAR(10)) + ' AND ' + CAST(@DataFineAnnoPrecedente AS VARCHAR(10)) + '
				AND RD.RCDMCC_CAUSALE = ''830''
				----AND RD.RCDMCC_CACLI NOT IN (''49'',''31'',''40'',''41'',''46'',''54'',''65'') -- condizione esclusa su indicazione di Silvia Onorati
				--AND PP.CODAGE IS NULL
			UNION
			SELECT DISTINCT
				CR.ID_CLIENTE,
				C.CDFIS AS CODFIS,
				' + CAST((@AnnoRC -1) AS VARCHAR(5)) + ' AS ANNO_PREC,
				' + CAST((@AnnoRC) AS VARCHAR(5)) + ' AS ANNO,
				' + CAST(@DataRC AS VARCHAR(10)) + ' AS DATA_RC
			FROM
				' + @SPILinkAnnoPrecedente + '.dbo.RCDMCC_DIRETTA AS RD
				INNER JOIN ' + @SPILinkAnnoPrecedente + '.dbo.CONTRATTI_RC AS CR ON CR.CODCONF = RD.RCDMCC_CODCONF
				--INNER JOIN ' + @SPILinkAnnoPrecedente + '.dbo.CLIENTE AS C ON C.ID_CLIENTE = CR.ID_CLIENTE
				INNER JOIN ' + @SPILinkAnnoCorrente + '.dbo.CLIENTE AS C ON C.ID_CLIENTE = CR.ID_CLIENTE
																			AND C.SEX IN (''F'', ''M'')
				INNER JOIN ' + @SPILinkAnnoPrecedente + '.dbo.VW_COAG AS VC ON RD.RCDMCC_CODCONF = VC.COAG_CODCONF
																AND ' + CAST(@DataFineAnnoPrecedente AS VARCHAR(10)) + ' BETWEEN VC.COAG_DVALINI AND VC.COAG_DVALFIN 
																AND VC.COAG_TIPAGE IN (1, 3) 
				/*LEFT OUTER JOIN ' + @SPILinkAnnoCorrente + '.Classifica.PERIMETRO_PAC AS PP ON C.CDFIS = PP.CODFIS 
																										AND PP.ESCLUSO = 0*/
			WHERE
				RD.RCDMCC_DTINCEN BETWEEN ' + CAST(@DataInizioEsclusioni AS VARCHAR(10)) + ' AND ' + CAST(@DataFineAnnoPrecedente AS VARCHAR(10)) + '
				AND RD.RCDMCC_CAUSALE = ''830''
				----AND RD.RCDMCC_CACLI NOT IN (''49'',''31'',''40'',''41'',''46'',''54'',''65'') -- condizione esclusa su indicazione di Silvia Onorati
				--AND PP.CODAGE IS NULL
		'
		PRINT '@Sql = ' + @Sql
		EXECUTE (@Sql)
		-- probabilmente vanno eliminati i clienti con anno <> anno_1
	END

	PRINT '/**********************Popolamento tabella esclusione rata insuff*********************/'
	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Classifica.SEP_ClientiConRataInsufficiente') AND type in (N'U'))
	BEGIN
		DROP TABLE Classifica.SEP_ClientiConRataInsufficiente
	END 
	-- Da escludere perchè hanno almeno una rata di importo insufficiente
	SELECT DISTINCT
		ID_CLIENTE,
		CDFIS AS CODFIS,
		COUNT(*) AS NUM_RATE_INSUFF,
		CAST(DTMOV / 100 AS INT) AS ANNO
	INTO Classifica.SEP_ClientiConRataInsufficiente
	FROM
		Classifica.TEMP_MOVIMENTI_STIPENDI_PENSIONI
	WHERE
		IMPORTO < @ImportoMinimoRata
		AND @AnnoRC = CAST(DTMOV / 100 AS INT)
	GROUP BY ID_CLIENTE, CDFIS, CAST(DTMOV / 100 AS INT)
	/*********************************************************************************************/

	-- Se non esiste la tabella clienti con rata insufficiente la creo, altrimenti viene aggiornato lo storico
	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Classifica.SEP_ClientiConRataInsufficiente') AND type in (N'U'))
	BEGIN
		IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Classifica.SEP_ClientiConRataInsufficiente_STORICO') AND type in (N'U'))
		BEGIN
			SELECT * 
			INTO Classifica.SEP_ClientiConRataInsufficiente_STORICO
			FROM Classifica.SEP_ClientiConRataInsufficiente			
		END 
		ELSE 
		BEGIN
			-- elimino dallo storico i clienti dell'anno corrente
			DELETE B
			FROM 
				Classifica.SEP_ClientiConRataInsufficiente_STORICO B 
			WHERE
				B.ANNO = @AnnoRC

			INSERT INTO Classifica.SEP_ClientiConRataInsufficiente_STORICO
			SELECT * FROM Classifica.SEP_ClientiConRataInsufficiente WHERE ANNO=@AnnoRC
		END
	END 
	ELSE
	BEGIN
		PRINT 'La tabella Classifica.SEP_ClientiConRataInsufficiente NON esiste e deve essere creata.'

		CREATE TABLE [Classifica].[SEP_ClientiConRataInsufficiente]
		(
		[ID_CLIENTE] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
		[CODFIS] [varchar] (16) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
		[NUM_RATE_INSUFF] [int] NULL,
		[ANNO] [int] NULL
		) ON [PRIMARY]
	END

	-- Storicizzazione della SEP_ClientiConCanalizzazioneAnnoPrecedente
	IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Classifica.SEP_ClientiConCanalizzazioneAnnoPrecedente') AND type in (N'U'))
	BEGIN
		IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Classifica.SEP_ClientiConCanalizzazioneAnnoPrecedente_Storico') AND type in (N'U'))
		BEGIN
			SELECT * 
			INTO Classifica.SEP_ClientiConCanalizzazioneAnnoPrecedente_Storico
			FROM Classifica.SEP_ClientiConCanalizzazioneAnnoPrecedente			
		END 
		ELSE 
		BEGIN
			DELETE Classifica.SEP_ClientiConCanalizzazioneAnnoPrecedente_Storico
			WHERE ANNO = @AnnoRC

			INSERT INTO Classifica.SEP_ClientiConCanalizzazioneAnnoPrecedente_Storico
			SELECT * FROM Classifica.SEP_ClientiConCanalizzazioneAnnoPrecedente WHERE ANNO = @AnnoRC
		END
	END
	ELSE
	BEGIN
		PRINT 'La tabella Classifica.SEP_ClientiConCanalizzazioneAnnoPrecedente NON esiste e deve essere creata.'

		CREATE TABLE [Classifica].[SEP_ClientiConCanalizzazioneAnnoPrecedente]
		(
		[ID_CLIENTE] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
		[CODFIS] [varchar] (16) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
		[ANNO_PREC] [int] NOT NULL,
		[ANNO] [int] NOT NULL,
		[DATA_RC] [int] NOT NULL
		) ON [PRIMARY]	
	END

	UPDATE TSP
	--SET DATA_PRIMO_VERSAMENTO = (SELECT MIN(DATAMOV) FROM Classifica.TEMP_MOVIMENTI_STIPENDI_PENSIONI B WHERE B.ID_CLIENTE = TSP.id_CLIENTE AND B.ANNO= TSP.ANNO)
	SET DATA_PRIMO_VERSAMENTO = (SELECT MIN(DTMOV) FROM Classifica.TEMP_MOVIMENTI_STIPENDI_PENSIONI B WHERE B.ID_CLIENTE = TSP.id_CLIENTE AND B.ANNO= TSP.ANNO_1)
	FROM 
		Classifica.TEMP_STIPENDI_PENSIONI TSP

	UPDATE TSP
	--SET TSP.NUM_RATE_ATTESE_ANNO_1 = (@DataRC/100) - (DATA_PRIMO_VERSAMENTO) + CASE WHEN @DataRC = @AnnoRC * 10000 + 1231 THEN 1 ELSE 0 END 
	SET TSP.NUM_RATE_ATTESE_ANNO_1 = (@DataRC/100) - (DATA_PRIMO_VERSAMENTO) + CASE WHEN @DataRC = @DataFineMeseRC THEN 1 ELSE 0 END 
	FROM 
		Classifica.TEMP_STIPENDI_PENSIONI TSP

	PRINT '/**************************Aggiornamento Esclusioni sulle temporanee****************************/'
	UPDATE A
	SET ID_ESCLUSIONE=1		
	FROM 
		Classifica.TEMP_STIPENDI_PENSIONI A
		INNER JOIN Classifica.SEP_ClientiConCanalizzazioneAnnoPrecedente B ON --B.ID_CLIENTE = A.ID_CLIENTE
																				B.CODFIS = A.CDFIS

	WHERE
		A.ID_ESCLUSIONE=0

	UPDATE A
	SET ID_ESCLUSIONE=2
	FROM 
		Classifica.TEMP_STIPENDI_PENSIONI A
		INNER JOIN Classifica.SEP_ClientiConRataInsufficiente B ON	--B.ID_CLIENTE = A.ID_CLIENTE
																	B.CODFIS = A.CDFIS
																	AND B.ANNO = A.ANNO_1
	WHERE
		A.ID_ESCLUSIONE=0

	-- Aggiornamento delle esclusioni assegnate tramite eccezione
	UPDATE A
	SET ID_ESCLUSIONE = CASE WHEN B.FLAG_ESCLUSO = 0 THEN 0 ELSE 4 END 
	FROM 
		Classifica.TEMP_STIPENDI_PENSIONI A
		INNER JOIN Classifica.SEP_ECCEZIONI_CLIENTE B ON B.ID_CLIENTE = A.ID_CLIENTE
	WHERE 
		B.FLAG_ESCLUSO IS NOT NULL 

	PRINT '/***********************Aggiornamento Tabella Definitiva Movimenti******************************/'
	IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI') AND type in (N'U'))
	BEGIN
		SELECT * 
		INTO Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI
		FROM Classifica.TEMP_MOVIMENTI_STIPENDI_PENSIONI
	END 
	ELSE
	BEGIN
		/*DELETE M
		FROM
			Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI M
			INNER JOIN Classifica.TEMP_MOVIMENTI_STIPENDI_PENSIONI T ON M.ID_CLIENTE = T.ID_CLIENTE
																		AND M.DTMOV = T.DTMOV*/

		DELETE  Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI
		WHERE DATA_RC >= @AnnoRC * 10000 + 101

		INSERT INTO Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI
		SELECT * FROM Classifica.TEMP_MOVIMENTI_STIPENDI_PENSIONI
		
	END 
    
	PRINT '/*********************Inserimento in tabella definitiva CLIENTI*************************/'
	IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Classifica.SEP_CLIENTI_STIPENDI_PENSIONI') AND type in (N'U'))
	BEGIN
		SELECT * 
		INTO Classifica.SEP_CLIENTI_STIPENDI_PENSIONI
		FROM Classifica.TEMP_STIPENDI_PENSIONI	
	END 
	ELSE
	BEGIN
		/*-- elimino dalla definitiva i clienti presenti in tabella temporanea
		DELETE B
		FROM 
			Classifica.TEMP_STIPENDI_PENSIONI A
			INNER JOIN Classifica.SEP_CLIENTI_STIPENDI_PENSIONI B ON	A.ID_CLIENTE=B.ID_CLIENTE	
																		AND B.ANNO_1 = A.ANNO_1
					-- potrebbe essere necessario mettere una condizione sull'anno=anno_1 nel caso in cui 
					-- l'incentivazione prosegua nel tempo e lo stesso cliente potrebbe apparire più volte
		*/
		-- elimino dalla definitiva tutti i record che hanno anno1 = anno corrente in modo da preservare gli eventuali dati dell'anno precedente 
		DELETE Classifica.SEP_CLIENTI_STIPENDI_PENSIONI
		WHERE ANNO_1=@AnnoRC

		INSERT INTO Classifica.SEP_CLIENTI_STIPENDI_PENSIONI
		SELECT * FROM Classifica.TEMP_STIPENDI_PENSIONI	
	END 

	/*********************************************************************************************/
	-- ora vanno aggiornate le esclusioni e i dati consuntivi sulle tabelle definitive
	/*UPDATE Classifica.SEP_CLIENTI_STIPENDI_PENSIONI
	SET NUM_RATE_ANNO_1=0,
		NUM_RATE_ANNO_2=0,
		NUM_RATE_ANNO_3=0,
		NUM_RATE_ATTESE_ANNO_1=0,
		NUM_RATE_ATTESE_ANNO_2=0,
		NUM_RATE_ATTESE_ANNO_3=0,
		NUM_RATE_INSUFF_ANNO_2=0,
		NUM_RATE_INSUFF_ANNO_3=0,
		FLAG_DELINQUENCY_ANNO_2=0,
		FLAG_DELINQUENCY_ANNO_3=0,
		DATA_PRIMO_VERSAMENTO=0,
		ID_ESCLUSIONE=0*/


	PRINT '/*********************************Aggiornamento Rate*************************************/'
	
	UPDATE CSP
		SET NUM_RATE_ANNO_1 = T.NUM_RATE
	FROM
		Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP
		INNER JOIN (
			SELECT 
				ID_CLIENTE,
				COUNT(*) AS NUM_RATE,
				ANNO,
				CODAGE
			FROM Classifica.TEMP_MOVIMENTI_STIPENDI_PENSIONI
			GROUP BY ID_CLIENTE, CODAGE, ANNO
		)  T ON T.ID_CLIENTE= CSP.ID_CLIENTE
				AND CSP.ANNO_1 = T.ANNO
				AND CSP.CODAGE = T.CODAGE
	WHERE CSP.ANNO_1=@AnnoRC
		AND CSP.DATA_RC = @DataRC

	UPDATE CSP
		SET NUM_RATE_ANNO_2 = T.NUM_RATE
	FROM
		Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP
		INNER JOIN (
			SELECT 
				ID_CLIENTE,
				COUNT(*) AS NUM_RATE,
				ANNO,
				CODAGE
			FROM Classifica.TEMP_MOVIMENTI_STIPENDI_PENSIONI
			GROUP BY ID_CLIENTE, CODAGE, ANNO
		)  T ON T.ID_CLIENTE= CSP.ID_CLIENTE
				AND CSP.ANNO_2 = T.ANNO
				AND CSP.CODAGE = T.CODAGE
	WHERE CSP.ANNO_2=@AnnoRC
		AND CSP.DATA_RC = @DataRC

	UPDATE CSP
		SET NUM_RATE_ANNO_3 = T.NUM_RATE
	FROM
		Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP
		INNER JOIN (
			SELECT 
				ID_CLIENTE,
				COUNT(*) AS NUM_RATE,
				ANNO,
				CODAGE
			FROM Classifica.TEMP_MOVIMENTI_STIPENDI_PENSIONI
			GROUP BY ID_CLIENTE, CODAGE, ANNO
		)  T ON T.ID_CLIENTE= CSP.ID_CLIENTE
				AND CSP.ANNO_3 = T.ANNO
				AND CSP.CODAGE = T.CODAGE
	WHERE CSP.ANNO_3=@AnnoRC
		AND CSP.DATA_RC = @DataRC

	UPDATE CSP
		--SET CSP.NUM_RATE_ATTESE_ANNO_1 = (@DataRC/100) - (DATA_PRIMO_VERSAMENTO) + CASE WHEN @DataRC = @AnnoRC * 10000 + 1231 THEN 1 ELSE 0 END 
		SET CSP.NUM_RATE_ATTESE_ANNO_1 = (@DataRC/100) - (DATA_PRIMO_VERSAMENTO) + CASE WHEN @DataRC = @DataFineMeseRC THEN 1 ELSE 0 END 
	FROM 
		Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP
	WHERE
		CSP.ANNO_1 = @AnnoRC
		AND CSP.DATA_RC = @DataRC

	UPDATE CSP
		--SET CSP.NUM_RATE_ATTESE_ANNO_2 = (@DataRC/100) - (@AnnoRC * 100 + 1) + CASE WHEN @DataRC = @AnnoRC * 10000 + 1231 THEN 1 ELSE 0 END 
		SET CSP.NUM_RATE_ATTESE_ANNO_2 = (@DataRC/100) - (@AnnoRC * 100 + 1) + CASE WHEN @DataRC = @DataFineMeseRC THEN 1 ELSE 0 END 
	FROM 
		Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP
	WHERE
		CSP.ANNO_2 = @AnnoRC
		AND CSP.DATA_RC = @DataRC

	UPDATE CSP
		--SET CSP.NUM_RATE_ATTESE_ANNO_3 = (@DataRC/100) - (@AnnoRC * 100 + 1) + CASE WHEN @DataRC = @AnnoRC * 10000 + 1231 THEN 1 ELSE 0 END 
		SET CSP.NUM_RATE_ATTESE_ANNO_3 = (@DataRC/100) - (@AnnoRC * 100 + 1) + CASE WHEN @DataRC = @DataFineMeseRC THEN 1 ELSE 0 END 
	FROM 
		Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP
	WHERE
		CSP.ANNO_3 = @AnnoRC
		AND CSP.DATA_RC = @DataRC

	-- Aggiornamento numero rate di importo insufficiente
	UPDATE CSP
		SET NUM_RATE_INSUFF_ANNO_2 = T.NUM_RATE
	FROM
		Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP
		INNER JOIN (
			SELECT 
				ID_CLIENTE,
				COUNT(*) AS NUM_RATE,
				CAST(DTMOV/100 AS INT) AS ANNO
			FROM Classifica.TEMP_MOVIMENTI_STIPENDI_PENSIONI
			WHERE IMPORTO < @ImportoMinimoRata
			GROUP BY ID_CLIENTE, CAST(DTMOV/100 AS INT)
		)  T ON T.ID_CLIENTE= CSP.ID_CLIENTE
				AND CSP.ANNO_2 = T.ANNO
	WHERE CSP.ANNO_2=@AnnoRC
		AND CSP.DATA_RC = @DataRC

	UPDATE CSP
		SET NUM_RATE_INSUFF_ANNO_3 = T.NUM_RATE
	FROM
		Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP
		INNER JOIN (
			SELECT 
				ID_CLIENTE,
				COUNT(*) AS NUM_RATE,
				CAST(DTMOV/100 AS INT) AS ANNO
			FROM Classifica.TEMP_MOVIMENTI_STIPENDI_PENSIONI
			WHERE IMPORTO < @ImportoMinimoRata
			GROUP BY ID_CLIENTE, CAST(DTMOV/100 AS INT)
		)  T ON T.ID_CLIENTE= CSP.ID_CLIENTE
				AND CSP.ANNO_3 = T.ANNO
	WHERE CSP.ANNO_3=@AnnoRC
		AND CSP.DATA_RC = @DataRC

	PRINT '/*********************************Aggiornamento Esclusioni*************************************/'
	UPDATE Classifica.SEP_CLIENTI_STIPENDI_PENSIONI 
	SET ID_ESCLUSIONE=0
	WHERE ID_ESCLUSIONE=1
		AND ANNO_1=@AnnoRC

	UPDATE CSP
	SET ID_ESCLUSIONE=1		
	FROM 
		Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP
		INNER JOIN Classifica.SEP_ClientiConCanalizzazioneAnnoPrecedente B ON --B.ID_CLIENTE = CSP.ID_CLIENTE
																				B.CODFIS = CSP.CDFIS
																				AND CSP.ANNO_1 = B.ANNO
	WHERE
		CSP.ID_ESCLUSIONE=0
		AND CSP.ANNO_1 = @AnnoRC
		--AND CSP.DATA_RC = @DataRC

	-- metto l'esclusione solo se l'anno è l'anno 1 altrimenti il cliente è in delinquency
	UPDATE CSP
	SET ID_ESCLUSIONE=2
	FROM 
		Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP
		INNER JOIN Classifica.SEP_ClientiConRataInsufficiente B ON	--B.ID_CLIENTE = CSP.ID_CLIENTE
																	B.CODFIS = CSP.CDFIS
																	AND B.ANNO = CSP.ANNO_1
	WHERE
		CSP.ID_ESCLUSIONE=0
		--AND CSP.DATA_RC = @DataRC

 	-- metto l'esclusione solo se l'anno è l'anno 1 altrimenti il cliente è in delinquency
	/*UPDATE Classifica.SEP_CLIENTI_STIPENDI_PENSIONI
	SET ID_ESCLUSIONE=3
	WHERE
		ID_ESCLUSIONE=0
		AND (NUM_RATE_ANNO_1<NUM_RATE_ATTESE_ANNO_1) -- OR NUM_RATE_ANNO_2<NUM_RATE_ATTESE_ANNO_2 OR NUM_RATE_ANNO_3<NUM_RATE_ATTESE_ANNO_3)
	*/
	;WITH UltimaRataCliente
	AS
	(
		SELECT DISTINCT 
			M.ID_CLIENTE, 
			MAX(M.DTMOV) AS UltimaData
		FROM 
			Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI M
		WHERE
			M.DATA_RC = (SELECT MAX(DATA_RC) FROM Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI WHERE ANNO=@AnnoRC) 
			AND M.INDICE_AGGIORNAMENTO = (SELECT MAX(INDICE_AGGIORNAMENTO) FROM Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI WHERE DATA_RC = (SELECT MAX(DATA_RC) FROM Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI WHERE ANNO=@AnnoRC))
		GROUP BY M.ID_CLIENTE
	) 
	UPDATE CSP
		SET ID_ESCLUSIONE=3
	FROM 
		Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP
		LEFT JOIN UltimaRataCliente URC ON URC.ID_CLIENTE = CSP.ID_CLIENTE
	WHERE
		CSP.ID_ESCLUSIONE=0
		AND ((CSP.NUM_RATE_ANNO_1<CSP.NUM_RATE_ATTESE_ANNO_1) OR 
			(CSP.NUM_RATE_ANNO_1=CSP.NUM_RATE_ATTESE_ANNO_1 AND @DataRC<>@DataFineMeseRC AND URC.UltimaData=@DataRC/100))
			--(CSP.NUM_RATE_ANNO_1=CSP.NUM_RATE_ATTESE_ANNO_1 AND @DataRC<>@AnnoRC * 10000 + 1231 AND URC.UltimaData=@DataRC/100))

	-- Aggiornamento delle esclusioni assegnate tramite eccezione
	UPDATE CSP
	SET ID_ESCLUSIONE = CASE WHEN EC.FLAG_ESCLUSO = 0 THEN 0 ELSE 4 END 
	FROM 
		Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP
		INNER JOIN Classifica.SEP_ECCEZIONI_CLIENTE EC ON EC.ID_CLIENTE = CSP.ID_CLIENTE
	WHERE 
		EC.FLAG_ESCLUSO IS NOT NULL 

	PRINT '/*******************************Aggiornamento delinquency**************************************/'

	UPDATE Classifica.SEP_CLIENTI_STIPENDI_PENSIONI 
	SET FLAG_DELINQUENCY_ANNO_2=0
	WHERE ANNO_2>=@AnnoRC

	UPDATE Classifica.SEP_CLIENTI_STIPENDI_PENSIONI 
	SET FLAG_DELINQUENCY_ANNO_3=0
	WHERE ANNO_3>=@AnnoRC

	;WITH UltimaRataCliente
	AS
	(
		SELECT DISTINCT 
			M.ID_CLIENTE, 
			MAX(M.DTMOV) AS UltimaData
		FROM 
			Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI M
		WHERE
			M.DATA_RC = (SELECT MAX(DATA_RC) FROM Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI WHERE ANNO=@AnnoRC) 
			AND M.INDICE_AGGIORNAMENTO = (SELECT MAX(INDICE_AGGIORNAMENTO) FROM Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI WHERE DATA_RC = (SELECT MAX(DATA_RC) FROM Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI WHERE ANNO=@AnnoRC))
		GROUP BY M.ID_CLIENTE
	) 
	UPDATE CSP
	SET FLAG_DELINQUENCY_ANNO_2 = 1
	FROM 
		Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP
		LEFT JOIN UltimaRataCliente URC ON URC.ID_CLIENTE = CSP.ID_CLIENTE
	WHERE
		CSP.ID_ESCLUSIONE=0
		AND (((CSP.NUM_RATE_ANNO_2<CSP.NUM_RATE_ATTESE_ANNO_2) OR 
			(CSP.NUM_RATE_ANNO_2=CSP.NUM_RATE_ATTESE_ANNO_2 AND @DataRC<>@DataFineMeseRC AND URC.UltimaData=@DataRC/100 AND CSP.NUM_RATE_ATTESE_ANNO_2 > 0))
			--(CSP.NUM_RATE_ANNO_2=CSP.NUM_RATE_ATTESE_ANNO_2 AND @DataRC<>@AnnoRC * 10000 + 1231 AND URC.UltimaData=@DataRC/100 AND CSP.NUM_RATE_ATTESE_ANNO_2 > 0))
			OR CSP.NUM_RATE_INSUFF_ANNO_2 > 0)

	;WITH UltimaRataCliente
	AS
	(
		SELECT DISTINCT 
			M.ID_CLIENTE, 
			MAX(M.DTMOV) AS UltimaData
		FROM 
			Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI M
		WHERE
			M.DATA_RC = (SELECT MAX(DATA_RC) FROM Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI WHERE ANNO=@AnnoRC) 
			AND M.INDICE_AGGIORNAMENTO = (SELECT MAX(INDICE_AGGIORNAMENTO) FROM Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI WHERE DATA_RC = (SELECT MAX(DATA_RC) FROM Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI WHERE ANNO=@AnnoRC))
		GROUP BY M.ID_CLIENTE
	) 
	UPDATE CSP
	SET FLAG_DELINQUENCY_ANNO_3 = 1
	FROM 
		Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP
		LEFT JOIN UltimaRataCliente URC ON URC.ID_CLIENTE = CSP.ID_CLIENTE
	WHERE
		CSP.ID_ESCLUSIONE=0
		AND (((CSP.NUM_RATE_ANNO_3<CSP.NUM_RATE_ATTESE_ANNO_3) OR 
			(CSP.NUM_RATE_ANNO_3=CSP.NUM_RATE_ATTESE_ANNO_3 AND @DataRC<>@DataFineMeseRC AND URC.UltimaData=@DataRC/100 AND CSP.NUM_RATE_ATTESE_ANNO_3 > 0))
			--(CSP.NUM_RATE_ANNO_3=CSP.NUM_RATE_ATTESE_ANNO_3 AND @DataRC<>@AnnoRC * 10000 + 1231 AND URC.UltimaData=@DataRC/100 AND CSP.NUM_RATE_ATTESE_ANNO_3 > 0))
			OR CSP.NUM_RATE_INSUFF_ANNO_3 > 0)

	PRINT '/*******************************Storicizzazione clienti**************************************/'

	UPDATE Classifica.SEP_CLIENTI_STIPENDI_PENSIONI
	SET DATA_RC=@DataRC,
		INDICE_AGGIORNAMENTO=@IndiceAggiornamento

	IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Classifica.SEP_CLIENTI_STIPENDI_PENSIONI_STORICO') AND type in (N'U'))
	BEGIN
		SELECT * 
		INTO Classifica.SEP_CLIENTI_STIPENDI_PENSIONI_STORICO
		FROM Classifica.SEP_CLIENTI_STIPENDI_PENSIONI
	END 
	ELSE
	BEGIN
		-- elimino dallo storico i dati rel a questa data RC (se presenti)
		DELETE Classifica.SEP_CLIENTI_STIPENDI_PENSIONI_STORICO 
		WHERE DATA_RC=@DataRC
			AND INDICE_AGGIORNAMENTO = @IndiceAggiornamento
		
		INSERT INTO Classifica.SEP_CLIENTI_STIPENDI_PENSIONI_STORICO
		SELECT * FROM Classifica.SEP_CLIENTI_STIPENDI_PENSIONI
	END 

	PRINT '/********************************Aggiornamento Sintesi PB************************************/'
	IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Classifica.SEP_SINTESI_PB_ANNO') AND type in (N'U'))
	BEGIN
		CREATE TABLE Classifica.SEP_SINTESI_PB_ANNO (
			CODAGE VARCHAR(6) NOT NULL,
			ANNO INT NOT NULL,
			CATEGORIA VARCHAR(100) NULL,
			NUM_CLIENTI INT NULL,
			NUM_CLIENTI_VALIDI INT NULL,
			IMPORTO_CANAL_VALIDE NUMERIC(38,2) NULL,
			DELINQUENCY INT NULL,
			STATO VARCHAR(1) NULL,
			ESCLUSO INT NULL,
			DATA_RC INT NOT NULL,
			INDICE_AGGIORNAMENTO INT NOT NULL
		)
	END 


	DELETE Classifica.SEP_SINTESI_PB_ANNO
	WHERE DATA_RC = @DataRC AND INDICE_AGGIORNAMENTO = @IndiceAggiornamento

	INSERT INTO Classifica.SEP_SINTESI_PB_ANNO
	SELECT DISTINCT 
		PP.CODAGE,
		@AnnoRC AS ANNO,
		PP.CATEGORIA_PB AS CATEGORIA,
		0 AS NUM_CLIENTI,
		0 AS NUM_CLIENTI_VALIDI,
		0 AS IMPORTO_CANAL_VALIDE,
		0 AS DELINQUENCY,
		PP.STATUS AS STATO,
		PP.ESCLUSO AS ESCLUSO,
		@DataRC AS DATA_RC,
		@IndiceAggiornamento AS INDICE_AGGIORNAMENTO
	FROM 
		Classifica.PERIMETRO_PAC PP 
		LEFT JOIN Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP ON PP.CODAGE = CSP.CODAGE
	WHERE 
		PP.ESCLUSO=0


	UPDATE SPB
	SET NUM_CLIENTI = CSP.NUM_CLIENTI
	FROM 
		Classifica.SEP_SINTESI_PB_ANNO SPB
		INNER JOIN 
		(	SELECT  
				CSP.CODAGE,
				COUNT(DISTINCT CSP.CDFIS) AS NUM_CLIENTI
			FROM 
				Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP 
			GROUP BY CSP.CODAGE
		) CSP ON CSP.CODAGE = SPB.CODAGE
	WHERE
		SPB.DATA_RC=@DataRC
		AND SPB.INDICE_AGGIORNAMENTO=@IndiceAggiornamento
	

	UPDATE SPB
	SET SPB.NUM_CLIENTI_VALIDI = CSP.NUM_CLIENTI
	FROM 
		Classifica.SEP_SINTESI_PB_ANNO SPB
		INNER JOIN 
		(	SELECT  
				CSP.CODAGE,
				COUNT(DISTINCT CSP.CDFIS) AS NUM_CLIENTI
			FROM 
				Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP 
			WHERE CSP.ID_ESCLUSIONE=0
			GROUP BY CSP.CODAGE
		) CSP ON CSP.CODAGE = SPB.CODAGE																	
	WHERE
		SPB.DATA_RC=@DataRC
		AND SPB.INDICE_AGGIORNAMENTO=@IndiceAggiornamento
		
	UPDATE SPB
	SET SPB.DELINQUENCY = CSP.NUM_CLIENTI
	FROM 
		Classifica.SEP_SINTESI_PB_ANNO SPB
		INNER JOIN 
		(	SELECT  
				CSP.CODAGE,
				COUNT(DISTINCT CSP.CDFIS) AS NUM_CLIENTI
			FROM 
				Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP 
			WHERE CSP.ID_ESCLUSIONE=0
				AND 0 < CASE @AnnoRC 
							WHEN CSP.ANNO_2 THEN CSP.FLAG_DELINQUENCY_ANNO_2 
							WHEN CSP.ANNO_3 THEN CSP.FLAG_DELINQUENCY_ANNO_3
							ELSE 0
						END 
			GROUP BY CSP.CODAGE
		) CSP ON CSP.CODAGE = SPB.CODAGE																	
	WHERE
		SPB.ANNO = @AnnoRC
		AND SPB.DATA_RC=@DataRC
		AND SPB.INDICE_AGGIORNAMENTO=@IndiceAggiornamento

	UPDATE SPB
	SET SPB.IMPORTO_CANAL_VALIDE = CSP.IMPORTO
	FROM 
		Classifica.SEP_SINTESI_PB_ANNO SPB
		INNER JOIN 
		(	SELECT  
				CSP.CODAGE,
				SUM(MOV.IMPORTO) AS IMPORTO
			FROM 
				Classifica.SEP_CLIENTI_STIPENDI_PENSIONI CSP 
				INNER JOIN Classifica.SEP_MOVIMENTI_STIPENDI_PENSIONI MOV ON	MOV.CDFIS = CSP.CDFIS
																				AND CAST(MOV.DTMOV/100 AS INT) = @AnnoRC
			WHERE CSP.ID_ESCLUSIONE=0
			GROUP BY CSP.CODAGE
		) CSP ON CSP.CODAGE = SPB.CODAGE																	
	WHERE
		SPB.DATA_RC=@DataRC
		AND SPB.INDICE_AGGIORNAMENTO=@IndiceAggiornamento	

	PRINT '/************************************* FINE PROCEDURA *************************************/'
	/*********************************************************************************************/
END
