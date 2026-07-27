public partial class frmAutocomposizioneSpesa : Form
{
    private int _idMovimento;
    private int _idCondominio;

    public frmAutocomposizioneSpesa(
        int idMovimento,
        int idCondominio)
    {
        InitializeComponent();

        _idMovimento = idMovimento;
        _idCondominio = idCondominio;
    }
}
private void btnAvanti_Click(
    object sender,
    EventArgs e)
{
    if(chkTabelleMillesimali.Checked)
    {
        RipartizionePerMillesimi();
    }

    if(chkMetriQuadri.Checked)
    {
        RipartizionePerMetriQuadri();
    }

    if(chkContatori.Checked)
    {
        RipartizionePerConsumi();
    }

    if(chkAPorta.Checked)
    {
        RipartizionePerUnita();
    }

    MessageBox.Show(
        "Ripartizione completata.");
} private decimal LeggiImportoSpesa()
{
    SqlConnection cn =
        new DBConnection().Connection;

    string sql =
    @"SELECT Importo
      FROM MovimentiContabili
      WHERE IdMovimento=@IdMovimento";

    SqlCommand cmd =
        new SqlCommand(sql, cn);

    cmd.Parameters.AddWithValue(
        "@IdMovimento",
        _idMovimento);

    cn.Open();

    decimal importo =
        Convert.ToDecimal(
            cmd.ExecuteScalar());

    cn.Close();

    return importo;
} private void RipartizionePerMillesimi()
{
    decimal importoSpesa =
        LeggiImportoSpesa();

    SqlConnection cn =
        new DBConnection().Connection;

    string sql =
    @"
    SELECT
        R.IdUnita,
        R.ValoreMillesimale
    FROM RigheTabellaMillesimale R
    INNER JOIN TabelleMillesimali T
        ON T.IdTabella=R.IdTabella
    WHERE T.IdCondominio=@IdCondominio";

    SqlDataAdapter da =
        new SqlDataAdapter(sql, cn);

    da.SelectCommand.Parameters.AddWithValue(
        "@IdCondominio",
        _idCondominio);

    DataTable dt =
        new DataTable();

    da.Fill(dt);

    decimal totaleMillesimi = 0;

    foreach(DataRow r in dt.Rows)
    {
        totaleMillesimi +=
           Convert.ToDecimal(
              r["ValoreMillesimale"]);
    }

    foreach(DataRow r in dt.Rows)
    {
        int idUnita =
            Convert.ToInt32(r["IdUnita"]);

        decimal mm =
            Convert.ToDecimal(
                r["ValoreMillesimale"]);

        decimal quota =
            (importoSpesa * mm) /
            totaleMillesimi;

        SalvaRipartizione(
            idUnita,
            quota,
            mm);
    }
}   private void SalvaRipartizione(
    int idUnita,
    decimal quota,
    decimal millesimi)
{
    SqlConnection cn =
        new DBConnection().Connection;

    string sql =
    @"INSERT INTO Ripartizioni
      (
          IdMovimento,
          IdUnita,
          Millesimi,
          Importo
      )
      VALUES
      (
          @IdMovimento,
          @IdUnita,
          @Millesimi,
          @Importo
      )";

    SqlCommand cmd =
        new SqlCommand(sql, cn);

    cmd.Parameters.AddWithValue(
        "@IdMovimento",
        _idMovimento);

    cmd.Parameters.AddWithValue(
        "@IdUnita",
        idUnita);

    cmd.Parameters.AddWithValue(
        "@Millesimi",
        millesimi);

    cmd.Parameters.AddWithValue(
        "@Importo",
        quota);

    cn.Open();

    cmd.ExecuteNonQuery();

    cn.Close();
}private void RipartizionePerMetriQuadri()
{
    decimal importoSpesa =
        LeggiImportoSpesa();

    SqlConnection cn =
        new DBConnection().Connection;

    string sql =
    @"
    SELECT
        IdUnita,
        Superficie
    FROM UnitaImmobiliari";

    SqlDataAdapter da =
        new SqlDataAdapter(sql, cn);

    DataTable dt =
        new DataTable();

    da.Fill(dt);

    decimal totaleMq = 0;

    foreach(DataRow r in dt.Rows)
    {
        totaleMq +=
           Convert.ToDecimal(
                r["Superficie"]);
    }

    foreach(DataRow r in dt.Rows)
    {
        int idUnita =
            Convert.ToInt32(
                r["IdUnita"]);

        decimal mq =
            Convert.ToDecimal(
                r["Superficie"]);

        decimal quota =
            importoSpesa *
            mq /
            totaleMq;

        SalvaRipartizione(
            idUnita,
            quota,
            mq);
    }
}  private void RipartizionePerConsumi()
{
    decimal importoSpesa =
        LeggiImportoSpesa();

    SqlConnection cn =
        new DBConnection().Connection;

    string sql =
    @"
    SELECT
        IdUnita,
        SUM(Valore) Consumo
    FROM LettureContatori
    GROUP BY IdUnita";

    SqlDataAdapter da =
        new SqlDataAdapter(sql, cn);

    DataTable dt =
        new DataTable();

    da.Fill(dt);

    decimal totaleConsumo = 0;

    foreach(DataRow r in dt.Rows)
    {
        totaleConsumo +=
            Convert.ToDecimal(
                r["Consumo"]);
    }

    foreach(DataRow r in dt.Rows)
    {
        int idUnita =
            Convert.ToInt32(
                r["IdUnita"]);

        decimal consumo =
            Convert.ToDecimal(
                r["Consumo"]);

        decimal quota =
            importoSpesa *
            consumo /
            totaleConsumo;

        SalvaRipartizione(
            idUnita,
            quota,
            consumo);
    }
}  private void RipartizionePerUnita()
{
    decimal importo =
        LeggiImportoSpesa();

    SqlConnection cn =
        new DBConnection().Connection;

    string sql =
    @"SELECT IdUnita
      FROM UnitaImmobiliari";

    SqlDataAdapter da =
        new SqlDataAdapter(sql, cn);

    DataTable dt =
        new DataTable();

    da.Fill(dt);

    decimal quota =
        importo / dt.Rows.Count;

    foreach(DataRow r in dt.Rows)
    {
        SalvaRipartizione(
            Convert.ToInt32(r["IdUnita"]),
            quota,
            0);
    }
}  private void btnAbbandona_Click(
    object sender,
    EventArgs e)
{
    this.Close();
}
