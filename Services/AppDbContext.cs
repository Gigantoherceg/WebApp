using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Services.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Notice> Notices { get; set; }
    }
}
