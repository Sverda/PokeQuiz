using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using PokeQuiz.Services.Interfaces;

namespace PokeQuiz.Controllers
{
    [Route("api/quiz")]
    public class QuizController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        private readonly string _correctAnswerKey = "answer";
        private ISession session;

        public QuizController(IPokemonService pokemonService, IHttpContextAccessor httpContextAccessor)
        {
            _pokemonService = pokemonService;
            session = httpContextAccessor.HttpContext.Session;
        }

        [Route("question")]
        public QuizDto GetQuestion()
        {
            var correctAnswer = _pokemonService.ChooseRandom();
            var fakeAnswers = Enumerable.Range(1, 3).Select(_ => _pokemonService.ChooseRandom().Name).ToList();
            fakeAnswers.Add(correctAnswer.Name);

            session.SetString(_correctAnswerKey, correctAnswer.Name);

            return new QuizDto
            {
                CorrectAnswer = correctAnswer,
                FakeAnswers = fakeAnswers
            };
        }

        [Route("answer/{name}")]
        public bool GetAnswer(string name)
        {
            var correctName = session.GetString(_correctAnswerKey);
            return name == correctName;
        }
    }
}