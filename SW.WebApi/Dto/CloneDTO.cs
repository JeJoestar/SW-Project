using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class CloneDTO
    {
        [Required]
        [StringLength(4)]
        public string Number { get; set; }
        [Required]
        public int LegionId { get; set; }
        public int BaseId { get; set; }
        public int StarshipId { get; set; }
        [Required]
        public string Equipment { get; set; }
        public string Qualification { get; set; }
    }
}
