using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class LegionRepository : GenericRepository<Legion>, ILegionRepository
    {
        public LegionRepository(SWContext context) : base(context)
        {
        }
    }
}
