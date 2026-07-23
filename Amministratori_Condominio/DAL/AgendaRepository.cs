using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Amministratori_Condominio.DAL
{
    public class AgendaRepository
    {
        private string _connectionString;

        public AgendaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Carica tutti gli interventi di agenda per un condominio con filtri opzionali
        /// </summary>
        public DataTable GetAgendaInterventiByCondominio(int idCondominio, DateTime? dataInizio = null, DateTime? dataFine = null, string stato = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        a.IdIntervento,
                        a.IdCondominio,
                        c.Nome AS NomeCondominio,
                        a.Descrizione,
                        a.DataIntervento,
                        a.Stato,
                        DATEDIFF(DAY, GETDATE(), a.DataIntervento) AS GiorniRimanenti
                    FROM AgendaIntervento a
                    INNER JOIN Condomini c ON a.IdCondominio = c.IdCondominio
                    WHERE a.IdCondominio = @IdCondominio";

                if (dataInizio.HasValue)
                    query += " AND a.DataIntervento >= @DataInizio";

                if (dataFine.HasValue)
                    query += " AND a.DataIntervento <= @DataFine";

                if (!string.IsNullOrEmpty(stato))
                    query += " AND a.Stato = @Stato";

                query += " ORDER BY a.DataIntervento DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdCondominio", idCondominio);

                if (dataInizio.HasValue)
                    cmd.Parameters.AddWithValue("@DataInizio", dataInizio.Value.Date);

                if (dataFine.HasValue)
                    cmd.Parameters.AddWithValue("@DataFine", dataFine.Value.Date);

                if (!string.IsNullOrEmpty(stato))
                    cmd.Parameters.AddWithValue("@Stato", stato);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// Carica tutti gli interventi per un amministratore
        /// </summary>
        public DataTable GetAgendaInterventiByAmministratore(int idAmministratore, DateTime? dataInizio = null, DateTime? dataFine = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        a.IdIntervento,
                        a.IdCondominio,
                        c.Nome AS NomeCondominio,
                        a.Descrizione,
                        a.DataIntervento,
                        a.Stato,
                        DATEDIFF(DAY, GETDATE(), a.DataIntervento) AS GiorniRimanenti
                    FROM AgendaIntervento a
                    INNER JOIN Condomini c ON a.IdCondominio = c.IdCondominio
                    WHERE c.IdAmministratore = @IdAmministratore";

                if (dataInizio.HasValue)
                    query += " AND a.DataIntervento >= @DataInizio";

                if (dataFine.HasValue)
                    query += " AND a.DataIntervento <= @DataFine";

                query += " ORDER BY a.DataIntervento ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdAmministratore", idAmministratore);

                if (dataInizio.HasValue)
                    cmd.Parameters.AddWithValue("@DataInizio", dataInizio.Value.Date);

                if (dataFine.HasValue)
                    cmd.Parameters.AddWithValue("@DataFine", dataFine.Value.Date);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// Inserisce un nuovo intervento in agenda
        /// </summary>
        public int InsertIntervento(int idCondominio, string descrizione, DateTime? dataIntervento, string stato = "Programmato")
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO AgendaIntervento (IdCondominio, Descrizione, DataIntervento, Stato)
                    VALUES (@IdCondominio, @Descrizione, @DataIntervento, @Stato);
                    SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdCondominio", idCondominio);
                cmd.Parameters.AddWithValue("@Descrizione", descrizione ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DataIntervento", dataIntervento.HasValue ? (object)dataIntervento.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Stato", stato ?? "Programmato");

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Aggiorna un intervento di agenda
        /// </summary>
        public bool UpdateIntervento(int idIntervento, string descrizione, DateTime? dataIntervento, string stato)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    UPDATE AgendaIntervento
                    SET Descrizione = @Descrizione, 
                        DataIntervento = @DataIntervento, 
                        Stato = @Stato
                    WHERE IdIntervento = @IdIntervento";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdIntervento", idIntervento);
                cmd.Parameters.AddWithValue("@Descrizione", descrizione ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DataIntervento", dataIntervento.HasValue ? (object)dataIntervento.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Stato", stato ?? (object)DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Elimina un intervento di agenda
        /// </summary>
        public bool DeleteIntervento(int idIntervento)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM AgendaIntervento WHERE IdIntervento = @IdIntervento";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdIntervento", idIntervento);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Carica un singolo intervento per ID
        /// </summary>
        public DataRow GetInterventoById(int idIntervento)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        a.IdIntervento,
                        a.IdCondominio,
                        c.Nome AS NomeCondominio,
                        a.Descrizione,
                        a.DataIntervento,
                        a.Stato
                    FROM AgendaIntervento a
                    INNER JOIN Condomini c ON a.IdCondominio = c.IdCondominio
                    WHERE a.IdIntervento = @IdIntervento";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdIntervento", idIntervento);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        /// <summary>
        /// Carica interventi prossimi (entro X giorni)
        /// </summary>
        public DataTable GetInterventoProssimi(int idAmministratore, int giorniAntecedenti = 7)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT TOP 20
                        a.IdIntervento,
                        a.IdCondominio,
                        c.Nome AS NomeCondominio,
                        a.Descrizione,
                        a.DataIntervento,
                        a.Stato,
                        DATEDIFF(DAY, GETDATE(), a.DataIntervento) AS GiorniRimanenti
                    FROM AgendaIntervento a
                    INNER JOIN Condomini c ON a.IdCondominio = c.IdCondominio
                    WHERE c.IdAmministratore = @IdAmministratore
                    AND a.DataIntervento IS NOT NULL
                    AND a.DataIntervento BETWEEN GETDATE() AND DATEADD(DAY, @GiorniAntecedenti, GETDATE())
                    AND a.Stato != 'Completato'
                    ORDER BY a.DataIntervento ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdAmministratore", idAmministratore);
                cmd.Parameters.AddWithValue("@GiorniAntecedenti", giorniAntecedenti);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// Cambia lo stato di un intervento
        /// </summary>
        public bool UpdateStatoIntervento(int idIntervento, string nuovoStato)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE AgendaIntervento SET Stato = @Stato WHERE IdIntervento = @IdIntervento";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdIntervento", idIntervento);
                cmd.Parameters.AddWithValue("@Stato", nuovoStato);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
