using System.Data.Entity;

public class RistorazioneContext : DbContext
{
    public RistorazioneContext() : base("name=RistorazioneDb") { }

    public DbSet<Cliente> Clienti { get; set; }
    public DbSet<Comanda> Comande { get; set; }
    public DbSet<ComandaDettaglio> ComandeDettagli { get; set; }
    public DbSet<Prodotto> Prodotti { get; set; }
    public DbSet<Menu> Menu { get; set; }
    public DbSet<MenuProdotto> MenuProdotti { get; set; }
}
``
