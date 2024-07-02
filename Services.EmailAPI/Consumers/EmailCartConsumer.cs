using AutoMapper;
using MassTransit;
using WebApp21.MessageBus.Common;
using WebApp21.Services.EmailAPI.Models.Dto;
using WebApp21.Services.EmailAPI.Services;

namespace WebApp21.Services.EmailAPI.Consumers
{
    public class EmailCartConsumer : IConsumer<ShoppingCartMessaging>
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        public EmailCartConsumer(IEmailService emailService, IMapper mapper)
        {
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<ShoppingCartMessaging> context)
        {
            var objMessage = context.Message;
            CartDto Dto = _mapper.Map<CartDto>(objMessage);
            await _emailService.EmailCartAndLog(Dto);

            //try
            //{
            //    await _emailService.EmailCartAndLog(objMessage);
            //}
            //catch (Exception ex)
            //{
            //    // Handle the exception
            //}
        }

    }
}

