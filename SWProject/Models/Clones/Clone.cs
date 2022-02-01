using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWProject
{
    public class Clone : BaseEntity
    {
        public string? Number { get; set; }
        public Legion? Legion { get; set; }
        public string? Equipment { get; set; }
        public string? Qualification { get; set; }
    }
}
