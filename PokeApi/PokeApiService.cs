using System;
using PokeApi.Interfaces;

namespace PokeApi
{
    public class PokeApiService : IPokeApiService
    {
        private static readonly int PokemonMax = 151;
        private readonly IPokeApiHandler _pokeApiHandler;

        public PokeApiService(IPokeApiHandler pokeApiHandler)
        {
            this._pokeApiHandler = pokeApiHandler;
        }

        public (string Name, byte[] Sprite) GetRandomPokemon()
        {
            var random = new Random().Next(PokemonMax);

            var pokemonName = _pokeApiHandler.GetPokemonName(random);
            var pokemonSprite = _pokeApiHandler.GetPokemonSprite(random);

            return (pokemonName, pokemonSprite);
        }
    }
}
