using OrderAPI.Application.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace OrderAPI.Infrastructure.Services
{
    public class RabbitMQService : IMessageBroker, IDisposable
    {
        private bool isConnectionActive;
        private IConnection connection;
        private IChannel channel;
        private readonly ConnectionFactory _factory;

        public RabbitMQService(ConnectionFactory factory)
        {
            _factory = factory;
        }

        private async Task CreateConnectionAndDeclare()
        {
            if (!isConnectionActive)
            {
                connection = await _factory.CreateConnectionAsync();
                channel = await connection.CreateChannelAsync();
                await channel.ExchangeDeclareAsync(exchange: "order_logs", type: ExchangeType.Topic);
                isConnectionActive = true;
            }
        }

        public async Task Publish<T>(T message, string routingKey)
        {
            await CreateConnectionAndDeclare();
            routingKey = string.IsNullOrEmpty(routingKey) ? "annonymus" : routingKey;
            string msg = message is string str ? str : JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(msg);
            await channel.BasicPublishAsync(exchange: "order_logs", routingKey: routingKey, body: body);
            Console.WriteLine($" API at routing key: '{routingKey}' sent: '{msg}'");
        }

        public void Dispose()
        {
            connection?.Dispose();
            channel?.Dispose();
            isConnectionActive = false;
        }
    }
} 