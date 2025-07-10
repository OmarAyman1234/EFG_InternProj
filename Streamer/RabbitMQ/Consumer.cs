using Microsoft.AspNetCore.SignalR;
using OrderSharedContent;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Streamer.SignalR;
using System.Text;
using System.Text.Json;

namespace Streamer.RabbitMQ
{
    public class Consumer : BackgroundService
    {
        private static IConnection _connection;
        private static IChannel _channel;
        private readonly IHubContext<OrdersStreamHub, IOrderStream> _orderStreamHub;

        public Consumer(IHubContext<OrdersStreamHub, IOrderStream> ordersStreamHub)
        {
            _orderStreamHub = ordersStreamHub;
        }
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = await factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();

            await _channel.ExchangeDeclareAsync(exchange: "order_logs", type: ExchangeType.Topic);
            string queueName = "order_logs";
            await _channel.QueueDeclareAsync(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false
            );
            await _channel.QueueBindAsync(queue: queueName, exchange: "order_logs", routingKey: "#");

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);

                var order = JsonSerializer.Deserialize<OrderDto>(message);
                if(order != null)
                    await _orderStreamHub.Clients.All.ReceiveOrderUpdate(order);
            };

            await _channel.BasicConsumeAsync(
                queue: queueName,
                autoAck: true,
                consumer: consumer
            );
        } 
    }
}
