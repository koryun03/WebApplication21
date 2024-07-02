using MassTransit;
using WebApp21.MessageBus.Common;
using WebApp21.Services.EmailAPI.Services;

namespace WebApp21.Services.EmailAPI.Consumers
{
    public class UserRegisterConsumer : IConsumer<RegisterUserMessaging>
    {
        private readonly IEmailService _emailService;
        public UserRegisterConsumer(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Consume(ConsumeContext<RegisterUserMessaging> context)
        {
            var objMessage = context.Message;
            await _emailService.RegisterUserEmailAndLog(objMessage.Email);
        }

    }
}
