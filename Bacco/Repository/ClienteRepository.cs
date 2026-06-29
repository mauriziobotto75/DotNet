using System.Collections.Generic;
using System.Data.SqlClient;

public class ClienteRepository
{
    private DatabaseConnection db = new DatabaseConnection();

    public List<Cliente> GetAll()
    {
        var list = new List<Cliente>();

        using (var conn = db.GetConnection())
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM Clienti", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Cliente
                {
                    Id = (int)reader["Id"],
                    Nome = reader["Nome"].ToString(),
                    Cognome = reader["Cognome"].ToString(),
                    Email = reader["Email"].ToString()
                });
            }
        }
        return list;
    }

    public void Add(Cliente c)
    {
        using (var conn = db.GetConnection())
        {
            conn.Open();
            var cmd = new SqlCommand(
                "INSERT INTO Clienti VALUES (@Nome,@Cognome,@Email,@Telefono,@Documento)", conn);

            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@Cognome", c.Cognome);
            cmd.Parameters.AddWithValue("@Email", c.Email);
            cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
            cmd.Parameters.AddWithValue("@Documento", c.Documento);

            cmd.ExecuteNonQuery();
        }
    }
}
