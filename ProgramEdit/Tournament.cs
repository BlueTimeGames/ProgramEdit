using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramEdit
{
    class Tournament
    {
        public int IdTournament { get; set; }
        public string Name { get; set; }
        public string Shortcut { get; set; }
        public int NumOfTeams { get; set; }
        public int System { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string PlayingDays { get; set; }
        public int PrizePool { get; set; }
        public int PPTeams { get; set; }
        public int PPDividing { get; set; }
        public City City { get; set; }
        public int TokenValue { get; set; }
        public Section Section { get; set; }
        public int BestOf { get; set; }
        public bool OpenReg { get; set; }

        public Tournament(int idTournament, string name, string shortcut, int numOfTeams, int system, string startDate, string endDate, string playingDays, int prizePool, int pPTeams, int pPDividing, City city, int tokenValue, Section section, int bestOf, bool openReg)
        {
            IdTournament = idTournament;
            Name = name;
            Shortcut = shortcut;
            NumOfTeams = numOfTeams;
            System = system;
            StartDate = startDate;
            EndDate = endDate;
            PlayingDays = playingDays;
            PrizePool = prizePool;
            PPTeams = pPTeams;
            PPDividing = pPDividing;
            City = city;
            TokenValue = tokenValue;
            Section = section;
            BestOf = bestOf;
            OpenReg = openReg;
        }
    }
}
