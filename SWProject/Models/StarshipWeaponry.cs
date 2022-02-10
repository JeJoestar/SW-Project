using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class StarshipWeaponry : BaseEntity
    {
        public int LaserTurretCnt { get; set; }
        public int LaserDoubleCannonCnt { get; set; }
        public int LaserTargetDefenseCannonCnt { get; set; }
        public int ProtonTorpedoLauncherCnt { get; set; }
    }
}
