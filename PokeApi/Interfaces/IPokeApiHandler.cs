namespace PokeApi.Interfaces
{
    public interface IPokeApiHandler
    {
        string GetPokemonName(int index);
        byte[] GetPokemonSprite(int index);
    }
}