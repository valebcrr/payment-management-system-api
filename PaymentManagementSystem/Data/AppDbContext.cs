using Microsoft.EntityFrameworkCore;
using PaymentManagementSystem.Models;

namespace PaymentManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Payment> Payments { get; set; }
    }
}
