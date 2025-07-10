using OrderAPI.Utils;
using OrderAPI.Models;
using OrderAPI.Data.Context;

using OrderSharedContent;

namespace OrderAPI.Data.Repositories
{
    public class OrderServices
    {
        static OrderContext context = new OrderContext();
        public static IEnumerable<OrderDto> GetOrders()
        {
            return context.Orders.Select(o => new OrderDto
            {
                Id = o.Id,
                ClientId = o.ClientId,
                Product = o.Product,
                Price = o.Price,
                Quantity = o.Quantity,
                Direction = o.Direction
            });
        }
        public static OrderDto? GetOrderById(int id)
        {
            var foundOrder = context.Orders.FirstOrDefault(o => o.Id == id);

            return foundOrder != null
                ? new OrderDto
                {
                    Id = foundOrder.Id,
                    ClientId = foundOrder.ClientId,
                    Product = foundOrder.Product,
                    Price = foundOrder.Price,
                    Quantity = foundOrder.Quantity,
                    Direction = foundOrder.Direction
                }
                : null;
        }
        public static OrderDto CreateOrder(CreateOrderRequest order)
        {
            order.Direction = OrderUtils.NormalizeDirection(order.Direction);

            var newOrder = new Order(order.Product, order.Price, order.Quantity, order.Direction);
            context.Orders.Add(newOrder);
            context.SaveChanges();
            return new OrderDto { Id = newOrder.Id, ClientId = newOrder.ClientId, Product = newOrder.Product, Price = newOrder.Price, Quantity = newOrder.Quantity, Direction = newOrder.Direction };
        }
        public static OrderDto? EditOrder(int id, EditOrderRequest order)
        {
            var orderToEdit = context.Orders.FirstOrDefault(o => o.Id == id);
            if (orderToEdit != null)
            {
                orderToEdit.Product = order.Product;
                orderToEdit.Price = order.Price;
                orderToEdit.Quantity = order.Quantity;

                //Normalize order direction
                order.Direction = OrderUtils.NormalizeDirection(order.Direction);
                orderToEdit.Direction = order.Direction;

                var editedOrderDto = new OrderDto
                {
                    Id = orderToEdit.Id,
                    ClientId = orderToEdit.ClientId,
                    Product = orderToEdit.Product,
                    Price = orderToEdit.Price,
                    Quantity = orderToEdit.Quantity,
                    Direction = orderToEdit.Direction
                };

                context.SaveChanges();
                return editedOrderDto;
            }
            else return null;
        }
        public static bool DeleteOrder(int id)
        {
            var orderToRemove = context.Orders.FirstOrDefault(o => o.Id == id);
            if (orderToRemove != null)
            {
                context.Orders.Remove(orderToRemove);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
