public class ComandaService
{
    private RistorazioneEntities _db;

    public ComandaService(RistorazioneEntities db)
    {
        _db = db;
    }

    public Comande CreaNuova(int tavoloId)
    {
        var c = new Comande
        {
            Data = DateTime.Now,
            TavoloId = tavoloId
        };

        _db.Comande.Add(c);
        _db.SaveChanges();

        return c;
    }

    public Comande Carica(int id)
    {
        return _db.Comande
            .Include("Comande_Dettaglio.Prodotti")
            .First(x => x.Id == id);
    }

    public void AggiungiProdotto(Comande comanda, Prodotti prodotto)
    {
        var riga = comanda.Comande_Dettaglio
            .FirstOrDefault(d => d.ProdottoId == prodotto.Id);

        if (riga != null)
        {
            riga.Quantita++;
            riga.Importo = riga.Quantita * riga.Prezzo;
        }
        else
        {
            comanda.Comande_Dettaglio.Add(new Comande_Dettaglio
            {
                ProdottoId = prodotto.Id,
                Quantita = 1,
                Prezzo = prodotto.Prezzo,
                Importo = prodotto.Prezzo
            });
        }

        _db.SaveChanges();
    }
}
