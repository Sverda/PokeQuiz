using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokeApi.Interfaces;
using PokeApi.Model;

namespace PokeApi
{
    public class PokeApiHandler : IPokeApiHandler
    {
        private readonly WebClient _client;
        private static readonly string PokeApiHost = @"https://pokeapi.co/api/v2/";
        private static readonly string PokemonUrlSuffix = "pokemon/";

        public PokeApiHandler()
        {
            _client = new WebClient
            {
                BaseAddress = PokeApiHost
            };
        }

        public string GetPokemonName(int index)
        {
            var pokemon = getPokemonAsync(index).Result;
            return pokemon.name;
        }

        public byte[] GetPokemonSprite(int index)
        {
            var pokemon = getPokemonAsync(index).Result;
            var spriteUrl = pokemon.sprites["front_default"];
            var sprite = _client.DownloadData(spriteUrl);
            return sprite;
        }

        private async Task<PokemonJson> getPokemonAsync(int index)
        {
            var urlSuffix = PokemonUrlSuffix + index + "/";
            var content = await _client.DownloadStringTaskAsync(urlSuffix);
            var parsedJson = JsonConvert.DeserializeObject<PokemonJson>(content);
            return parsedJson;
        }
    }
}
