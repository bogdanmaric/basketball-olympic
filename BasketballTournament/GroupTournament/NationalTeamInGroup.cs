using BasketballTournament.BasketballTeam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament.GroupPhase
{
    internal class NationalTeamInGroup
    {
        public NationalTeam NationalTeam { get; set; }
        public int Points { get; set; }
        public int Position { get; set; }

        public static int placeInGroup = 1;
        public List<NationalTeamInGroup> wonAgainst { get; set; }

        public NationalTeamInGroup(NationalTeam nationalTeam) 
        {
            NationalTeam = nationalTeam;
            Points = 0;
            wonAgainst = new List<NationalTeamInGroup>();
            fillPostionNumber();
        }

        private void fillPostionNumber()
        {
            if (placeInGroup == 5)
            {
                placeInGroup = 1;
            }

            Position = placeInGroup++;
        }

        public void UpdateStats(int thisTeamScore, int opponentTeamScore, bool thisTeamWon)
        {
            if (thisTeamWon) 
            {
                Points += 2;
            }
            NationalTeam.TeamStats.UpdateTeamStats(thisTeamScore, opponentTeamScore);
        }

        public override string ToString()
        {
            
            string result = string.Format("\t{0,2}. {1,-20} {2} / {3} / {4} / {5} / {6} / {7}\n",
                Position, NationalTeam.Team, NationalTeam.TeamStats.Wins, NationalTeam.TeamStats.Losses, Points, NationalTeam.TeamStats.ScoredPoints, NationalTeam.TeamStats.ReceivedPoints, NationalTeam.TeamStats.DifferenceScoreReceivedPoints);
            return result;
        }

    }
}
