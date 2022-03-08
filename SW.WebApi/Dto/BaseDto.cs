namespace SW.DAL
{
    public class BaseDto
    {
        public int? AttachedFleetId { get; set; }

        public Supply AmmoSupply { get; set; }

        public List<CloneDto> Clones { get; set; }

        public List<DroidDto> Droids { get; set; }
    }
}
