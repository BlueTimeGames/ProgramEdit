using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramEdit
{
    class Team
    {
        public int IdTeam { get; set; }
        public string Name { get; set; }
        public string Shortcut { get; set; }
        public int IdCity { get; set; }
        public int Budget { get; set; }
        public int Reputation { get; set; }

        public Team(int id, string name)
        {
            IdTeam = id;
            Name = name;
        }

        public Team(int id, string name, string shortcut, int city, int budget, int reputation)
        {
            IdTeam = id;
            Name = name;
            Shortcut = shortcut;
            IdCity = city;
            Budget = budget;
            Reputation = reputation;
        }
    }
}
