using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramEdit
{
    class Nation
    {
        public int IdNation { get; set; }
        public string Name { get; set; }

        public Nation(int idNation, string name)
        {
            IdNation = idNation;
            Name = name;
        }
    }
}
