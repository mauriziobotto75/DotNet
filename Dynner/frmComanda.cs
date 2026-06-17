


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
private void CaricaDettagli()
{
    dgv.DataSource = null;

    var righe = db.ComandeDettagli
        .Where(x => x.ComandaId == comanda.Id)
        .Select(x => new
        {
            x.Quantita,
            Nome = x.Prodotto.Nome,
            x.Importo
        }).ToList();

    dgv.DataSource = righe;
}
private void CaricaCategorie()
{
    var categorie = _db.Menu.ToList();

    pnlCategorie.Controls.Clear();

    foreach (var c in categorie)
    {
        var btn = new Button();
        btn.Text = c.Nome;
        btn.Width = 120;
        btn.Height = 60;

        btn.Click += (s, e) => CaricaProdotti(c.Id);

        pnlCategorie.Controls.Add(btn);
    } 
    comanda = new Comanda
{
    Data = DateTime.Now,
    TavoloId = _tavoloId,
    Dettagli = new List<ComandaDettaglio>()
};

db.Comande.Add(comanda);
db.SaveChanges(); // ← crea ID reale
    private void CaricaProdotti(int menuId)
{
    var prodotti = _db.MenuProdotti
        .Where(mp => mp.MenuId == menuId)
        .Select(mp => mp.Prodotto)
        .ToList();

    pnlProdotti.Controls.Clear();

    foreach (var p in prodotti)
    {
        var btn = new Button();
        btn.Text = $"{p.Nome}\n{p.Prezzo:C}";
        btn.Width = 120;
        btn.Height = 80;

        btn.Click += (s, e) => AggiungiProdotto(p);

        pnlProdotti.Controls.Add(btn);
    } 
 private void AggiungiProdotto(Prodotto p)
{
    var riga = db.ComandeDettagli
        .FirstOrDefault(x => x.ComandaId == comanda.Id && x.ProdottoId == p.Id);

    if (riga != null)
    {
        riga.Quantita++;
        riga.Importo = riga.Quantita * riga.Prezzo;
    }
    else
    {
        db.ComandeDettagli.Add(new ComandaDettaglio
        {
            ComandaId = comanda.Id,
            ProdottoId = p.Id,
            Quantita = 1,
            Prezzo = p.Prezzo,
            Importo = p.Prezzo
        });
    }

    db.SaveChanges();

    CaricaDettagli();
}

    RefreshGrid();
    AggiornaTotale();
} private void RefreshGrid()
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
        private void AggiornaTotale()
{
    decimal totale = _comandaCorrente.Dettagli.Sum(d => d.Importo);
    lblTotale.Text = totale.ToString("C");
}
        private void SalvaComanda()
{
    _comandaCorrente.Totale = _comandaCorrente.Dettagli.Sum(d => d.Importo);

    _db.Comande.Add(_comandaCorrente);
    _db.SaveChanges();

    MessageBox.Show("Comanda salvata!");
} 
        private void EliminaRiga()
{
    if (dgvComanda.CurrentRow == null) return;

    int index = dgvComanda.CurrentRow.Index;
    _comandaCorrente.Dettagli.RemoveAt(index);

    RefreshGrid();
    AggiornaTotale();
}
}
}
