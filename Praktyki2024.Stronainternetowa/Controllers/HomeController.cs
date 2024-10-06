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
                "Mercedes",
                "Z³oty",
                12000,
                false,
                43400
            );

            return View(pod1);
        }

        [Route("Podstrona2")]
        public IActionResult Strona2()
        {
            var pod2 = new Strona2ViewModel(
                16,
                15,
                14,
                13,
                12
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
			[HttpPost]
			public IActionResult KontaktSubmit()
			{
				// Po prostu zwracamy widok KontaktSubmit
				return View("KontaktSubmit");
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
