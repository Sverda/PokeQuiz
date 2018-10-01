using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Model;
using PokeApi.Interfaces;
using PokeQuiz.Services;

namespace PokeQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly IPokeApiService _pokeApiService;
        private readonly PokeContext _pokeContext;

        public SeedController(IPokeApiService pokeApiService, PokeContext pokeContext)
        {
            _pokeApiService = pokeApiService;
            _pokeContext = pokeContext;
        }

        public IEnumerable<Pokemon> SeedDatabase()
        {
            var data = createTestData(amount: 10);
            _pokeContext.Set<Pokemon>().AddRange(data);
            _pokeContext.SaveChanges();
            return data;
        }

        private IEnumerable<Pokemon> createTestData(int amount)
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
    }
}