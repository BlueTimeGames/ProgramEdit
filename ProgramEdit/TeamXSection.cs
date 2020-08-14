using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramEdit
{
    class TeamXSection
    {
        public int IdTeamXSection { get; set; }
        public string Name { get; set; }
        public int IdSection { get; set; }

        public TeamXSection(int idTeamXSection, int section, string name)
        {
            IdTeamXSection = idTeamXSection;
            Name = name;
            IdSection = section;
        }
    }
}
