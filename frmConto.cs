private RistorazioneContext _db = new RistorazioneContext();
private Comanda _comanda
public void CaricaConto(int comandaId)
{
    _comanda = _db.Comande
        .Include("Dettagli.Prodotto")
        .First(c => c.Id == comandaId);

    dgvConto.DataSource = _comanda.Dettagli.Select(d => new
    {
        Qta = d.Quantita,
        Descrizione = d.Prodotto.Nome,
        Prezzo = d.Prezzo,
        Importo = d.Importo
    }).ToList();

    lblData.Text = DateTime.Now.ToShortDateString();
    lblOra.Text = DateTime.Now.ToShortTimeString();

    CalcolaTotale();
    CaricaTipiPagamento();
} 
private void CaricaTipiPagamento()
{
    cmbTipoPagamento.DataSource = _db.TipiPagamento.ToList();
    cmbTipoPagamento.DisplayMember = "Descrizione";
    cmbTipoPagamento.ValueMember = "Id";
}  private decimal totale = 0;

private void CalcolaTotale()
{
    totale = _comanda.Dettagli.Sum(d => d.Importo);
    lblTotale.Text = totale.ToString("C");

    CalcolaSconto();
}   private void txtSconto_TextChanged(object sender, EventArgs e)
{
    CalcolaSconto();
}

private decimal totaleScontato = 0;

private void CalcolaSconto()
{
    decimal scontoPerc = 0;
    decimal.TryParse(txtSconto.Text, out scontoPerc);

    totaleScontato = totale - (totale * scontoPerc / 100);

    lblTotaleScontato.Text = totaleScontato.ToString("C");

    CalcolaResto();
}
private void txtPagato_TextChanged(object sender, EventArgs e)
{
    CalcolaResto();
}

private void CalcolaResto()
{
    decimal pagato = 0;
    decimal.TryParse(txtPagato.Text, out pagato);

    decimal resto = pagato - totaleScontato;

    lblResto.Text = resto.ToString("C");
}
private void btnConferma_Click(object sender, EventArgs e)
{
    decimal sconto = decimal.Parse(txtSconto.Text == "" ? "0" : txtSconto.Text);
    decimal pagato = decimal.Parse(txtPagato.Text == "" ? "0" : txtPagato.Text);

    var pagamento = new Pagamento
    {
        ComandaId = _comanda.Id,
        Totale = totale,
        ScontoPercentuale = sconto,
        TotaleScontato = totaleScontato,
        ImportoPagato = pagato,
        Resto = pagato - totaleScontato,
        TipoPagamentoId = (int)cmbTipoPagamento.SelectedValue
    };

    _db.Pagamenti.Add(pagamento);

    // chiude la comanda
    _comanda.Totale = totaleScontato;

    _db.SaveChanges();

    MessageBox.Show("Pagamento registrato!");
    this.Close();
}
private void btnTorna_Click(object sender, EventArgs e)
{
    this.Close();
}
private void btnPagamentoCompleto_Click(object sender, EventArgs e)
{
    txtPagato.Text = totaleScontato.ToString();
}
