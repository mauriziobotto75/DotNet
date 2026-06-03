var db = new RistorazioneEntities();
var prodotti = db.Prodotti.ToList();
private void btnConto_Click(object sender, EventArgs e)
{
    int idComanda = _comanda.Id;

    FormConto frm = new FormConto(idComanda);
    frm.ShowDialog();
}
private void ApriMenu()
{
    FormMenu frm = new FormMenu();

    frm.OnProdottoSelezionato += (prodotto) =>
    {
        var service = new ComandaService(_db);
        service.AggiungiProdotto(_comanda, prodotto);

        RefreshGrid();
    };

    frm.ShowDialog();
}
