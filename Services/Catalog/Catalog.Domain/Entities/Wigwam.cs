namespace Catalog.Domain.Entities
{
    public class Wigwam : BaseEntity
    {
        public string WigwamTitle { get; set; } = null!;
        public string WigwamDescription { get; set; } = null!;
        public float Price { get; set; }
    }
}
