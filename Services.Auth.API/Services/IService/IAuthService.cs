using WebApp21.Services.AuthAPI.Models.Dto;

namespace WebApp21.Services.AuthAPI.Services.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
        Task<string> GetUserId(string email);
    }
}
