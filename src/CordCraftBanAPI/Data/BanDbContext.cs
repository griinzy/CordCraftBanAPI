using Microsoft.EntityFrameworkCore;

namespace CordCraftBanAPI.Data
{
    public class BanDbContext : DbContext
    {
        public BanDbContext(DbContextOptions<BanDbContext> options) : base(options) { }
        public DbSet<Ban> Bans { get; set; }
    }
}
