using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PokeApi;
using PokeApi.Interfaces;
using PokeQuiz.Models;

namespace PokeQuiz.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPokeApiService _pokeApiService;

        public HomeController(IPokeApiService pokeApiService)
        {
            this._pokeApiService = pokeApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = _pokeApiService.GetRandomPokemon().Name;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
