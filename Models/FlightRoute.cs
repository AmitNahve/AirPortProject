using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Models
{
    public class FlightRoute : IFlightRoute
    {
        public List<ILeg>? Legs { get; set; } = new List<ILeg>();

        public IAirPortLogic ? AirPort { get; set; }

        public IEnumerable<ILeg> GetNextStation()
        {
            foreach (var station in Legs!)
            {
                yield return station;
            }



        }
    }
}
