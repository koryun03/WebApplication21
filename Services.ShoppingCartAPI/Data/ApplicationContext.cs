using Microsoft.EntityFrameworkCore;
using WebApp21.Services.ShoppingCartAPI.Models;

namespace WebApp21.Services.ShoppingCartAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

    }
}
