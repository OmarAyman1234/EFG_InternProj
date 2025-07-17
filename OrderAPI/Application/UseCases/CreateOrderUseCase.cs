using OrderAPI.Application.Interfaces;
using OrderAPI.Domain;
using OrderSharedContent;

namespace OrderAPI.Application.UseCases
{
    public class CreateOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;
        public CreateOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> ExecuteAsync(CreateOrderRequest request)
        {
            request.Direction = OrderUtils.NormalizeDirection(request.Direction);
            var order = new Order(request.Product, request.Price, request.Quantity, request.Direction);
            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();
            return order;
        }
    }
} 