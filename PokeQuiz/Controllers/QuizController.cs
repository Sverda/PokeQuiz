using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Model;
using PokeQuiz.Services.Interfaces;

namespace PokeQuiz.Controllers
{
    public class QuizController : Controller
    {
        private readonly IPokemonService _pokemonService;

        public QuizController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public IActionResult Index()
        {
            var correctAnswer = _pokemonService.ChooseRandom();
            var fakeAnswers = Enumerable.Range(1, 3).Select(_ => _pokemonService.ChooseRandom().Name);
            return View(new QuizViewModel
            {
                CorrectAnswer = correctAnswer,
                FakeAnswers = fakeAnswers
            });
        }
    }
}