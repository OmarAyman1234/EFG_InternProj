using Microsoft.AspNetCore.SignalR;
using OrderSharedContent;

namespace Streamer.SignalR
{
    public class OrdersStreamHub : Hub<IOrderStream>
    {
        public async Task SendOrderToClients(OrderDto orderDto)
        {
            await Clients.All.ReceiveOrderUpdate(orderDto);
        }
    }
}
