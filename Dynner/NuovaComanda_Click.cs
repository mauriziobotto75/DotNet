


private RistorazioneContext _db = new RistorazioneContext();
private Comanda _comandaCorrente;
private void NuovaComanda()
{
    _comandaCorrente = new Comanda
    {
        Data = DateTime.Now,
        Coperti = 1,
        Dettagli = new List<ComandaDettaglio>()
    };

    dgvComanda.DataSource = _comandaCorrente.Dettagli.ToList();
    AggiornaTotale();
}
