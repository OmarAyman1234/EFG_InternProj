using OrderAPI.Application.Interfaces;
using OrderSharedContent;
using System.Text.Json;

namespace OrderAPI.Application.UseCases.OrderUseCase
{
    public class GetAllOrdersUseCase
    {
        private readonly IOrderRepository _orderRepository;
        public GetAllOrdersUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderDto>> ExecuteAsync()
        {

            var orders = (await _orderRepository.GetAllAsync()).Select(o => new OrderDto
            {
                Id = o.Id,
                ClientId = o.ClientId,
                Product = o.Product,
                Price = o.Price,
                Quantity = o.Quantity,
                Direction = o.Direction
            }).ToList();

            return orders;
        }
    }
} 