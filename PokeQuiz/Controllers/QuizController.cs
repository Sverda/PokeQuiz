using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Model;
using PokeQuiz.Services.Interfaces;

namespace PokeQuiz.Controllers
{
    [Route("api/quiz")]
    public class QuizController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        private QuizViewModel _questionData;

        public QuizController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [Route("question")]
        public QuizViewModel GetQuestion()
        {
            var correctAnswer = _pokemonService.ChooseRandom();
            var fakeAnswers = Enumerable.Range(1, 3).Select(_ => _pokemonService.ChooseRandom().Name).ToList();
            fakeAnswers.Add(correctAnswer.Name);
            _questionData = new QuizViewModel
            {
                CorrectAnswer = correctAnswer,
                FakeAnswers = fakeAnswers
            };
            return _questionData;
        }

        [Route("answer/{name}")]
        public bool GetAnswer(string name)
        {
            return name == _questionData?.CorrectAnswer.Name;
        }
    }
}