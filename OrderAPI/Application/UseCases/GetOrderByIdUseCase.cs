using OrderAPI.Application.Interfaces;
using OrderAPI.Domain;

namespace OrderAPI.Application.UseCases
{
    public class GetOrderByIdUseCase
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrderByIdUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order?> ExecuteAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }
    }
} 