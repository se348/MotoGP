using Microsoft.AspNetCore.Mvc;
using MotoGP.Models;

namespace MotoGP.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult ListRaces()
        {
            ViewData["BannerNr."] = 0;
            return View();
        }

        public IActionResult BuildMap()
        {
            Race r = new Race() { RaceID = 1, X = 517, Y = 19, Name = "Assen" };
            Race r2 = new Race() { RaceID = 2, X = 859, Y = 249, Name = "Losail Circuit" };
            Race r3 = new Race() { RaceID = 3, X = 194, Y = 428, Name = "Autódromo Termas de Río Hondo" };
            ViewData["BannerNr."] = 0;
            ViewData["Races"] = new List<Race> {r, r2, r3 };
            return View();
        }
    }
}
