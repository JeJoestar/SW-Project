namespace SW.DAL
{
    public class Jedi : BaseEntity
    {
        public string Name { get; set; }

        public int? PadawanId { get; set; }
        public Jedi? Padawan { get; set; } // складні зв'язки сутності до самої себе, теж треба описати окремо, дивися в SWContext

        public int? TeacherId { get; set; }
        public Jedi? Teacher { get; set; }

        public int? LegionId { get; set; } // знову один до одного з легіоном
        public Legion? Legion { get; set; } // знову один до одного з легіоном
    }
}