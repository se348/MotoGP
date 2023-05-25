using Microsoft.AspNetCore.Mvc.Rendering;

namespace MotoGP.Models.ViewModel
{
    public class ListTicketsViewModel
    {
        public int raceID { get; set; }
        public SelectList? Races { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
