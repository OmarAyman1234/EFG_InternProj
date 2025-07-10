using System.ComponentModel.DataAnnotations.Schema;
namespace OrderAPI.Models
{
    public class Order
    {
        public Order() { }
        public Order(string product, decimal price, int qty, string orderDir)
        {
            Product = product;
            Price = price;
            Quantity = qty;
            Direction = orderDir;
        }
        public int Id { get; private set; }
        public int ClientId { get; private set; } = 1;
        public string Product { get; set; } = null!;

        [Column(TypeName = "decimal(9, 2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Direction { get; set; } = null!;

    }
}
