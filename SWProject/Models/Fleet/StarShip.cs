using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWProject
{
    public abstract class StarShip : BaseEntity
    {
        public string? Name { get; }
        public List<Droid>? DroidList { get; set; }
        public List<Clone>? CloneList { get; set; }
        public object? PathList { get; }
        public StarshipWeaponry? Weaponry { get; set; }
    }
}
