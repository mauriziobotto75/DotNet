using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Amministratori_Condominio.DAL
{
    public class ContatoreDal
    {
        private string _connectionString;

        public ContatoreDal(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Leggi tutti i contatori di un condominio
        public DataTable GetContattoriByCondominio(int idCondominio)
        {
            DataTable dt = new DataTable();
            
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT IdContatore, Nome, UnitaMisura, Tipo 
                    FROM Contatori 
                    WHERE IdCondominio = @IdCondominio
                    ORDER BY Nome";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdCondominio", idCondominio);
                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            
            return dt;
        }

        // Leggi dettagli di un contatore
        public DataRow GetContatore(int idContatore)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT * FROM Contatori 
                    WHERE IdContatore = @IdContatore";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdContatore", idContatore);
                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        // Crea nuovo contatore
        public int InsertContatore(int idCondominio, string nome, string unitaMisura, string tipo)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO Contatori (IdCondominio, Nome, UnitaMisura, Tipo)
                    VALUES (@IdCondominio, @Nome, @UnitaMisura, @Tipo);
                    SELECT SCOPE_IDENTITY();";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdCondominio", idCondominio);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@UnitaMisura", unitaMisura);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Aggiorna contatore
        public bool UpdateContatore(int idContatore, string nome, string unitaMisura, string tipo)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    UPDATE Contatori 
                    SET Nome = @Nome, UnitaMisura = @UnitaMisura, Tipo = @Tipo
                    WHERE IdContatore = @IdContatore";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdContatore", idContatore);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@UnitaMisura", unitaMisura);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Elimina contatore
        public bool DeleteContatore(int idContatore)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"DELETE FROM Contatori WHERE IdContatore = @IdContatore";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdContatore", idContatore);
                
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
