using Microsoft.AspNetCore.Mvc.Rendering;

namespace MotoGP.Models.ViewModel
{
    public class RaceDetailViewModel
    {

        public int raceID { get; set; }
        public SelectList Races { get; set; }

        public Race? SelectedRace { get; set; }
    }
}
