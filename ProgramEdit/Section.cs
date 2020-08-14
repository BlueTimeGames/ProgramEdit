using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramEdit
{
    class Section
    {
        public int IdSection { get; set; }
        public string Name { get; set; }
        public string Shortcut { get; set; }
        public bool PositionRequired { get; set; }
        public int NumOfPlayers { get; set; }
        public List<PositionType> Positions  { get; set; }

        public Section(int id, string name)
        {
            IdSection = id;
            Name = name;
        }

        public Section(int id, string name, string shortcut, bool required, int nOfPl)
        {
            IdSection = id;
            Name = name;
            Shortcut = shortcut;
            PositionRequired = required;
            NumOfPlayers = nOfPl;
            Positions = new List<PositionType>();
        }
    }
}
