using System.Net;
using Newtonsoft.Json;
using PokeApi.Model;

namespace PokeApi
{
    internal class PokeApiHandler
    {
        private readonly WebClient _client;
        private static readonly string PokeApiHost = @"https://pokeapi.co/api/v2/";
        private static readonly string PokemonSuffix = "pokemon/";

        public PokeApiHandler()
        {
            _client = new WebClient
            {
                BaseAddress = PokeApiHost
            };
        }

        public string GetPokemonName(int index)
        {
            var pokemon = getPokemon(index);
            return pokemon.name;
        }

        public byte[] GetPokemonSprite(int index)
        {
            var pokemon = getPokemon(index);
            var spriteUrl = pokemon.sprites["front_default"];
            var sprite = _client.DownloadData(spriteUrl);
            return sprite;
        }

        private PokemonJson getPokemon(int index)
        {
            var urlSuffix = PokemonSuffix + index + "/";
            var content = _client.DownloadString(urlSuffix);
            var parsedJson = JsonConvert.DeserializeObject<PokemonJson>(content);
            return parsedJson;
        }
    }
}
