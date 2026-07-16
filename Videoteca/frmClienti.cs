public bool InserisciCliente(
    string cliente,
    string indirizzo,
    int comune,
    string cf,
    string telefono,
    string cellulare,
    string email,
    string documento,
    decimal credito)
{
    SqlConnection cn = new DBConnection().Connection;

    string sql =
    @"INSERT INTO tbclienti
     (
        cliente,
        indirizzoc,
        kscomunec,
        codicefiscalec,
        telefonoc,
        cellularec,
        emailc,
        documento,
        creditoresiduo
     )
     VALUES
     (
        @cliente,
        @indirizzo,
        @comune,
        @cf,
        @telefono,
        @cellulare,
        @email,
        @documento,
        @credito
     )";

    SqlCommand cmd = new SqlCommand(sql, cn);

    cmd.Parameters.AddWithValue("@cliente", cliente);
    cmd.Parameters.AddWithValue("@indirizzo", indirizzo);
    cmd.Parameters.AddWithValue("@comune", comune);
    cmd.Parameters.AddWithValue("@cf", cf);
    cmd.Parameters.AddWithValue("@telefono", telefono);
    cmd.Parameters.AddWithValue("@cellulare", cellulare);
    cmd.Parameters.AddWithValue("@email", email);
    cmd.Parameters.AddWithValue("@documento", documento);
    cmd.Parameters.AddWithValue("@credito", credito);

    cn.Open();
    int n = cmd.ExecuteNonQuery();
    cn.Close();

    return n > 0;
}
