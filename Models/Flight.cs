using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Flight
    {
        // number, passengers count, IsCritical, Brand, CurrentLeg, Landing/Departure
        public int FlightId { get; set; }
        public int Passengers { get; set; }
        public string Code { get; set; }
        public Leg? CurrentLeg { get; set; }
        public bool IsLanding { get; set; }
        public bool IsDeparture { get; set; }

        public Flight() => Code = Guid.NewGuid().ToString();
    }
}
