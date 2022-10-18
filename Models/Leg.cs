using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Leg
    {
        //Number, Capacity, Landing/Departure/Both , CrossingTime (seconds)
        public int LegId { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public Flight? FlightInStation { get; set; }
        public bool IsLanding { get; set; }
        public bool IsDeparture { get; set; }
        //public bool IsBoth { get; set; }
        public int StationWatingTime { get; set; }
    }
}
