using OrderAPI.Application.Interfaces;
using OrderAPI.Domain;
using OrderSharedContent;

namespace OrderAPI.Application.UseCases.OrderUseCase
{
    public class EditOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;
        public EditOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order?> ExecuteAsync(int id, EditOrderRequest request)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) return null;
            order.Product = request.Product;
            order.Price = request.Price;
            order.Quantity = request.Quantity;
            order.Direction = OrderUtils.NormalizeDirection(request.Direction);
            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveChangesAsync();
            return order;
        }
    }
} 