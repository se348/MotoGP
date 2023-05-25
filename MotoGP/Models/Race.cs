﻿using System.ComponentModel.DataAnnotations;

namespace MotoGP.Models
{
    public class Race
    {
        public int RaceID { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public string Country { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yy}")]
        public DateTime Date { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }
    }
}
