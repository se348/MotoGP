using Microsoft.EntityFrameworkCore;
using MotoGP.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoGP.Data
{
    public class GPContext : DbContext
    {
        public GPContext(DbContextOptions<GPContext> options): base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Race> Races {  get; set; }
        public DbSet<Rider> Riders { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().ToTable(nameof(Country));
            modelBuilder.Entity<Race>().ToTable(nameof(Race));
            modelBuilder.Entity<Rider>().ToTable(nameof(Rider));
            modelBuilder.Entity<Team>().ToTable(nameof(Team));
            modelBuilder.Entity<Ticket>().ToTable(nameof(Ticket));

            base.OnModelCreating(modelBuilder);
        }
    }
}
