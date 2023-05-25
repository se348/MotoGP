namespace MotoGP.Models
{
    public class Rider
    {
        public int RiderID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public int CountryID { get; set; }
        public Country? Country { get; set; }

        public int TeamID { get; set; }
        public Team? Team { get; set; }

        public string Bike { get; set; }
        public int Number { get; set; }

        public string Name { get { return this.FirstName + " " + this.LastName; } }
    }
}
