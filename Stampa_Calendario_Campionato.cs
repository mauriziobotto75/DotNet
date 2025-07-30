 using System;
using System.Collections.Generic;
using System.Linq;

class SerieACalendar
{
    static List<string> teams = new List<string> {
        "Atalanta", "Pisa", "Cagliari", "Fiorentina", "Como",
        "Lazio", "Genoa", "Lecce", "Inter", "Torino",
        "Juventus", "Parma", "Milan", "Cremonese", "Roma",
        "Bologna", "Sassuolo", "Napoli", "Udinese", "Verona"
    };

    static List<(string, string)> derbies = new List<(string, string)> {
        ("Juventus", "Torino"),
        ("Milan", "Inter"),
        ("Lazio", "Roma"),
        ("Fiorentina", "Pisa")
    };

    static HashSet<string> championsLeague = new HashSet<string> { "Napoli", "Inter", "Juventus", "Atalanta" };
    static HashSet<string> europaLeague = new HashSet<string> { "Roma", "Bologna" };
    static HashSet<string> conferenceLeague = new HashSet<string> { "Fiorentina" };
    static HashSet<int> europeanMatchDays = new HashSet<int> { 5, 22, 26, 29, 32, 35 };

    static List<(string, string)> alternationPairs = new List<(string, string)> {
        ("Milan", "Inter"),
        ("Lazio", "Roma"),
        ("Juventus", "Torino"),
        ("Fiorentina", "Pisa")
    };

    static Dictionary<int, List<(string, string)>> calendar = new Dictionary<int, List<(string, string)>>();

    static Dictionary<string, List<string>> homeAwayTracker = new Dictionary<string, List<string>>();

    static void Main()
    {
        foreach (var team in teams)
            homeAwayTracker[team] = new List<string>();

        GenerateCalendar();
        PrintCalendar();
    }

    static void GenerateCalendar()
    {
        var matches = new List<(string, string)>();
        for (int i = 0; i < teams.Count; i++)
        {
            for (int j = i + 1; j < teams.Count; j++)
            {
                matches.Add((teams[i], teams[j]));
            }
        }

        var rnd = new Random();
        var firstLeg = matches.OrderBy(x => rnd.Next()).ToList();
        var secondLeg = firstLeg.Select(m => (m.Item2, m.Item1)).OrderBy(x => rnd.Next()).ToList();

        for (int day = 1; day <= 38; day++)
            calendar[day] = new List<(string, string)>();

        AssignMatches(firstLeg, 1, 19, rnd);
        AssignMatches(secondLeg, 20, 38, rnd);
    }

    static void AssignMatches(List<(string, string)> matchList, int startDay, int endDay, Random rnd)
    {
        int matchIndex = 0;
        for (int day = startDay; day <= endDay; day++)
        {
            while (calendar[day].Count < 10 && matchIndex < matchList.Count)
            {
                var match = matchList[matchIndex];
                matchIndex++;

                if (IsDerby(match) && (day == 1 || day == 9 || calendar[day].Any(IsDerby)))
                    continue;

                if (europeanMatchDays.Contains(day) && IsEuropeanConflict(match))
                    continue;

                if (!IsAlternationRespected(match, day))
                    continue;

                calendar[day].Add(match);
                homeAwayTracker[match.Item1].Add("H");
                homeAwayTracker[match.Item2].Add("A");
            }
        }
    }

    static bool IsDerby((string, string) match)
    {
        return derbies.Contains(match) || derbies.Contains((match.Item2, match.Item1));
    }

    static bool IsEuropeanConflict((string, string) match)
    {
        var allEuropean = championsLeague.Union(europaLeague).Union(conferenceLeague);
        return allEuropean.Contains(match.Item1) && allEuropean.Contains(match.Item2);
    }

    static bool IsAlternationRespected((string, string) match, int day)
    {
        foreach (var pair in alternationPairs)
        {
            if ((match.Item1 == pair.Item1 && match.Item2 == pair.Item2) ||
                (match.Item1 == pair.Item2 && match.Item2 == pair.Item1))
            {
                var home1 = homeAwayTracker[pair.Item1];
                var home2 = homeAwayTracker[pair.Item2];
                if (home1.Count > 0 && home2.Count > 0 &&
                    home1.Last() == "H" && home2.Last() == "H")
                    return false;
            }
        }
        return true;
    }

    static void PrintCalendar()
    {
        foreach (var day in calendar.Keys.OrderBy(k => k))
        {
            Console.WriteLine($"Giornata {day}:");
            foreach (var match in calendar[day])
            {
                Console.WriteLine($"  {match.Item1} vs {match.Item2}");
            }
            Console.WriteLine();
        }
    }
}
