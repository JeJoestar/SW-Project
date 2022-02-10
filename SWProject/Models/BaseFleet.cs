namespace SW.DAL
{
    public class BaseFleet : BaseEntity // ця сутність взагалі не мала ключа 
    {
        public List<Base>? AttachedBases { get; set; } 
        public List<Starship>? Starships { get; set; }
    }
}