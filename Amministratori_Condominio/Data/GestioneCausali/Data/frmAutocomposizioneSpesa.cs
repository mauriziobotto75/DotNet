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
