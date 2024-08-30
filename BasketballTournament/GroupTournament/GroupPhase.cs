using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament.GroupPhase
{
    internal class GroupPhase
    {
        public List<Group> Groups {  get; set; }
        public List<NationalTeamInGroup> NationalTeamsRanking { get; set; }

        public GroupPhase(List<Group> groups) 
        { 
            Groups = groups;
        }

        public GroupPhase()
        {
            Groups = new List<Group>();
        }

        public void SimulateGroupPhase()
        {
            foreach (var group in Groups) 
            {
                group.simulateMatchesInGroup();
            }
            RankTeamsAfterGroupStage();
        }

        public void RankTeamsAfterGroupStage()
        {
            var firstPlacedTeams = Groups.Select(group => group.NationalTeamInGroup.First()).ToList();
            var secondPlacedTeams = Groups.Select(group => group.NationalTeamInGroup.Skip(1).First()).ToList();
            var thirdPlacedTeams = Groups.Select(group => group.NationalTeamInGroup.Skip(2).First()).ToList();

            // Rank each group of teams
            var rankedFirstPlaced = RankTeams(firstPlacedTeams);
            var rankedSecondPlaced = RankTeams(secondPlacedTeams);
            var rankedThirdPlaced = RankTeams(thirdPlacedTeams);

            // Combine the rankings
            var finalRankings = rankedFirstPlaced.Concat(rankedSecondPlaced).Concat(rankedThirdPlaced).ToList();

            // Assign the final positions
            for (int i = 0; i < finalRankings.Count; i++)
            {
                finalRankings[i].Position = i + 1;
            }

            NationalTeamsRanking = finalRankings;

            // Teams ranked 1 to 8 go to elimination stage
            //NationalTeamsRanking = finalRankings.Take(8).ToList();
        }

        private List<NationalTeamInGroup> RankTeams(List<NationalTeamInGroup> teams)
        {
            return teams
                .OrderByDescending(team => team.Points)
                .ThenByDescending(team => team.NationalTeam.TeamStats.DifferenceScoreReceivedPoints) // Goal difference
                .ThenByDescending(team => team.NationalTeam.TeamStats.ScoredPoints) // Number of goals scored
                .ToList();
        }

        public void DisplayNationalTeamsRanking()
        {
            Console.WriteLine("\nRangiranje timova:\n");
            foreach (var team in NationalTeamsRanking)
            {
                Console.WriteLine(team);
            }
        }

        public override string ToString()
        {
            string result = "";
            result = "\nKonačan plasman u grupama:\n";
            foreach (var group in Groups) 
            {
                result += $"{group}";
            }
            return result;
        }
    }
}
