namespace SWProject
{
    public class Jedi : BaseEntity
    {
        public string? Name { get; set; }
        public Jedi? Padawan { get; set; }
        public Jedi? Teacher { get; set; }
        public Legion? Legion { get; set; }
    }
}