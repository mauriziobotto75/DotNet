using System;

public class PrintingService
{
    public void StampaFattura(Comanda comanda)
    {
        Console.WriteLine("===== FATTURA =====");

        foreach (var d in comanda.Dettagli)
        {
            Console.WriteLine($"{d.Descrizione} x{d.Quantita} = {d.Totale}");
        }

        Console.WriteLine("Totale: " + comanda.Dettagli.Sum(x => x.Totale));
    }
}
