using WebApp21.Services.EmailAPI.Message;
using WebApp21.Services.EmailAPI.Models.Dto;

namespace WebApp21.Services.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDto cartDto);
        Task RegisterUserEmailAndLog(string email);
        Task LogOrderPlaced(RewardsMessage rewardsDto);
    }
}
