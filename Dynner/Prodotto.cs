public class Prodotto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Prezzo { get; set; }

    public int CategoriaId { get; set; }

    public virtual ICollection<ComandaDettaglio> Dettagli { get; set; }
}
``
