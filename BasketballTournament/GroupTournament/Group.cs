using BasketballTournament.GroupPhase;
using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace BasketballTournament
{

	internal class Group
    {
        public string Name { get; set; }

        public List<NationalTeamInGroup> NationalTeamsInGroup { get; set; }

        public Group(string name)
        {
            Name = name;
            NationalTeamsInGroup = new List<NationalTeamInGroup>();
        }

        public string UpdateGroupPositions()
        {
            return "Update Group Positions";
        }

        public override string ToString()
        {
            string result = $"\tGrupa {Name} (Ime - pobede/porazi/bodovi/postignuti koševi/primljeni koševi/koš razlika):\n";
            foreach (var teamInGroup in NationalTeamsInGroup) 
            {
                result += $"{teamInGroup}"; 
            }
            return result;
        }
    }

}