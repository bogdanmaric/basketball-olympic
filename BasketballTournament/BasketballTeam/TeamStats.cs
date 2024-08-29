using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BasketballTournament.BasketballTeam
{
    internal class TeamStats
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int ScoredPoints { get; set; }
        public int ReceivedPoints { get; set; }
        public int DifferenceScoreReceivedPoints { get; set; }

        public TeamStats()
        {
            Wins = 0;
            Losses = 0;
            ScoredPoints = 0;
            ReceivedPoints = 0;
            DifferenceScoreReceivedPoints = 0;
        }

        public void UpdateTeamStats(int scored, int received)
        {
            ScoredPoints += scored;
            ReceivedPoints += received;
            if (scored > received)
            {
                Wins++;
            }
            else
            {
                Losses++;
            }
            DifferenceScoreReceivedPoints += scored - received;
        }
    }
}
