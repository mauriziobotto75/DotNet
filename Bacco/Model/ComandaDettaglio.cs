public class ComandaDettaglio : BaseModel
{
    public int Id { get; set; }
    public int ComandaId { get; set; }
    public string Descrizione { get; set; }
    public int Quantita { get; set; }
    public decimal Prezzo { get; set; }

    public decimal Totale => Quantita * Prezzo;
}
