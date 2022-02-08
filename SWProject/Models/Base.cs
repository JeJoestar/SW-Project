using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWProject
{
    public class Base : BaseEntity
    {
        public BaseFleet? AttachedFleet { get; set; }
        public int? AttachedFleetId { get; set; }
        public List<Droid> Droids { get; set; }
        public List<Clone> Clones { get; set; }
        public Supply? AmmoSupply { get; set; }
        
    }
}
