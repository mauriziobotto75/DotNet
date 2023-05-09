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
			CONTEST_164_417_OUT
	),
	IndiceAggiornamento
	AS
	(
		SELECT 
			d.DATA_RC,
			MAX(INDICEAGGIORNAMENTO) AS INDICEAGGIORNAMENTO
		FROM 
			CONTEST_164_417_OUT o
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
		CONTEST_164_417_OUT CNT 
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