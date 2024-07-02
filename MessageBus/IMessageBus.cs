namespace WebApp21.MessageBus
{
    public interface IMessageBus
    {
        Task PublishMessage<T>(T gen) where T : class;
    }
}
