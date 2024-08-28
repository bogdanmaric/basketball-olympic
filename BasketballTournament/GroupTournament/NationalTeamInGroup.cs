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
            fillPostionNumber();
            Points = 0;
        }

        private void fillPostionNumber()
        {
            if (placeInGroup == 5)
            {
                placeInGroup = 1;
            }

            Position = placeInGroup++;
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
