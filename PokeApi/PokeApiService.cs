using System;
using System.Net;
using PokeApi.Model;

namespace PokeApi
{
    public class PokeApiService
    {
        private static readonly int PokemonMax = 151;

        public (string Name, byte[] Sprite) GetRandomPokemon()
        {
            int random = new Random().Next(PokemonMax);
            var pokeApiHandler = new PokeApiHandler();
            var pokemonName = pokeApiHandler.GetPokemonName(random);
            var pokemonSprite = pokeApiHandler.GetPokemonSprite(random);
            return (pokemonName, pokemonSprite);
        }
    }
}
