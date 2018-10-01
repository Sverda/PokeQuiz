using System;
using System.Linq;
using Model;
using PokeQuiz.Services.Interfaces;

namespace PokeQuiz.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly PokeContext _pokeContext;
        private readonly Random _random = new Random();

        public PokemonService(PokeContext pokeContext)
        {
            _pokeContext = pokeContext;
        }

        public Pokemon ChooseRandom()
        {
            var valueConstraint = _pokeContext.Pokemon.Last().Id;
            var number = _random.Next(valueConstraint);
            try
            {
                return _pokeContext.Pokemon.First(p => p.Id == number);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception);
                throw new Exception("Database is empty. Please seed it. ", exception);
            }
        }
    }
}
