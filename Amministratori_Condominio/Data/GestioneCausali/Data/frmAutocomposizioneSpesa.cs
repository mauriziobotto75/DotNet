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
}
