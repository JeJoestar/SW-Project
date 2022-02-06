using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWProject
{
    public class StarDestroyer : BaseEntity
    {
        public List<Droid> Droids { get; set; }
        public List<Clone> Passangers { get; set; }
        public string PathList { get; set; }
        public StarshipWeaponry? Weaponry { get; set; }
        public int FleetId { get; set; }
        public BaseFleet Fleet { get; set; }
    }
}
