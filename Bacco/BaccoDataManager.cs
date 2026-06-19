// Esempio di classe base per gestire i dati
public class BaccoDataManager
{
    private string _connectionString = "Server=.;Database=Bacco;";
    
    // Esempio: Gestione Prodotti
    public List<Prodotto> GetProdotti()
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM dbo.Prodotti";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                var reader = cmd.ExecuteReader();
                var prodotti = new List<Prodotto>();
                while (reader.Read())
                {
                    prodotti.Add(new Prodotto
                    {
                        Id = (int)reader["Id"],
                        Nome = reader["Nome"].ToString(),
                        Prezzo = (decimal)reader["Prezzo"]
                    });
                }
                return prodotti;
            }
        }
    }
}

public class Prodotto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Prezzo { get; set; }
}
