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
}
