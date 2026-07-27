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
}
