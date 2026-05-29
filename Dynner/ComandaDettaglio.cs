public class ComandaDettaglio
{
    public int Id { get; set; }

    public int ComandaId { get; set; }
    public int ProdottoId { get; set; }

    public int Quantita { get; set; }
    public decimal Prezzo { get; set; }
    public decimal Importo { get; set; }

    public virtual Comanda Comanda { get; set; }
    public virtual Prodotto Prodotto { get; set; }
}
