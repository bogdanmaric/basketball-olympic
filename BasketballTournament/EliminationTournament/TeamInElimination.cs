using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament.EliminationTournament
{
    internal class TeamInElimination
    {
        public NationalTeam FirstTeam { get; set; }
        public NationalTeam SecondTeam { get; set; }
        public int FirstTeamScore { get; set; }
        public int SecondTeamScore { get; set; }

        public TeamInElimination(NationalTeam firstTeam, NationalTeam secondTeam) 
        { 
            FirstTeam = firstTeam;
            SecondTeam = secondTeam;
            FirstTeamScore = 0;
            SecondTeamScore = 0;
        }

        public NationalTeam PlayMatch()
        {
            Random rnd = new Random();
            int rankingDifference = FirstTeam.FIBARanking - SecondTeam.FIBARanking;

            int baseScoreA = rnd.Next(70, 100);
            int baseScoreB = rnd.Next(70, 100);

            int scoreAdjustment = rankingDifference / 10;
            baseScoreA += scoreAdjustment;
            baseScoreB -= scoreAdjustment;

            baseScoreA = Math.Max(baseScoreA, 60);
            baseScoreB = Math.Max(baseScoreB, 60);

            return (FirstTeamScore > SecondTeamScore) ? FirstTeam : SecondTeam;
        }
    }
}
