using BasketballTournament.GroupPhase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament.Simulation
{
    internal class PlayGroupMatch
    {
        public NationalTeamInGroup Team1 { get; set; }
        public NationalTeamInGroup Team2 { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }

        public PlayGroupMatch(NationalTeamInGroup team1, NationalTeamInGroup team2)
        {
            Team1 = team1;
            Team2 = team2;
            Team1Score = 0;
            Team2Score = 0;
        }

        public void PlayMatch()
        {

            Random rnd = new Random();
            int rankingDifference = Team1.NationalTeam.FIBARanking - Team2.NationalTeam.FIBARanking;

            Team1Score = rnd.Next(70, 100);
            Team2Score = rnd.Next(70, 100);

            int scoreAdjustment = rankingDifference / 10;
            Team1Score += scoreAdjustment;
            Team2Score -= scoreAdjustment;

            Team1Score = Math.Max(Team1Score, 60);
            Team2Score = Math.Max(Team2Score, 60);

            if (Team1Score > Team2Score)
            {
                Team1.UpdateStats(Team1Score, Team2Score, true);
                Team1.wonAgainst.Add(Team2);
                Team2.UpdateStats(Team2Score, Team1Score, false);
            } else
            {
                Team2.UpdateStats(Team2Score, Team1Score, true);
                Team2.wonAgainst.Add(Team1);
                Team1.UpdateStats(Team1Score, Team2Score, false);
            }

            Team1.playedAgainst.Add(Team2);
            Team2.playedAgainst.Add(Team1);
        }

        public override string ToString()
        {
            string result = $"\t\t{Team1.NationalTeam.Team} - {Team2.NationalTeam.Team} ({Team1Score}:{Team2Score})";
            return result;
        }
    }
}
