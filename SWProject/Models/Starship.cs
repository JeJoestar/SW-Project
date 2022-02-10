using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class Starship : BaseEntity
    {
        public List<Droid> Droids { get; set; }
        public List<Clone> Passangers { get; set; }
        public string PathList { get; set; }
        public StarshipWeaponry? Weaponry { get; set; }
        public BaseFleet Fleet { get; set; }
        public int FleetId { get; set; }
        public string Type { get; set; }
    }
}
