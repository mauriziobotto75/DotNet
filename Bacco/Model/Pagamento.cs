public class Pagamento
{
    public int Id { get; set; }
    public int ComandaId { get; set; }

    public decimal Totale { get; set; }
    public decimal Sconto { get; set; }
    public decimal Netto { get; set; }
    public decimal Contanti { get; set; }
    public decimal Carta { get; set; }
    public decimal Resto { get; set; }
}
