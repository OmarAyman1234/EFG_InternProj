using OrderSharedContent;

namespace Streamer.SignalR
{
    public interface IOrderStream
    {
        Task ReceiveOrderUpdate(OrderDto orderDto);
    }
}
