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

        public NationalTeamInGroup(NationalTeam nationalTeam) 
        {
            NationalTeam = nationalTeam;
            Points = 0;
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
            Points += (thisTeamWon) ? 2 : 1;
            NationalTeam.TeamStats.UpdateTeamStats(thisTeamScore, opponentTeamScore);
        }

        public override string ToString()
        {
            string result = $"\t\t{Position}. {NationalTeam.Team} " +
                $"{NationalTeam.TeamStats.Wins}/{NationalTeam.TeamStats.Losses}/{Points}" +
                $"/{NationalTeam.TeamStats.ScoredPoints}/{NationalTeam.TeamStats.ReceivedPoints}" +
                $"/{NationalTeam.TeamStats.DifferenceScoreReceivedPoints}\n";
            return result;
        }

    }
}
