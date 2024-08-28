using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament.GroupPhase
{
    internal class GroupPhase
    {
        public List<Group> Groups {  get; set; }

        public GroupPhase(List<Group> groups) 
        { 
            Groups = groups;
        }

        public GroupPhase()
        {
            Groups = new List<Group>();
        }

        public override string ToString()
        {
            string result = "";
            result = "Konačan plasman u grupama:\n";
            foreach (var group in Groups) 
            {
                result += $"{group}";
            }
            return result;
        }
    }
}
