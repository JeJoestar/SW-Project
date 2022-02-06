namespace SWProject
{
    public class BaseFleet : BaseEntity // ця сутність взагалі не мала ключа 
    {
        public List<Base>? AttachedBases { get; set; } // зв'язок один до одного мені не подобається, треба якось перепланувати
        public StarDestroyer? Venator { get; set; }
        public List<AssaultShip>? Acclamators { get; set; } // не додавай слово List до ліста  => Acclamators або AssaultShips  
    }
}