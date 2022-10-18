using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AirPortContext : DbContext
    {
        public AirPortContext(DbContextOptions<AirPortContext> options) : base(options)
        {

        }
        public DbSet<Flight>? Flights { get; set; }
        public DbSet<Leg>? Legs { get; set; }
        public DbSet<Log>? Logs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Number, Capacity, Landing/Departure/Both , CrossingTime (seconds)
            modelBuilder.Entity<Leg>().HasData(
            new Leg
            {
                LegId = 1,
                Number = 1,
                Capacity=0,
                FlightInStation = null,
                IsLanding = true,
                IsDeparture = false,
                StationWatingTime = 3,

            },
            new Leg
            {
                LegId = 2,
                Number = 2,
                Capacity = 0,
                FlightInStation = null,
                IsLanding = true,
                IsDeparture = false,
                StationWatingTime = 3,

            },
            new Leg
            { LegId = 3,Number = 3, Capacity = 0, FlightInStation = null,IsLanding = true, IsDeparture = false,StationWatingTime = 3,},
            new Leg
            {
                LegId = 4,
                Number = 4,
                Capacity = 0,
                FlightInStation = null,
                IsLanding = true,
                IsDeparture = true,
                StationWatingTime = 5,

            },
            new Leg
            {
                LegId = 5,
                Number = 5,
                Capacity = 0,
                FlightInStation = null,
                IsLanding = true,
                IsDeparture = false,
                StationWatingTime = 5,

            },
            new Leg
            {
                LegId = 6,
                Number = 6,
                Capacity = 0,
                FlightInStation = null,
                IsLanding = true,
                IsDeparture = true,
                StationWatingTime = 10,

            },
            new Leg
            {
                LegId = 7,
                Number = 7,
                Capacity = 0,
                FlightInStation = null,
                IsLanding = true,
                IsDeparture = true,
                StationWatingTime = 10,

            },
            new Leg
            {
                LegId = 8,
                Number = 8,
                Capacity = 0,
                FlightInStation = null,
                IsLanding = false,
                IsDeparture = true,
                StationWatingTime = 5,

            });
        }
    }
}
