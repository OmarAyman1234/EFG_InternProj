using OrderAPI.Domain;
using OrderSharedContent;

namespace OrderAPI.Application.UseCases.OrderUseCase
{
    public class OrderService
    {
        private readonly GetAllOrdersUseCase _getAllOrders;
        private readonly GetOrderByIdUseCase _getOrderById;
        private readonly CreateOrderUseCase _createOrder;
        private readonly EditOrderUseCase _editOrder;
        private readonly DeleteOrderUseCase _deleteOrder;

        public OrderService(
            GetAllOrdersUseCase getAllOrders,
            GetOrderByIdUseCase getOrderById,
            CreateOrderUseCase createOrder,
            EditOrderUseCase editOrder,
            DeleteOrderUseCase deleteOrder)
        {
            _getAllOrders = getAllOrders;
            _getOrderById = getOrderById;
            _createOrder = createOrder;
            _editOrder = editOrder;
            _deleteOrder = deleteOrder;
        }

        public Task<IEnumerable<OrderDto>> GetAllAsync() => _getAllOrders.ExecuteAsync();
        public Task<Order?> GetByIdAsync(int id) => _getOrderById.ExecuteAsync(id);
        public Task<Order> CreateAsync(CreateOrderRequest request) => _createOrder.ExecuteAsync(request);
        public Task<Order?> EditAsync(int id, EditOrderRequest request) => _editOrder.ExecuteAsync(id, request);
        public Task<bool> DeleteAsync(int id) => _deleteOrder.ExecuteAsync(id);
    }
} 