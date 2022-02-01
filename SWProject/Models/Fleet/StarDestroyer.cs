using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWProject
{
    public class StarDestroyer : StarShip
    {
        public List<Clone>? Passangers { get; set; }
        public List<Droid>? Droids { get; set; }
    }
}
