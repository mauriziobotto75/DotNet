public class Pagamento
{
    public int Id { get; set; }

    public int ComandaId { get; set; }
    public decimal Totale { get; set; }
    public decimal ScontoPercentuale { get; set; }
    public decimal TotaleScontato { get; set; }
    public decimal ImportoPagato { get; set; }
    public decimal Resto { get; set; }

    public int TipoPagamentoId { get; set; }

    public virtual Comanda Comanda { get; set; }
    public virtual TipoPagamento TipoPagamento { get; set; }
}
