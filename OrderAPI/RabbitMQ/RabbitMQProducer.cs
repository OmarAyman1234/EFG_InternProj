using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace OrderAPI.RabbitMQ
{
    public class RabbitMQProducer : IDisposable
    {
        private static bool isConnectionActive;
        private static IConnection connection;
        private static IChannel channel;
        public static async Task CreateConnectionAndDeclare()
        {
            if (!isConnectionActive)
            {
                var factory = new ConnectionFactory();
                connection = await factory.CreateConnectionAsync();
                channel = await connection.CreateChannelAsync();

                await channel.ExchangeDeclareAsync(exchange: "order_logs", type: ExchangeType.Topic);

                isConnectionActive = true;
            }
        }
        //public static async void Send(string message, string routingKey)
        //{

        //    await CreateConnectionAndDeclare();

        //    routingKey = string.IsNullOrEmpty(routingKey) ? "annonymus" : routingKey;
        //    var body = Encoding.UTF8.GetBytes(message);
        //    await channel.BasicPublishAsync(exchange: "order_logs", routingKey: routingKey, body: body);

        //    Console.WriteLine(value: $" API at routing key: '{routingKey}' sent: '{message}'");
        //}
        //public static async void Send(OrderDto order, string routingKey)
        //{
        //    await CreateConnectionAndDeclare();

        //    routingKey = string.IsNullOrEmpty(routingKey) ? "annonymus" : routingKey;

        //    var json = JsonSerializer.Serialize(order);
        //    var body = Encoding.UTF8.GetBytes(json);

        //    await channel.BasicPublishAsync(exchange: "order_logs", routingKey: routingKey, body: body);

        //    Console.WriteLine(value: $" API at routing key: '{routingKey}' sent: '{order}'");
        //}
        public static async Task Send<T>(T data, string routingKey)
        {
            await CreateConnectionAndDeclare();

            routingKey = string.IsNullOrEmpty(routingKey) ? "annonymus" : routingKey;

            string message = data is string str ? str : JsonSerializer.Serialize(data);
            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(exchange: "order_logs", routingKey: routingKey, body: body);

            Console.WriteLine($" API at routing key: '{routingKey}' sent: '{message}'");
        }


        public void Dispose()
        {
            connection.Dispose();
            channel.Dispose();
            isConnectionActive = false;
        }
    }
}
