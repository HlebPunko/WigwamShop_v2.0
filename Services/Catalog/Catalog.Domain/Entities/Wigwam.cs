namespace Catalog.Domain.Entities
{
    public class Wigwam : BaseEntity
    {
        public string WigwamTitle { get; set; }
        public string WigwamDescription { get; set; }
        public string Path { get; set; }
        public decimal Price { get; set; }
    }
}
