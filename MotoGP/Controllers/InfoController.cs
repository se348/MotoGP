using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP.Data;
using MotoGP.Models;
using MotoGP.Models.ViewModel;

namespace MotoGP.Controllers
{
    public class InfoController : Controller
    {
        private readonly GPContext gpContext;
        public InfoController(GPContext gPContext) 
        {
            this.gpContext = gPContext;
        }
        public IActionResult ListRaces()
        {
            ViewData["BannerNr."] = 0;
            var races = gpContext.Races.OrderBy(x => x.Date).ToList();
            return View(races);
        }

        public IActionResult ListRiders()
        {
            ViewData["BannerNr."] = 1;
            var races = gpContext.Riders
                .Include(b => b.Country)
                .OrderBy(x => x.Number).ToList();
            return View(races);
        }

        public IActionResult BuildMap()
        {
            
            ViewData["BannerNr."] = 0;
            var races = gpContext.Races.ToList();
            return View(races);
        }

        public IActionResult SelectRace(int raceID = 0)
        {
            RaceDetailViewModel model = new RaceDetailViewModel();
            if (raceID != 0) 
            {
                model.SelectedRace = gpContext.Races.Where(a => a.RaceID == raceID).FirstOrDefault();
            }
            model.raceID = raceID;
            model.Races = new SelectList(gpContext.Races.ToList(), "RaceID", "Name");

            ViewData["BannerNr."] = 0;
            return View(model);
        }

        public IActionResult ShowRace(int id)
        {

            ViewData["BannerNr."] = 0;
            var race = gpContext.Races.Find(id);
            return View(race);
        }
    }
}
