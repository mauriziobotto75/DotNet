private int _comandaId;
private RistorazioneEntities _db = new RistorazioneEntities();

public FormConto(int comandaId)
{
    InitializeComponent();
    _comandaId = comandaId;
}
