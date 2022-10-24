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
       
        public int Id { get; set; }
        public string? FlightCode { get; set; }
        public int PassengersCount { get; set; }
        public bool Ciritical { get; set; }
        
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

        
        public Flight()
        {
            FlightCode = Guid.NewGuid().ToString();
        }
    }


}
