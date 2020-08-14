using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramEdit
{
    class City
    {
        public int IdCity { get; set; }
        public string Name { get; set; }

        public City(int idCity, string name)
        {
            IdCity = idCity;
            Name = name;
        }
    }
}
