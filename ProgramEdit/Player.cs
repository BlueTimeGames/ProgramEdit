using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramEdit
{
    class Player
    {
        public int IdPlayer { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nick { get; set; }
        public int Nation { get; set; }
        public int TeamXSection { get; set; }
        public int Value { get; set; }
        public int Salary { get; set; }
        public string ContractEnd { get; set; }
        public int PlayerCoop { get; set; }
        public int IndividualSkill { get; set; }
        public int TeamplaySkill { get; set; }
        public int IndividualPotencial { get; set; }
        public int TeamplayPotencial { get; set; }
        public int Section { get; set; }
        public int Position { get; set; }
        public int IdTeam { get; set; }

        public Player(int idPlayer, string name, string surname, string nick, int nation, int teamXSection, int value, int salary, string contractEnd, int individualSkill, int teamplaySkill, int individualPotencial, int teamplayPotencial, int section, int position, int team)
        {
            IdPlayer = idPlayer;
            Name = name;
            Surname = surname;
            Nick = nick;
            Nation = nation;
            TeamXSection = teamXSection;
            Value = value;
            Salary = salary;
            ContractEnd = contractEnd;
            IndividualSkill = individualSkill;
            TeamplaySkill = teamplaySkill;
            IndividualPotencial = individualPotencial;
            TeamplayPotencial = teamplayPotencial;
            Section = section;
            Position = position;
            IdTeam = team;
        }
    }
}
