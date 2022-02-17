using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class DroidRepository : GenericRepository<Droid>, IDroidRepository
    {
        public DroidRepository(SWContext context) : base(context)
        {
        }
    }
}
