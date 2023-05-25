using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP.Data;
using MotoGP.Models;
using MotoGP.Models.ViewModel;

namespace MotoGP.Controllers
{
    public class ShopController : Controller
    {
        private readonly GPContext gPContext;
        public ShopController(GPContext gPContext)
        {
            this.gPContext = gPContext;
        }

        public IActionResult OrderTicket()
        {
            ViewData["BannerNr."] = 3;
            var selectList = new SelectList(gPContext.Countries.ToList(), "CountryID", "Name");
            ViewData["SelectList"] = selectList;
            ViewData["RacesList"] = gPContext.Races.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OrderTicket([Bind("Name,Address,Email,Number,CountryID,RaceID")]Ticket ticket)
        {

            ticket.OrderDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                gPContext.Tickets.Add(ticket);
                gPContext.SaveChanges();

                return RedirectToAction("ConfirmOrder", new {id = ticket.TicketID});
            }
            else
            {
                var selectList = new SelectList(gPContext.Countries.ToList(), "CountryID", "Name");
                ViewData["SelectList"] = selectList;
                return View(ticket);
            }
        }

        public IActionResult ConfirmOrder(int id)
        {
            ViewData["BannerNr."] = 3;
            var ticket = gPContext.Tickets
                .Where(a => a.TicketID == id)
                .Include(a => a.Country)
                .Include(a => a.Race)
                .FirstOrDefault();
            return View(ticket);
        }
    
        public IActionResult ListTickets(int raceID= 0)
        {
            ListTicketsViewModel model = new ListTicketsViewModel();
            if (raceID > 0)
            {
                model.Tickets = gPContext.Tickets
                    .Include(a => a.Country)
                    .Include(a => a.Race)
                    .Where(a => a.RaceID == raceID).ToList();
            }
            else
            {
                model.Tickets = gPContext.Tickets
                    .Include(a => a.Country)
                    .Include(a => a.Race)
                    .ToList();
            }
            model.raceID = raceID;
            model.Races = new SelectList(gPContext.Races.ToList(), "RaceID", "Name");
            ViewData["BannerNr."] = 3;
            return View(model);
        }
    }
}
