var comanda = db.Comande
    .Include("Comande_Dettaglio.Prodotti")
    .First(c => c.Id == id);

private int _comandaId;
private RistorazioneEntities _db = new RistorazioneEntities();

public FormConto(int comandaId)
{
    InitializeComponent();
    _comandaId = comandaId;
}
