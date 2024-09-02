using BasketballTournament.GroupPhase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament.Simulation
{
    internal class EliminationPhaseMatch
    {
        public NationalTeam Team1 { get; set; }
        public NationalTeam Team2 { get; set; }
        public NationalTeam TeamWon { get; set; }
        public NationalTeam TeamLost { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }

        public EliminationPhaseMatch(NationalTeam team1, NationalTeam team2)
        {
            Team1 = team1;
            Team2 = team2;
            Team1Score = 0;
            Team2Score = 0;
        }

        public void PlayMatchElimination()
        {

            Random rnd = new Random();
            int rankingDifference = Team1.FIBARanking - Team2.FIBARanking;

            Team1Score = rnd.Next(70, 100);
            Team2Score = rnd.Next(70, 100);

            int scoreAdjustment = rankingDifference / 10;
            Team1Score += scoreAdjustment;
            Team2Score -= scoreAdjustment;

            Team1Score = Math.Max(Team1Score, 60);
            Team2Score = Math.Max(Team2Score, 60);

            TeamWon = Team1Score > Team2Score ? Team1 : Team2;
            TeamLost = Team1Score < Team2Score ? Team1 : Team2;
        }

        public string DisplayResults()
        {
            string result = $"{Team1.Team} - {Team2.Team} ({Team1Score}:{Team2Score})";
            return result;
        }
    }
}
