namespace Order.Application.Models
{
    public class UpdateOrderModel
    {
        public string WigwamName { get; set; } = null!;
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int WigwamId { get; set; }
        public int UserId { get; set; }
    }
}
