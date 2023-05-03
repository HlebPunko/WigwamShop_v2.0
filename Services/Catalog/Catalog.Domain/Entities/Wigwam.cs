namespace Catalog.Domain.Entities
{
    public class Wigwam
    {
        public int WigwamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string Path { get; set; }
    }
}
