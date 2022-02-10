using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class Clone : BaseEntity
    {
        public string? Number { get; set; }
        public Legion? Legion { get; set; }
        public int? LegionId { get; set; }
        public Base? Base { get; set; }
        public int? BaseId { get; set; }
        public Starship? Starship { get; set; }
        public int? StarshipId { get; set; }
        public string? Equipment { get; set; }
        public string? Qualification { get; set; }
    }
}
