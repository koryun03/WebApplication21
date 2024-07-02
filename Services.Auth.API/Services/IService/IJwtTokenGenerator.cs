using WebApp21.Services.AuthAPI.Models;

namespace WebApp21.Services.AuthAPI.Services.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);

    }
}
