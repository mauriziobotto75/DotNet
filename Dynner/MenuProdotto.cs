
 public class MenuProdotto
{
    public int Id { get; set; }

    public int MenuId { get; set; }
    public int ProdottoId { get; set; }

    public int Ordine { get; set; } // posizione nel menu
    public string Categoria { get; set; } // Antipasto, Primi, ecc.

    public virtual Menu Menu { get; set; }
    public virtual Prodotto Prodotto { get; set; }
}
