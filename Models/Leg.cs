using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Leg : ILeg
    {
        //[Key]
        public int Id { get; set; }
        public int Number { get; set; }
        //[ForeignKey("Flight")]
        public int? FlightId { get; set; }
        public IFlight? Flight { get; set; }
        public Target Target { get; set; }
        public int StationWatingTime { get; set; }
        public int NextLegNumber { get; set; }
        SemaphoreSlim gate = new SemaphoreSlim(1);
        public async Task EnterStation(IFlight flight)
        {
            if(Flight == null)
            Flight = flight;
            else
            {
                await gate.WaitAsync();
                Flight = flight;
                gate.Release();

            }
        }

        public void ExitStation()
        {
            Flight = null;
        }

        // //Number, Capacity, Landing/Departure/Both , CrossingTime (seconds)
        // public int Id { get; set; }
        // public int Number { get; set; }
        // public int Capacity { get; set; }
        // //[ForeignKey("Flight")]
        // //public int FlightyId { get; set; }
        //// public Flight? FlightInStation { get; set; }
        // public bool IsLanding { get; set; }
        // public bool IsDeparture { get; set; }
        // //public bool IsWating { get; set; }
    }
}
