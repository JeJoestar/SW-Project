using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class Legion : BaseEntity
    {
        public string Name { get; set; }

        public int GeneralJediId { get; set; }

        public Jedi GeneralJedi { get; set; }
        
        
        // public Clone? Commander { get; set; }

        //тут дві ентіті типу Clone і List<Clone>, EF важко визначити тип звязку
        //треба це описати руками в SWContext
        // https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
        // я додав деякі зміни в SWContext, глянь там

        public List<Clone> Clones { get; set; }

    }
}
