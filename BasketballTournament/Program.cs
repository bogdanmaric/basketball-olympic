using BasketballTournament;
using BasketballTournament.EliminationTournament;
using BasketballTournament.GroupPhase;
using System.Text.Json;
using System.Text.RegularExpressions;
using Group = BasketballTournament.Group;

internal class Program
{
    private static void Main(string[] args)
    {
        string pathGroups = "D:\\Projects\\Visual Studio\\BasketballTournament\\BasketballTournament\\task\\groups.json";
        string jsonString = File.ReadAllText(pathGroups);
        var dataForGroups = JsonSerializer.Deserialize<Dictionary<string, List<NationalTeam>>>(jsonString);

        // Creating every Group and put all of them in List of groups, which will be given to GroupStage
        List<Group> groups = new List<Group>();
        foreach (var groupData in dataForGroups) 
        {
            Group group = new Group(groupData.Key);
            foreach (var nationalTeam in groupData.Value) {
                group.NationalTeamInGroup.Add(new NationalTeamInGroup(nationalTeam));
            }
            groups.Add(group);
        }

        GroupPhase groupPhase = new GroupPhase(groups);
        groupPhase.SimulateGroupPhase();
        groupPhase.DisplayNationalTeamsRanking();

        //-----------------//
        //Eliminaiton Phase//
        //-----------------//

        //Teams with 1-8 rank are going to elimination phase
        EliminationPhase eliminationPhase = new EliminationPhase(groupPhase.NationalTeamsRanking.Take(8).ToList());
        eliminationPhase.SetEliminationPhase();


    }
}