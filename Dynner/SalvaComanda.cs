private void SalvaComanda()
{
    _comandaCorrente.Totale = _comandaCorrente.Dettagli.Sum(d => d.Importo);

    _db.Comande.Add(_comandaCorrente);
    _db.SaveChanges();

    MessageBox.Show("Comanda salvata!");
}
``
