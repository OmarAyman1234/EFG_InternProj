using OrderAPI.Utils;
using OrderAPI.Models;
using OrderAPI.Data.Context;

using OrderSharedContent;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace OrderAPI.Data.Repositories
{
    public class OrderServices
    {
        private readonly IDistributedCache _cache;
        private readonly OrderContext _context;

        public OrderServices(IDistributedCache cache, OrderContext context)
        {
            _cache = cache;
            _context = context;
        }

        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            string cacheKey = "AllOrders";
            var cachedOrders = await _cache.GetStringAsync(cacheKey);
            if (cachedOrders != null)
            {
                Console.WriteLine("Orders from cache.");
                return JsonSerializer.Deserialize<IEnumerable<OrderDto>>(cachedOrders);
            }

            var orders = _context.Orders.Select(o => new OrderDto
            {
                Id = o.Id,
                ClientId = o.ClientId,
                Product = o.Product,
                Price = o.Price,
                Quantity = o.Quantity,
                Direction = o.Direction
            });

            await _cache.SetStringAsync(
                cacheKey,
                JsonSerializer.Serialize(orders),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
                    SlidingExpiration = TimeSpan.FromMinutes(10)
                }
            );

            Console.WriteLine("Orders from DB.");
            return orders;
        }
        public OrderDto? GetOrderById(int id)
        {
            var foundOrder = _context.Orders.FirstOrDefault(o => o.Id == id);

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
        public OrderDto CreateOrder(CreateOrderRequest order)
        {
            order.Direction = OrderUtils.NormalizeDirection(order.Direction);

            var newOrder = new Order(order.Product, order.Price, order.Quantity, order.Direction);
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return new OrderDto { Id = newOrder.Id, ClientId = newOrder.ClientId, Product = newOrder.Product, Price = newOrder.Price, Quantity = newOrder.Quantity, Direction = newOrder.Direction };
        }
        public OrderDto? EditOrder(int id, EditOrderRequest order)
        {
            var orderToEdit = _context.Orders.FirstOrDefault(o => o.Id == id);
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

                _context.SaveChanges();
                return editedOrderDto;
            }
            else return null;
        }
        public bool DeleteOrder(int id)
        {
            var orderToRemove = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (orderToRemove != null)
            {
                _context.Orders.Remove(orderToRemove);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
