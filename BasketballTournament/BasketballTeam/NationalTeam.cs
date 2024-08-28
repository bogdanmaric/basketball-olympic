using BasketballTournament.BasketballTeam;
using BasketballTournament.GroupPhase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament
{
    internal class NationalTeam
    {
        public string Team { get; set; }
        public string ISOCode { get; set; }
        public int FIBARanking { get; set; }
        public TeamStats TeamStats { get; set; }


        public NationalTeam(string team, string isoCode, int fibaRanking)
        {
            Team = team;
            ISOCode = isoCode;
            FIBARanking = fibaRanking;
            TeamStats = new TeamStats();
        }
    }
}
