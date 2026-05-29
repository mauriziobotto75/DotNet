private void AggiungiProdotto(Prodotto p)
{
    var esistente = _comandaCorrente.Dettagli
        .FirstOrDefault(d => d.ProdottoId == p.Id);

    if (esistente != null)
    {
        esistente.Quantita++;
        esistente.Importo = esistente.Quantita * esistente.Prezzo;
    }
    else
    {
        _comandaCorrente.Dettagli.Add(new ComandaDettaglio
        {
            ProdottoId = p.Id,
            Prodotto = p,
            Quantita = 1,
            Prezzo = p.Prezzo,
            Importo = p.Prezzo
        });
    }

    RefreshGrid();
    AggiornaTotale();
}
