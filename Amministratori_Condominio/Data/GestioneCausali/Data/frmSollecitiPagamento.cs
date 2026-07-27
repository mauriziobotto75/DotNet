private void frmSollecitiPagamento_Load(
    object sender,
    EventArgs e)
{
    CaricaRateScadute();
}

private int _idRata;

private void dgvRateScadute_CellClick(
    object sender,
    DataGridViewCellEventArgs e)
{
    _idRata =
      Convert.ToInt32(
      dgvRateScadute.Rows[e.RowIndex]
      .Cells["IdRata"].Value);

    CaricaDatiSollecito();
}
private void CaricaDatiSollecito()
{
    SqlConnection cn =
        new DBConnection().GetConnection();

    string sql =
    @"
    SELECT TOP 1

        P.Nome,
        P.Cognome,
        P.Indirizzo,
        P.Comune,
        P.CAP,

        R.Importo

    FROM Rate R

    INNER JOIN UnitaImmobiliari U
        ON U.IdUnita=R.IdUnita

    INNER JOIN OccupazioniUnita O
        ON O.IdUnita=U.IdUnita

    INNER JOIN Persone P
        ON P.IdPersona=O.IdPersona

    WHERE R.IdRata=@IdRata
    ";

    SqlCommand cmd =
        new SqlCommand(sql, cn);

    cmd.Parameters.AddWithValue(
        "@IdRata",
        _idRata);

    cn.Open();

    SqlDataReader dr =
        cmd.ExecuteReader();

    if(dr.Read())
    {
        txtDestinatario.Text =
            dr["Cognome"] + " " +
            dr["Nome"];

        txtIndirizzo.Text =
            dr["Indirizzo"].ToString();

        txtImporto.Text =
            Convert.ToDecimal(
            dr["Importo"])
            .ToString("N2");
    }

    dr.Close();
    cn.Close();
}
private void btnGenera_Click(
    object sender,
    EventArgs e)
{
    decimal importo =
        Convert.ToDecimal(
            txtImporto.Text);

    string testo =
@"OGGETTO : SOLLECITO DI PAGAMENTO

Spett.le " +
txtDestinatario.Text +

@",

da una verifica contabile
risulta uno scoperto ad oggi
pari ad Euro "
+
importo.ToString("N2")

+
@".

La preghiamo pertanto
di provvedere con cortese
sollecitudine al saldo.

Distinti saluti.

L'Amministratore";

    rtfTesto.Text = testo;
}
private void CaricaRateScadute()
{
    SqlConnection cn =
        new DBConnection().GetConnection();

    string sql =
    @"
    SELECT
        R.IdRata,
        P.Cognome + ' ' + P.Nome AS Condominio,
        R.Scadenza,
        R.Importo
    FROM Rate R
    INNER JOIN UnitaImmobiliari U
         ON U.IdUnita = R.IdUnita
    INNER JOIN OccupazioniUnita O
         ON O.IdUnita = U.IdUnita
    INNER JOIN Persone P
         ON P.IdPersona = O.IdPersona
    WHERE
         R.Pagata = 0
         AND
         R.Scadenza < GETDATE()
    ";

    SqlDataAdapter da =
        new SqlDataAdapter(sql, cn);

    DataTable dt =
        new DataTable();

    da.Fill(dt);

    dgvRateScadute.DataSource = dt;
} 
private void btnSalva_Click( object sender,  EventArgs e)
      SqlConnection cn =  new DBConnection().GetConnection();
      string sql = @"21    INSERT INTO Solleciti 
          (       IdRata,  DataSollecito,  Testo,   Stato ) 
          VALUES29    ( @IdRata, GETDATE(),  @Testo, 'Da inviare'34    )";
    SqlCommand cmd =37        new SqlCommand(sql, cn); 
    cmd.Parameters.AddWithValue( "@IdRata", _idRata);
    cmd.Parameters.AddWithValue("@Testo", rtfTesto.Text); 
    cn.Open();
    cmd.ExecuteNonQuery();
     cn.Close(); 
     MessageBox.Show(54        "Sollecito registrato."); 
} private void GeneraSollecitiMassivi()
{
    foreach(DataGridViewRow row
        in dgvRateScadute.Rows)
    {
        int idRata =
          Convert.ToInt32(
          row.Cells["IdRata"].Value);

        GeneraSollecito(idRata);
    }
} private void dgvRateScadute_RowPrePaint(
    object sender,
    DataGridViewRowPrePaintEventArgs e)
{
    DateTime scadenza =
        Convert.ToDateTime(
         dgvRateScadute.Rows[e.RowIndex]
         .Cells["Scadenza"].Value);

    if(scadenza < DateTime.Today)
    {
        dgvRateScadute.Rows[e.RowIndex]
            .DefaultCellStyle.BackColor =
                Color.LightPink;
    }
}
private int _idRata;

private void dgvRateScadute_CellClick(
    object sender,
    DataGridViewCellEventArgs e)
{
    _idRata =
      Convert.ToInt32(
      dgvRateScadute.Rows[e.RowIndex]
      .Cells["IdRata"].Value);

    CaricaDatiSollecito();
}
