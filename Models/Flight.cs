using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Models
{

    public class Flight : IFlight
    {
        //[Key]
        public int Id { get; set; }
        public string? FlightCode { get; set; }
        public int PassengersCount { get; set; }
        public bool Ciritical { get; set; }
        //[ForeignKey("Leg")]
        //public int? LegId { get; set; }
        public ILeg? Leg { get; set; }
        public bool IsVisitedOnStation4 { get; set; }
        public Target Target { get; set; }

        public void Start(IFlightRoute flightRoute)
        {
            Task.Run(() => RunFlight(flightRoute));

        }

        private void RunFlight(IFlightRoute flightRoute)
        {
            foreach (var station in flightRoute.GetNextStation())
            {
                station.EnterStation(this);
                Console.WriteLine($" flight in station: {station.Number},Flight Code:{station.Flight?.FlightCode}");
                Thread.Sleep(station.StationWatingTime * 1000);
                station.ExitStation();
            }
            Console.WriteLine($"flight ended. Flight Code:{this.FlightCode}");
        }

        //public int Id { get; set; }
        //public string Code { get; set; }
        //public bool IsLanding { get; set; }
        //public bool IsPending { get; set; }
        //public bool IsDeparture { get; set; }
        //public DateTime SubmissionTime { get; set; }
        //public bool? TimerFinished { get; set; }
        //public Leg? CurrenLeg { get; set; }
        //public virtual ICollection<LiveUpdate> LiveUpdates { get; set; }
        //public virtual ICollection<Station> Stations { get; set; }
        public Flight()
        {
            FlightCode = Guid.NewGuid().ToString();
        }
    }


}
