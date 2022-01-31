using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWProject
{
    public class Legion
    {
        public string? Name { get; set; }
        public Jedi? GeneralJedi { get; set; }
        public Clone? Commander { get; set; }
        public List<Clone>? Clones { get; set; }

    }
}
