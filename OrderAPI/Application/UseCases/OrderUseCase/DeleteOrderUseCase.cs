using OrderAPI.Application.Interfaces;

namespace OrderAPI.Application.UseCases.OrderUseCase
{
    public class DeleteOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;
        public DeleteOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> ExecuteAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) return false;
            await _orderRepository.DeleteAsync(id);
            await _orderRepository.SaveChangesAsync();
            return true;
        }
    }
} 