using System.ComponentModel.DataAnnotations;

namespace OrderSharedContent
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }

        public string Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Direction { get; set; }

        public string ToString()
        {
            return Product + Price;
        }
    }

    public class CreateOrderRequest
    {
        public CreateOrderRequest(string product, decimal price, int quantity, string direction)
        {
            Product = product;
            Price = price;
            Quantity = quantity;
            Direction = direction;
        }

        [Required(ErrorMessage = "Product cannot be empty!")]
        public string Product { get; set; }

        [Range(1, 9999999.99, ErrorMessage = "Minimum for price is 1 and maximum is 9,999,999")]
        public decimal Price { get; set; }

        [Range(1, 1000, ErrorMessage = "Minimum for quantity is 1 and maximum is 1000")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Direction cannot be empty!")]
        [RegularExpression("^(Buy|B|buy|b|Sell|S|sell|s)$", ErrorMessage = "Direction can only be Buy or Sell!")]
        public string Direction { get; set; }
    }
    
    public class EditOrderRequest
    {
        public EditOrderRequest(string product, decimal price, int quantity, string direction)
        {
            Product = product;
            Price = price;
            Quantity = quantity;
            Direction = direction;
        }

        [Required(ErrorMessage = "Product cannot be empty!")]
        public string Product { get; set; }

        [Range(1, 9999999.99, ErrorMessage = "Minimum for price is 1 and maximum is 9,999,999")]
        public decimal Price { get; set; }

        [Range(1, 1000, ErrorMessage = "Minimum for quantity is 1 and maximum is 1000")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Direction cannot be empty!")]
        [RegularExpression("^(Buy|B|buy|b|Sell|S|sell|s)$", ErrorMessage = "Direction can only be Buy or Sell!")]
        public string Direction { get; set; }
    }
}
