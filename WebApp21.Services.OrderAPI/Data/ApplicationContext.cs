using Microsoft.EntityFrameworkCore;
using WebApp21.Services.OrderAPI.Models;

namespace WebApp21.Services.OrderAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
