private void RefreshGrid()
{
    dgvComanda.DataSource = null;
    dgvComanda.DataSource = _comandaCorrente.Dettagli
        .Select(d => new
        {
            Qta = d.Quantita,
            Portata = d.Prodotto.Nome,
            Prezzo = d.Prezzo,
            Importo = d.Importo
        }).ToList();
}
