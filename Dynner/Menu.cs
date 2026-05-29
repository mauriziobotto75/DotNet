 public class Menu
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public decimal Prezzo { get; set; }
    public decimal PrezzoImposto { get; set; }

    public bool StampaDettaglio { get; set; }
    public int CodiceIva { get; set; }

    public virtual ICollection<MenuProdotto> Prodotti { get; set; }
}
``

