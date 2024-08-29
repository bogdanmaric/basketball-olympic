using BasketballTournament.GroupPhase;
using BasketballTournament.Simulation;
using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace BasketballTournament
{

	internal class Group
    {
        public string Name { get; set; }

        public List<NationalTeamInGroup> NationalTeamInGroup { get; set; }

        public Group(string name)
        {
            Name = name;
            NationalTeamInGroup = new List<NationalTeamInGroup>();
        }

        public string UpdateGroupPositions()
        {
            return "Update Group Positions";
        }

        public void simulateMatchesInGroup() 
        {
            for (int i = 0; i < NationalTeamInGroup.Count - 1; i++) 
            {
                for (int j = i + 1; j < NationalTeamInGroup.Count; j++)
                {
                    Console.WriteLine($"{NationalTeamInGroup[i].NationalTeam.Team} vs {NationalTeamInGroup[j].NationalTeam.Team} (j)");
                    var result = SimulationBasketballGame.SimulateGame(NationalTeamInGroup[i], NationalTeamInGroup[j]);
                    if (result.teamAScore > result.teamBScore)
                    {
                        NationalTeamInGroup[i].UpdateStats(result.teamAScore, result.teamBScore, true);
                        NationalTeamInGroup[j].UpdateStats(result.teamBScore, result.teamAScore, false);

                    } else
                    {
                        NationalTeamInGroup[i].UpdateStats(result.teamAScore, result.teamBScore, false);
                        NationalTeamInGroup[j].UpdateStats(result.teamBScore, result.teamAScore, true);
                    }
                }
            }
        }

        public override string ToString()
        {
            string result = $"\tGrupa {Name} (Ime - pobede/porazi/bodovi/postignuti koševi/primljeni koševi/koš razlika):\n";
            foreach (var teamInGroup in NationalTeamInGroup) 
            {
                result += $"{teamInGroup}"; 
            }
            return result;
        }
    }

}