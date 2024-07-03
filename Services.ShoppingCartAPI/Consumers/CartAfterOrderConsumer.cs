using AutoMapper;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using WebApp21.MessageBus.Common;
using WebApp21.Services.ShoppingCartAPI.Data;

namespace WebApp21.Services.ShoppingCartAPI.Consumers
{
    public class CartAfterOrderConsumer : IConsumer<CartAfterOrderMessaging>
    {
        //     private readonly IEmailService _emailService;
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public CartAfterOrderConsumer(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<CartAfterOrderMessaging> context)
        {
            //var objMessage = context.Message;
            //CartDto Dto = _mapper.Map<CartDto>(objMessage);
            //await _emailService.EmailCartAndLog(Dto);

            var objMessage = context.Message;
            var cartDetails = await _context.CartDetails.Where(e => e.CartHeaderId == objMessage.CartHeaderId).ToListAsync();
            _context.CartDetails.RemoveRange(cartDetails);
            await _context.SaveChangesAsync();


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
