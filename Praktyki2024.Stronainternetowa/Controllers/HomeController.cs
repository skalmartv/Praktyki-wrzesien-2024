using Microsoft.AspNetCore.Mvc;
using Praktyki2024.Stronainternetowa.Models;
using System.Diagnostics;

namespace Praktyki2024.StronaInternetowa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Podstrona1")]
        public IActionResult Strona1()
        {
            var pod1 = new Strona1ViewModel(
                "pod1",
                "pod2",
                "pod3",
                "pod4",
                "pod5"
            );

            return View(pod1);
        }

        [Route("Podstrona2")]
        public IActionResult Strona2()
        {
            var pod2 = new Strona2ViewModel(
                "pod11",
                "pod21",
                "pod31",
                "pod41",
                "pod51"
            );

            return View(pod2);
        }
        [Route("Podstrona3")]
        public IActionResult Strona3()
        {
            var pod3 = new Strona3ViewModel(
                "pod111",
                "pod211",
                "pod311",
                "pod411",
                "pod511"
            );

            return View(pod3);
        }
        public IActionResult Kontakt()
        {
            return View(new KontaktViewModel());
        }
        public IActionResult Sklep()
        {
            return View(new SklepViewModel());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
