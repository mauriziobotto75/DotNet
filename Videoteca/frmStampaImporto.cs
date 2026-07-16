public decimal CalcolaImporto(
    DateTime dataNoleggio,
    DateTime dataReso,
    decimal costoGiornaliero)
{
    int giorni =
        (dataReso - dataNoleggio).Days + 1;

    return giorni * costoGiornaliero;
}
