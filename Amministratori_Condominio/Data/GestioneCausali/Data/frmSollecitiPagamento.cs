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
} private void btnSalva_Click(13    object sender,14    EventArgs e)15{16    SqlConnection cn =17        new DBConnection().GetConnection();18 19    string sql =20    @"21    INSERT INTO Solleciti22    (23        IdRata,24        DataSollecito,25        Testo,26        Stato27    )28    VALUES29    (30        @IdRata,31        GETDATE(),32        @Testo,33        'Da inviare'34    )";35 36    SqlCommand cmd =37        new SqlCommand(sql, cn);38 39    cmd.Parameters.AddWithValue(40        "@IdRata",41        _idRata);42 43    cmd.Parameters.AddWithValue(44        "@Testo",45        rtfTesto.Text);46 47    cn.Open();48 49    cmd.ExecuteNonQuery();50 51    cn.Close();52 53    MessageBox.Show(54        "Sollecito registrato.");55}
