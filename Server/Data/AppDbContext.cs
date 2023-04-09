using Microsoft.EntityFrameworkCore;
using WordsCombiner.Shared.Model;

namespace WordsCombiner.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<JapaneseWord> JapaneseWords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JapaneseWord>()
                .HasKey(x => x.Value);
        }

    }
}
