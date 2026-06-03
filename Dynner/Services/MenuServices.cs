public class MenuService
{
    private RistorazioneEntities _db;

    public MenuService(RistorazioneEntities db)
    {
        _db = db;
    }

    public Menu Carica(int id)
    {
        return _db.Menu
            .Include("Menu_Prodotti.Prodotti")
            .First(m => m.Id == id);
    }

    public void AggiungiProdotto(Menu menu, Prodotti prodotto, string categoria)
    {
        menu.Menu_Prodotti.Add(new Menu_Prodotti
        {
            ProdottoId = prodotto.Id,
            Categoria = categoria
        });

        _db.SaveChanges();
    }
}
