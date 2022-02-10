using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class Supply : BaseEntity
    {
        public int CartridgesCnt { get; set; }
        public int GrenadesCnt { get; set; }
        public int FuelCnt { get; set; }

    }
}
