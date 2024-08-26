using BasketballTournament;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        string pathGroups = "D:\\Projects\\Visual Studio\\BasketballTournament\\BasketballTournament\\task\\groups.json";

        string jsonString = File.ReadAllText(pathGroups);

        var groupData = JsonSerializer.Deserialize<Dictionary<string, List<Country>>>(jsonString);

        foreach (var group in groupData)
        {
            Console.WriteLine($"Group {group.Key}:");
            foreach (var country in group.Value)
            {
                Console.WriteLine($"  Team: {country.Team}, ISO Code: {country.ISOCode}, FIBA Ranking: {country.FIBARanking}");
            }
        }
    }
}