using Microsoft.EntityFrameworkCore;
using WordsCombiner.Shared.Model;

namespace WordsCombiner.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Word> Words { get; set; }

    }
}
