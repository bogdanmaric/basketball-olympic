using BasketballTournament.GroupPhase;
using BasketballTournament.Simulation;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament.EliminationTournament
{
    internal class EliminationPhase
    {
        public List<NationalTeamInGroup> rankedTeams;
        public List<(NationalTeamInGroup, NationalTeamInGroup)> firstQuarterFinal;
        public List<(NationalTeamInGroup, NationalTeamInGroup)> secondQuarterFinal;

        public List<NationalTeam> firstSemiFinal;
        public List<NationalTeam> secondSemiFinal;

        public Dictionary<int, NationalTeam> TeamWithMedals;

        public EliminationPhase(List<NationalTeamInGroup> rankedTeams)
        {
            this.rankedTeams = rankedTeams;
            firstQuarterFinal = new List<(NationalTeamInGroup, NationalTeamInGroup)> ();
            secondQuarterFinal = new List<(NationalTeamInGroup, NationalTeamInGroup)>();
            firstSemiFinal = new List<NationalTeam> ();
            secondSemiFinal = new List<NationalTeam> () ;
            TeamWithMedals = new Dictionary<int, NationalTeam> ();
        }

        public List<(NationalTeamInGroup, NationalTeamInGroup)> PairTeamsForQuarterFinals(
    List<NationalTeamInGroup> hatD,
    List<NationalTeamInGroup> hatG)
        {
            var quarterFinalPairs = new List<(NationalTeamInGroup, NationalTeamInGroup)>();
            NationalTeamInGroup teamD1 = hatD[0];
            NationalTeamInGroup teamD2 = hatD[1];
            NationalTeamInGroup teamG1 = hatG[0];
            NationalTeamInGroup teamG2 = hatG[1];

            if (teamD1.playedAgainst.Contains(teamG1))
            {
                // If teamD1 has played against teamG1, pair teamD1 with teamG2
                quarterFinalPairs.Add((teamD1, teamG2));
                quarterFinalPairs.Add((teamD2, teamG1));
            }
            else if (teamD1.playedAgainst.Contains(teamG2))
            {
                // If teamD1 has played against teamG2, pair teamD1 with teamG1
                quarterFinalPairs.Add((teamD1, teamG1));
                quarterFinalPairs.Add((teamD2, teamG2));
            }
            else
            {
                // If teamD1 hasn't played against either, pair them in order
                quarterFinalPairs.Add((teamD1, teamG1));
                quarterFinalPairs.Add((teamD2, teamG2));
            }

            return quarterFinalPairs;
        }


        public void SetEliminationPhase()
        {
            var hatD = new List<NationalTeamInGroup> { rankedTeams[0], rankedTeams[1] };
            var hatE = new List<NationalTeamInGroup> { rankedTeams[2], rankedTeams[3] };
            var hatF = new List<NationalTeamInGroup> { rankedTeams[4], rankedTeams[5] };
            var hatG = new List<NationalTeamInGroup> { rankedTeams[6], rankedTeams[7] };

            Console.WriteLine("Šeširi: \n");
            Console.WriteLine("\tŠešir D: \n");
            Console.WriteLine($"\t\t{hatD[0].NationalTeam.Team}\n\t\t{hatD[1].NationalTeam.Team}");
            Console.WriteLine("\tŠešir E: \n");
            Console.WriteLine($"\t\t{hatE[0].NationalTeam.Team}\n\t\t{hatE[1].NationalTeam.Team}");
            Console.WriteLine("\tŠešir F: \n");
            Console.WriteLine($"\t\t{hatF[0].NationalTeam.Team}\n\t\t{hatF[1].NationalTeam.Team}");
            Console.WriteLine("\tŠešir G: \n");
            Console.WriteLine($"\t\t{hatG[0].NationalTeam.Team}\n\t\t{hatG[1].NationalTeam.Team}");


            var quarterFinals = new List<(NationalTeamInGroup, NationalTeamInGroup)>();

            var random = new Random();

            var availableTeamsInHatG = new List<NationalTeamInGroup>(hatG);
            var availableTeamsInHatF = new List<NationalTeamInGroup>(hatF);

           
            firstQuarterFinal = PairTeamsForQuarterFinals(hatD, hatG);
            secondQuarterFinal = PairTeamsForQuarterFinals(hatE, hatF);
            DisplayEliminationPhase();
            QuarterFinal();
        }

        public void QuarterFinal()
        {
            List<NationalTeam> firstSemi = new List<NationalTeam>();
            List<NationalTeam> secondSemi = new List<NationalTeam>();
            Console.WriteLine("Četvrtfinale:");
            foreach (var team in firstQuarterFinal)
            {
                EliminationPhaseMatch eliminationMatch = new EliminationPhaseMatch(team.Item1.NationalTeam, team.Item2.NationalTeam);
                eliminationMatch.PlayMatchElimination();
                if (eliminationMatch.Team1Score > eliminationMatch.Team2Score)
                {
                    firstSemiFinal.Add(team.Item1.NationalTeam);
                } else
                {
                    firstSemiFinal.Add(team.Item2.NationalTeam);
                }
                Console.WriteLine($"\t{eliminationMatch.DisplayResults()}");
            }
            Console.WriteLine();
            foreach (var team in secondQuarterFinal)
            {
                EliminationPhaseMatch eliminationMatch = new EliminationPhaseMatch(team.Item1.NationalTeam, team.Item2.NationalTeam);
                eliminationMatch.PlayMatchElimination();
                if (eliminationMatch.Team1Score > eliminationMatch.Team2Score)
                {
                    secondSemiFinal.Add(team.Item1.NationalTeam);
                }
                else
                {
                    secondSemiFinal.Add(team.Item2.NationalTeam);
                }
                Console.WriteLine($"\t{eliminationMatch.DisplayResults()}");
            }
            SeminFinal();
        }

        public void SeminFinal()
        {
            Console.WriteLine("\nPolufinale: ");
            EliminationPhaseMatch firstSemiFinalMatch = new EliminationPhaseMatch(firstSemiFinal[0], secondSemiFinal[1]);
            firstSemiFinalMatch.PlayMatchElimination();
            Console.WriteLine($"\t{firstSemiFinalMatch.DisplayResults()}");

            EliminationPhaseMatch secondSemiFinalMatch = new EliminationPhaseMatch(secondSemiFinal[0], firstSemiFinal[1]);
            secondSemiFinalMatch.PlayMatchElimination();
            Console.WriteLine($"\t{secondSemiFinalMatch.DisplayResults()}");

            (NationalTeam, NationalTeam) finalist = (firstSemiFinalMatch.TeamWon, secondSemiFinalMatch.TeamWon);
            (NationalTeam, NationalTeam) thirdPlaceCompeteTeams = (firstSemiFinalMatch.TeamLost, secondSemiFinalMatch.TeamLost);

            ThirdPlace(thirdPlaceCompeteTeams);
            Final(finalist);
            MedalCeremony();
        }

        public void ThirdPlace((NationalTeam, NationalTeam) thirdPlaceMatchTeams)
        {
            Console.WriteLine("\nUtakmica za treće mesto:");
            EliminationPhaseMatch thirdPlaceMatch = new EliminationPhaseMatch(thirdPlaceMatchTeams.Item1, thirdPlaceMatchTeams.Item2);
            thirdPlaceMatch.PlayMatchElimination();
            Console.WriteLine($"\t{thirdPlaceMatch.DisplayResults()}");
            TeamWithMedals.Add(3, thirdPlaceMatch.TeamWon);
        }

        public void Final((NationalTeam, NationalTeam) finalist)
        {
            Console.WriteLine("\nFinale:");
            EliminationPhaseMatch finalMatch = new EliminationPhaseMatch(finalist.Item1, finalist.Item2);
            finalMatch.PlayMatchElimination();
            Console.WriteLine($"\t{finalMatch.DisplayResults()}");
            if (finalMatch.Team1Score > finalMatch.Team2Score)
            {
                TeamWithMedals.Add(1, finalist.Item1);
                TeamWithMedals.Add(2, finalist.Item2);
            } else
            {
                TeamWithMedals.Add(1, finalist.Item2);
                TeamWithMedals.Add(2, finalist.Item1);
            }
        }

        public void MedalCeremony()
        {
            Console.WriteLine("\nMedalje:");
            //Order team by position
            foreach (var team in TeamWithMedals.OrderBy(team => team.Key))
            {
                Console.WriteLine($"{team.Key}. {team.Value.Team}");
            }
        }


        public void DisplayEliminationPhase()
        {
            Console.WriteLine("\nEliminacijona faza: ");
            foreach (var choice in firstQuarterFinal)
            {
                Console.WriteLine($"\t{choice.Item1.NationalTeam.Team} - {choice.Item2.NationalTeam.Team}");
            }
            Console.WriteLine();
            foreach (var choice in secondQuarterFinal)
            {
                Console.WriteLine($"\t{choice.Item1.NationalTeam.Team} - {choice.Item2.NationalTeam.Team}");
            }
            Console.WriteLine();
        }
    }
}
