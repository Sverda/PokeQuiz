using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                .HasKey(b => b.Name);

            seedDatabase(modelBuilder);
        }

        private void seedDatabase(ModelBuilder modelBuilder)
        {
            var templatePokemon = getTemplateData(amount: 10);
            //Debugger.Launch();
            foreach (var pokemon in templatePokemon)
            {
                modelBuilder.Entity<Pokemon>().HasData(pokemon);
            }
        }

        private IEnumerable<Pokemon> getTemplateData(int amount)
        {
            var downloaded = new List<Pokemon>();
            for (int i = 0; i < amount; i++)
            {
                var randomPokemon = _pokeApiService.GetRandomPokemon();

                var pokemon = new Pokemon()
                {
                    Name = randomPokemon.Name,
                    Image = randomPokemon.Sprite
                };
                downloaded.Add(pokemon);
            }

            return downloaded;
        }

        public DbSet<Pokemon> Pokemon { get; set; }
    }
}
