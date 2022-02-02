using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWProject
{
    public class Base : BaseEntity
    {
        public BaseFleet? AttachedFleet { get; set; } //в однієї бази один флотб флот прив'язаний до однієї бази, так має бути?
        public List<Droid>? DroidList { get; set; }
        public List<Clone>? CloneList { get; set; }
        public Supply? AmmoSupply { get; set; }
        
    }
}
