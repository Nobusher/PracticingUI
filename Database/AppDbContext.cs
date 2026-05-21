using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Aiport> Aiports => Set<Aiport>();
        public DbSet<Flight> Flights => Set<Flight>();
        public DbSet<Passenger> Passengers => Set<Passenger>();
        public DbSet<Ticket> Tickets => Set<Ticket>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasOne(f=>f.DepartureAiport)
                .WithMany(f=>f.DepartureFlight)
                .HasForeignKey(f=>f.DepartureAiportId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight>()
                .HasOne(f=>f.ArrivalAirport)
                .WithMany(a=>a.ArrivalFlights)
                .HasForeignKey(f=>f.ArrivalAirportId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
