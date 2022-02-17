using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class JediRepository : GenericRepository<Jedi>, IJediRepository
    {
        public JediRepository(SWContext context) : base(context)
        {
        }
    }
}
