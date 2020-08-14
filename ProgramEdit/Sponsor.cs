using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramEdit
{
    class Sponsor
    {
        public int IdSponsor { get; set; }
        public string Name { get; set; }
        public int MonthlyPayment { get; set; }
        public int RenewBonus { get; set; }
        public int MinTeamStrength { get; set; }
        public int SuccessPayment { get; set; }

        public Sponsor(int id, string name, int payment, int bonus, int strength, int success)
        {
            IdSponsor = id;
            Name = name;
            MonthlyPayment = payment;
            RenewBonus = bonus;
            MinTeamStrength = strength;
            SuccessPayment = success;
        }
    }
}
