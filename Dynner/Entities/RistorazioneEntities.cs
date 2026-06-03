public partial class RistorazioneEntities : DbContext
{
    public virtual DbSet<Comande> Comande { get; set; }
    public virtual DbSet<Prodotti> Prodotti { get; set; }
    public virtual DbSet<Menu> Menu { get; set; }
    public virtual DbSet<Pagamenti> Pagamenti { get; set; }
}
