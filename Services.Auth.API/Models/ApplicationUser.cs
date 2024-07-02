using Microsoft.AspNetCore.Identity;

namespace WebApp21.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
