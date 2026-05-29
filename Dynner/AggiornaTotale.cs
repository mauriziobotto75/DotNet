private void AggiornaTotale()
{
    decimal totale = _comandaCorrente.Dettagli.Sum(d => d.Importo);
    lblTotale.Text = totale.ToString("C");
}
