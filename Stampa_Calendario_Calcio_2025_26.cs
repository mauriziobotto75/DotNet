using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> squadre = new List<string>
 {
 "Atlanta", "Pisa", "Cagliari", "Fiorentina", "Como",
 "Lazio", "Genoa", "Lecce", "Inter", "Torino",
 "Juventus", "Parma", "Milan", "Cremonese", "Roma",
 "Bologna", "Sassuolo", "Napoli", "Udinese", "Verona"
 };

        int numGiornate = 19;
        int numPartitePerGiornata = squadre.Count / 2;

        List<List<(string, string)>> calendarioAndata = new List<List<(string, string)>>();

        // Genera calendario andata con algoritmo round-robin
        List<string> squadreTemp = new List<string>(squadre);
        if (squadreTemp.Count % 2 != 0)

            squadreTemp.Add("Riposo");

        int numSquadre = squadreTemp.Count;

        for (int giornata = 0; giornata < numGiornate; giornata++)
        {
            List<(string, string)> partite = new List<(string, string)>();

            for (int i = 0; i < numSquadre / 2; i++)
            {
                string casa = squadreTemp[i];
                string trasferta = squadreTemp[numSquadre - 1 - i];
                partite.Add((casa, trasferta));
            }

            calendarioAndata.Add(partite);

            // Rotazione delle squadre (tranne la prima)
            List<string> nuoveSquadre = new List<string>();
            nuoveSquadre.Add(squadreTemp[0]);
            nuoveSquadre.Add(squadreTemp[numSquadre - 1]);

            for (int i = 1; i < numSquadre - 1; i++)
                nuoveSquadre.Add(squadreTemp[i]);

            squadreTemp = nuoveSquadre;
        }

        // Stampa calendario andata
        for (int i = 0; i < calendarioAndata.Count; i++)
        {
            Console.WriteLine($"Giornata {i + 1}");
            foreach (var partita in calendarioAndata[i])
                Console.WriteLine($"{partita.Item1} vs {partita.Item2}");
            Console.WriteLine();
        }

        // Stampa calendario ritorno (squadre invertite)
        for (int i = 0; i < calendarioAndata.Count; i++)
        {
            Console.WriteLine($"Giornata {i + 20}");
            foreach (var partita in calendarioAndata[i])
                Console.WriteLine($"{partita.Item2} vs {partita.Item1}");
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}
