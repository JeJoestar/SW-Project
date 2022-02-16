using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class DroidRepository : GenericRepository<Clone>, IDroidRepository
    {
        public DroidRepository(SWContext context) : base(context)
        {
        }
    }
}
