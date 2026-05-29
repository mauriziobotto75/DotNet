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
}
