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

        public void OrderTeams()
        {
            // Sort teams by Points in descending order
            var sortedTeams = NationalTeamInGroup
                .OrderByDescending(team => team.Points)
                .ThenBy(team => GetRankByMutualResults(team))
                .ThenBy(team => GetRankByRoundFormation(team))
                .ToList();

            NationalTeamInGroup = sortedTeams;
            // Update Position field for each team
            for (int i = 0; i < NationalTeamInGroup.Count; i++)
            {
                NationalTeamInGroup[i].Position = i + 1; // Position starts from 1
            }
        }

        private int GetRankByMutualResults(NationalTeamInGroup team)
        {
           var tiedTeams = NationalTeamInGroup
                        .Where(t => t.Points == team.Points)
                        .ToList();

            if (tiedTeams.Count == 2)
            {
                var opponent = tiedTeams.First(t => t != team);
                if (team.wonAgainst.Contains(opponent))
                {
                    return 1; // Higher rank
                }
                else
                {
                    return -1; // Lower rank
                }
            }

            return 0; // No tie or three-team tie
        }

        private int GetRankByRoundFormation(NationalTeamInGroup team)
        {
            return team.NationalTeam.TeamStats.DifferenceScoreReceivedPoints;
        }

        public void simulateMatchesInGroup() 
        {
            Console.WriteLine($"Grupa {Name}:");
            for (int i = 0; i < NationalTeamInGroup.Count - 1; i++) 
            {
                Console.WriteLine($"\tTim {NationalTeamInGroup[i].NationalTeam.Team}:");
                for (int j = i + 1; j < NationalTeamInGroup.Count; j++)
                {
                    PlayGroupMatch playGroupMatch = new PlayGroupMatch(NationalTeamInGroup[i], NationalTeamInGroup[j]);
                    playGroupMatch.PlayMatch();
                    Console.WriteLine(playGroupMatch);
                }
            }

            OrderTeams();
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