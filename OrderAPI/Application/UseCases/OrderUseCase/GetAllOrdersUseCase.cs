using OrderAPI.Application.Interfaces;
using OrderSharedContent;
using System.Text.Json;

namespace OrderAPI.Application.UseCases.OrderUseCase
{
    public class GetAllOrdersUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICachingService _cache;
        public GetAllOrdersUseCase(IOrderRepository orderRepository, ICachingService cache)
        {
            _orderRepository = orderRepository;
            _cache = cache;
        }

        public async Task<IEnumerable<OrderDto>> ExecuteAsync()
        {
            string cacheKey = "AllOrders";
            var cachedOrders = await _cache.GetStringAsync(cacheKey);
            if (cachedOrders != null)
            {
                return JsonSerializer.Deserialize<IEnumerable<OrderDto>>(cachedOrders)!;
            }

            var orders = (await _orderRepository.GetAllAsync()).Select(o => new OrderDto
            {
                Id = o.Id,
                ClientId = o.ClientId,
                Product = o.Product,
                Price = o.Price,
                Quantity = o.Quantity,
                Direction = o.Direction
            }).ToList();

            await _cache.SetStringAsync(
                cacheKey,
                JsonSerializer.Serialize(orders),
                TimeSpan.FromHours(1)
            );

            return orders;
        }
    }
} 