using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CombinedStations : ICombinedStations
    {
        public List<ILeg>? Stations { get; set; }
        SemaphoreSlim Gate { get; set; } = new SemaphoreSlim(2);
        public CombinedStations(List<ILeg>? stations)
        {
            Stations = stations;

        }
        public async Task VisitStation(IFlight flight)
        {
            await Gate.WaitAsync();
            await VisitAvailableLeg(flight);
            Gate.Release();
        }
        private async Task VisitAvailableLeg(IFlight flight)
        {
            var station = Stations?.FirstOrDefault(s => s.Flight == null);
            await RunInStation(flight, station!);

        }
        public async Task RunInStation(IFlight flight, ILeg leg)
        {
            await leg!.EnterStation(flight);
            Console.WriteLine($" flight in station: {leg!.Number},Flight Code:{leg!.Flight!.FlightCode}");
            await leg.Visit();
            flight.Target = Target.Departure;
            leg.ExitStation();
        }


    }
}
