 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.SqlClient;

namespace CampionatoCalcio
{
    class Program
    {
        static string connectionString = "Server=localhost;Database=CAMPIONATO;Trusted_Connection=True;";

        static List<(int, int)> risultati = new List<(int, int)>
        {
            (2,2), (1,1), (0,0), (2,2), (1,1), (3,0), (0,0), (3,1), (0,4), (3,0)
        };

        Process.Start(@"C:\Users\MBOTTO\source\repos\Stampa_Calendario_Campionato_Calcio_2025_26\bin\debug\Net8.0\Stampa_Calendario_Campionato_Calcio_2025_26.exe");

            // 2. Simula elenco partite (da sostituire con lettura reale)
            List<(string, string)> partite = new List<(string, string)>
            {
                ("Atalanta", "Verona"),
                ("Bologna", "Udinese"),
                ("Cagliari", "Torino"),
                ("Empoli", "Sassuolo"),
                ("Fiorentina", "Salernitana"),
                ("Frosinone", "Roma"),
                ("Genoa", "Napoli"),
                ("Inter", "Monza"),
                ("Juventus", "Milan"),
                ("Lazio", "Lecce")
            };

            // 3. Applica risultati
            for (int i = 0; i < partite.Count; i++)
            {
                var (squadra1, squadra2) = partite[i];
                var (gol1, gol2) = risultati[i];

                AggiornaClassifica(squadra1, squadra2, gol1, gol2);
            }

            Console.WriteLine("Classifica aggiornata con successo.");
        }

        static void AggiornaClassifica(string squadra1, string squadra2, int gol1, int gol2)
        {
            int punti1 = 0, punti2 = 0;
            int vinte1 = 0, vinte2 = 0;
            int nulle1 = 0, nulle2 = 0;

            if (gol1 > gol2)
            {
                punti1 = 3; vinte1 = 1;
            }

             else if (gol2 > gol1)
            {
                punti2 = 3; vinte2 = 1;
            }
            else
            {
                punti1 = punti2 = 1;
                nulle1 = nulle2 = 1;
            }

            AggiornaDB(squadra1, punti1, vinte1, nulle1, gol1, gol2);
            AggiornaDB(squadra2, punti2, vinte2, nulle2, gol2, gol1);
        }

        static void AggiornaDB(string squadra, int punti, int vinte, int nulle, int golFatti, int golSubiti)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                   string query = @" UPDATE dbo.CLASSIFICA
                    SET 
                        Punti = Punti + @Punti,
                        Vinte = Vinte + @Vinte,
                        Nulle = Nulle + @Nulle,
                        GolFatti = GolFatti + @GolFatti,
                        GolSubiti = GolSubiti + @GolSubiti,
                        Giocate = Giocate + 1
                    WHERE Squadra = @Squadra"; 

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Punti", punti);
                    cmd.Parameters.AddWithValue("@Vinte", vinte);
                    cmd.Parameters.AddWithValue("@Nulle", nulle);
                    cmd.Parameters.AddWithValue("@GolFatti", golFatti);
                    cmd.Parameters.AddWithValue("@GolSubiti", golSubiti);
                    cmd.Parameters.AddWithValue("@Squadra", squadra);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
