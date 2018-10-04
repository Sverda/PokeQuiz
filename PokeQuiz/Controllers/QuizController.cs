using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Model;
using PokeQuiz.Services.Interfaces;

namespace PokeQuiz.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public QuizController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public QuizViewModel Get()
        {
            var correctAnswer = _pokemonService.ChooseRandom();
            var fakeAnswers = Enumerable.Range(1, 3).Select(_ => _pokemonService.ChooseRandom().Name).ToList();
            fakeAnswers.Add(correctAnswer.Name);
            return new QuizViewModel
            {
                CorrectAnswer = correctAnswer,
                FakeAnswers = fakeAnswers
            };
        }
    }
}