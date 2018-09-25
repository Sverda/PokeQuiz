namespace PokeApi.Interfaces
{
    public interface IPokeApiService
    {
        (string Name, byte[] Sprite) GetRandomPokemon();
    }
}