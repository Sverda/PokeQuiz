using Microsoft.EntityFrameworkCore;
using Model;

namespace PokeQuiz.Services
{
    public class PokeContext : DbContext
    {
        public PokeContext(DbContextOptions<PokeContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                .HasKey(b => b.Name);

        }

        public DbSet<Pokemon> Pokemon { get; set; }
    }
}
