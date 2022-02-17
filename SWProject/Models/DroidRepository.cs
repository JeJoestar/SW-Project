using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class CloneRepository : GenericRepository<Clone>, ICloneRepository
    {
        public CloneRepository(SWContext context) : base(context)
        {
        }
    }
}
