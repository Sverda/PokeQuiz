using System.Collections.Generic;

namespace PokeApi.Model
{
    public class PokemonJson
    {
        public string name { get; set; }
        public Dictionary<string, string> sprites = new Dictionary<string, string>();
    }
}
