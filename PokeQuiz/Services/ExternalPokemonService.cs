using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace PokeQuiz.Services
{
    internal class PokemonApiModel
    {
        public string name { get; set; }
        public Dictionary<string, string> sprites = new Dictionary<string, string>();
    }

    public class ExternalPokemonService
    {
        private int PokemonMax = 151;
        public Pokemon GetRandomPokemon()
        {
            var apiModel = CallPokeApi();
            var randomPokemon = ParseApiModel(apiModel.Result);
            return randomPokemon;
        }

        private Pokemon ParseApiModel(PokemonApiModel apiModel)
        {
            var spriteUrl = apiModel.sprites["front_default"];
            var client = new WebClient();
            var content = client.DownloadData(spriteUrl);
            var pokemon = new Pokemon
            {
                Name = apiModel.name,
                Image = content
            };
            return pokemon;
        }

        private async Task<PokemonApiModel> CallPokeApi()
        {
            var randomId = new Random().Next(PokemonMax);
            var url = @"https://pokeapi.co/api/v2/pokemon/" + randomId + "/";
            var client = new WebClient();
            var content = await client.DownloadStringTaskAsync(url);
            var parsedJson = JsonConvert.DeserializeObject<PokemonApiModel>(content);
            return parsedJson;
        }
    }
}
