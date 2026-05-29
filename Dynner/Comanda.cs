public class Comanda
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public int TavoloId { get; set; }
    public int Coperti { get; set; }
    public decimal Totale { get; set; }

    public virtual ICollection<ComandaDettaglio> Dettagli { get; set; }
}
