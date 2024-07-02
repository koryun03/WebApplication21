using MassTransit;

namespace WebApp21.MessageBus
{
    public class MessageBus : IMessageBus
    {
        //private readonly IBusControl _busControl;

        //public MessageBus(IBusControl busControl)
        //{
        //    _busControl = busControl;
        //}

        private readonly IPublishEndpoint _publishEndpoint;
        public MessageBus(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishMessage<T>(T instance) where T : class
        {
            await _publishEndpoint.Publish(instance);
        }
    }

}