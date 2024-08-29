using BasketballTournament.GroupPhase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament.Simulation
{
    internal class SimulationBasketballGame
    {
        public static (int teamAScore, int teamBScore) SimulateGame(NationalTeamInGroup teamA, NationalTeamInGroup teamB)
        {
            Random rnd = new Random();
            int rankingDifference = teamA.NationalTeam.FIBARanking - teamB.NationalTeam.FIBARanking;

            int baseScoreA = rnd.Next(70, 100);
            int baseScoreB = rnd.Next(70, 100);

            int scoreAdjustment = rankingDifference / 10;
            baseScoreA += scoreAdjustment;
            baseScoreB -= scoreAdjustment;

            baseScoreA = Math.Max(baseScoreA, 60);
            baseScoreB = Math.Max(baseScoreB, 60);

            return (baseScoreA, baseScoreB);
        }


    }
}
