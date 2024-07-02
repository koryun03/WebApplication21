using Microsoft.EntityFrameworkCore;
using WebApp21.Services.EmailAPI.Models;

namespace WebApp21.Services.EmailAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<EmailLogger> EmailLoggers { get; set; }

    }
}
