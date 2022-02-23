using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class DroidDTO
    {
        [Required]
        public string Model { get; set; }
        public int BaseId { get; set; }
        public int StarshipId { get; set; }
        public string Equipment { get; set; }
    }
}
