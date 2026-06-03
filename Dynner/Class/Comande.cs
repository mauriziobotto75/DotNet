public partial class Comande
{
    public decimal TotaleCalcolato()
    {
        return Comande_Dettaglio.Sum(x => x.Importo);
    }
}
