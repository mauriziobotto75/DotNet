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
}
