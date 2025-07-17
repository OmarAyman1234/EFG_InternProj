namespace OrderAPI.Application.Interfaces
{
    public interface IMessageBroker
    {
        Task Publish<T>(T message, string routingKey);
    }
} 