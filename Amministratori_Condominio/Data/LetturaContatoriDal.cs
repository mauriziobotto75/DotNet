using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Amministratori_Condominio.DAL
{
    public class LetturaContatoreDal
    {
        private string _connectionString;

        public LetturaContatoreDal(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Leggi tutte le letture di un contatore con dettagli unità
        public DataTable GetLettureByContatore(int idContatore)
        {
            DataTable dt = new DataTable();
            
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        l.IdLettura,
                        l.IdContatore,
                        l.IdUnita,
                        u.Interno,
                        u.Scala,
                        u.Piano,
                        l.DataLettura,
                        l.Valore,
                        rag.Cognome AS ProprietarioNome
                    FROM LettureContatori l
                    INNER JOIN UnitaImmobiliari u ON l.IdUnita = u.IdUnita
                    LEFT JOIN OccupazioniUnita oc ON u.IdUnita = oc.IdUnita 
                        AND oc.DataFine IS NULL
                    LEFT JOIN Persone rag ON oc.IdPersona = rag.IdPersona
                    WHERE l.IdContatore = @IdContatore
                    ORDER BY l.DataLettura DESC, u.Interno";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdContatore", idContatore);
                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            
            return dt;
        }

        // Leggi ultime letture per ogni unità
        public DataTable GetUltimeLetturePerUnita(int idContatore)
        {
            DataTable dt = new DataTable();
            
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        u.IdUnita,
                        u.Interno,
                        u.Scala,
                        u.Piano,
                        MAX(l.DataLettura) AS DataUltimaLettura,
                        (SELECT TOP 1 l2.Valore 
                         FROM LettureContatori l2 
                         WHERE l2.IdUnita = u.IdUnita 
                         AND l2.IdContatore = @IdContatore
                         ORDER BY l2.DataLettura DESC) AS UltimoValore
                    FROM UnitaImmobiliari u
                    LEFT JOIN LettureContatori l ON u.IdUnita = l.IdUnita 
                        AND l.IdContatore = @IdContatore
                    WHERE u.IdCondominio = (SELECT IdCondominio FROM Contatori WHERE IdContatore = @IdContatore)
                    GROUP BY u.IdUnita, u.Interno, u.Scala, u.Piano
                    ORDER BY u.Interno";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdContatore", idContatore);
                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            
            return dt;
        }

        // Inserisci lettura
        public int InsertLettura(int idContatore, int idUnita, DateTime dataLettura, decimal valore)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO LettureContatori (IdContatore, IdUnita, DataLettura, Valore)
                    VALUES (@IdContatore, @IdUnita, @DataLettura, @Valore);
                    SELECT SCOPE_IDENTITY();";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdContatore", idContatore);
                cmd.Parameters.AddWithValue("@IdUnita", idUnita);
                cmd.Parameters.AddWithValue("@DataLettura", dataLettura);
                cmd.Parameters.AddWithValue("@Valore", valore);
                
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Aggiorna lettura
        public bool UpdateLettura(int idLettura, DateTime dataLettura, decimal valore)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    UPDATE LettureContatori 
                    SET DataLettura = @DataLettura, Valore = @Valore
                    WHERE IdLettura = @IdLettura";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdLettura", idLettura);
                cmd.Parameters.AddWithValue("@DataLettura", dataLettura);
                cmd.Parameters.AddWithValue("@Valore", valore);
                
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Elimina lettura
        public bool DeleteLettura(int idLettura)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"DELETE FROM LettureContatori WHERE IdLettura = @IdLettura";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdLettura", idLettura);
                
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
