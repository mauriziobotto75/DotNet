public class PagamentoService
{
    private RistorazioneEntities _db;

    public PagamentoService(RistorazioneEntities db)
    {
        _db = db;
    }

    public void Paga(Comande comanda, decimal sconto, decimal pagato, int tipoPagamentoId)
    {
        decimal totale = comanda.Comande_Dettaglio.Sum(d => d.Importo);
        decimal totaleScontato = totale - (totale * sconto / 100);

        var p = new Pagamenti
        {
            ComandaId = comanda.Id,
            Totale = totale,
            ScontoPercentuale = sconto,
            TotaleScontato = totaleScontato,
            ImportoPagato = pagato,
            Resto = pagato - totaleScontato,
            TipoPagamentoId = tipoPagamentoId
        };

        _db.Pagamenti.Add(p);

        comanda.Totale = totaleScontato;

        _db.SaveChanges();
    }
}
