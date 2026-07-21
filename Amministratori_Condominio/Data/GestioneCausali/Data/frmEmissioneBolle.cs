 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Gestione_Amministratore.Data
{
    public record BollettaInsertDto(int IdRata, decimal Importo, DateTime DataEmissione, string NumeroDocumento);

    public class AdoGestioneRepository : IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection? _connection;

        public AdoGestioneRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        private SqlConnection Connection => _connection ??= new SqlConnection(_connectionString);

        public DataTable GetAmministratori()
        {
            const string sql = "SELECT IdAmministratore, RagioneSociale FROM dbo.Amministratori ORDER BY RagioneSociale";
            return ExecuteQuery(sql);
        }

        public DataTable GetCondominiByAmministratore(int idAmministratore)
        {
            const string sql = "SELECT IdCondominio, Nome FROM dbo.Condomini WHERE IdAmministratore = @id ORDER BY Nome";
            return ExecuteQuery(sql, ("@id", idAmministratore));
        }

        public DataTable GetUnitaByCondominio(int idCondominio)
        {
            const string sql = "SELECT IdUnita, Scala, Interno FROM dbo.UnitaImmobiliari WHERE IdCondominio = @id ORDER BY Scala, Interno";
            return ExecuteQuery(sql, ("@id", idCondominio));
        }

        public DataTable GetRateNonPagateByUnita(int idUnita)
        {
            const string sql = @"
SELECT r.IdRata, g.Descrizione AS Gestione, 'Rata' AS TipoPag, 
       'Rata del ' + CONVERT(nvarchar(10), r.Scadenza, 103) AS Descrizione, r.Importo
FROM dbo.Rate r
JOIN dbo.Gestioni g ON g.IdGestione = r.IdGestione
WHERE r.IdUnita = @idUnita AND r.Pagata = 0
ORDER BY r.Scadenza";
            return ExecuteQuery(sql, ("@idUnita", idUnita));
        }

        public int GetUltimoNumeroBolletta()
        {
            const string sql = "SELECT TOP 1 IdBolletta FROM dbo.Bollette ORDER BY IdBolletta DESC";
            var dt = ExecuteQuery(sql);
            if (dt.Rows.Count == 0) return 0;
            return Convert.ToInt32(dt.Rows[0]["IdBolletta"]);
        }

        public void SaveBolletteAndMarkRatePaid(IEnumerable<BollettaInsertDto> bollette)
        {
            if (bollette == null) return;
            using var conn = Connection;
            conn.Open();
            using var tx = conn.BeginTransaction();
            try
            {
                foreach (var b in bollette)
                {
                    using var cmd = new SqlCommand(
                        "INSERT INTO dbo.Bollette (IdRata, DataEmissione, NumeroDocumento, Importo) VALUES (@IdRata, @DataEmissione, @NumeroDocumento, @Importo); SELECT SCOPE_IDENTITY();",
                        conn, tx);
                    cmd.Parameters.AddWithValue("@IdRata", b.IdRata);
                    cmd.Parameters.AddWithValue("@DataEmissione", b.DataEmissione.Date);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", b.NumeroDocumento ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Importo", b.Importo);
                    cmd.ExecuteScalar();

                    // se vuoi segnare la rata come pagata:
                    using var upd = new SqlCommand("UPDATE dbo.Rate SET Pagata = 1 WHERE IdRata = @IdRata", conn, tx);
                    upd.Parameters.AddWithValue("@IdRata", b.IdRata);
                    upd.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        private DataTable ExecuteQuery(string sql, params (string name, object value)[] parameters)
        {
            var dt = new DataTable();
            using var cmd = new SqlCommand(sql);
            using var da = new SqlDataAdapter(cmd);
            cmd.Connection = Connection;
            foreach (var p in parameters)
            {
                cmd.Parameters.AddWithValue(p.name, p.value ?? DBNull.Value);
            }

            Connection.Open();
            try
            {
                da.Fill(dt);
            }
            finally
            {
                Connection.Close();
            }

            return dt;
        }

        public void Dispose()
        {
            _connection?.Dispose();
            _connection = null;
        }
    }
}
