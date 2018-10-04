using Microsoft.EntityFrameworkCore;
using Model;
using PokeApi.Interfaces;

namespace PokeQuiz.Services
{
    public class PokeContext : DbContext
    {
        private readonly IPokeApiService _pokeApiService;

        public PokeContext(DbContextOptions<PokeContext> options, IPokeApiService pokeApiService)
            : base(options)
        {
            _pokeApiService = pokeApiService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Pokemon>()
                .HasKey(p => p.Name);
        }

        public DbSet<Pokemon> Pokemon { get; set; }
    }
}
