using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PokeApi;
using PokeQuiz.Models;

namespace PokeQuiz.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var externalService = new PokeApiService();

            ViewData["Message"] = externalService.GetRandomPokemon().Name;

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
