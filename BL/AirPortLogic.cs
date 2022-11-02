using BL.Services;
using Models;
using Shared;
using Shared.ContextRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AirPortLogic : IAirPortLogic
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILegService legService;
        private readonly List<ILog> logList = new();


        private readonly List<IFlight> flights = new();
        public AirPortLogic(IUnitOfWork unitOfWork, ILegService legService)
        {
            this.unitOfWork = unitOfWork;
            this.legService = legService;
        }

        public async Task AddNewFlight(IFlight flight)
        {
            //unitOfWork.Flights.Create(flight);
            //unitOfWork.Complete();
            await StartFlight(flight);

        }

        private async Task StartFlight(IFlight flight)
        {
            flights.Add(flight);
            //logList.Add(new Log{ Flight = flight , Leg = flight.Leg, Time = DateTime.Now});
            Console.WriteLine(flights.Count);
            var stations = legService.GetLegs();
            // var path = new FlightRoute();
           
                await StartLanding(stations, flight);
            flights.Remove(flight);
          

        }



        private async Task StartDeparture(IEnumerable<ILeg> stations, IFlight flight)
        {


            var leg6 = stations.FirstOrDefault(s => s.Number == 6);
            var leg7 = stations.FirstOrDefault(s => s.Number == 7);
            var leg8 = stations.FirstOrDefault(s => s.Number == 8);
            var leg4 = stations.FirstOrDefault(s => s.Number == 4);
            var leg9 = stations.FirstOrDefault(s => s.Number == 9);
            ICombinedStations combinedStations = new CombinedStations(new List<ILeg> { leg6!, leg7! });
            await combinedStations.VisitStation(flight);
            await RunInStation(flight, leg8);
            await RunInStation(flight, leg4);
            await RunInStation(flight, leg9);
            Console.WriteLine($"flight ended. Flight Code:{flight.FlightCode}");
        }
        private async Task StartLanding(IEnumerable<ILeg> stations, IFlight flight)
        {
            var leg1 = stations.FirstOrDefault(s => s.Number == 1);
            var leg2 = stations.FirstOrDefault(s => s.Number == 2);
            var leg3 = stations.FirstOrDefault(s => s.Number == 3);
            var leg4 = stations.FirstOrDefault(s => s.Number == 4);
            var leg5 = stations.FirstOrDefault(s => s.Number == 5);
            var leg6 = stations.FirstOrDefault(s => s.Number == 6);
            var leg7 = stations.FirstOrDefault(s => s.Number == 7);
            var leg8 = stations.FirstOrDefault(s => s.Number == 8);
            var leg9 = stations.FirstOrDefault(s => s.Number == 9);
            await RunInStation(flight, leg1);
            await RunInStation(flight, leg2);
            await RunInStation(flight, leg3);
            await RunInStation(flight, leg4);
            await RunInStation(flight, leg5);
            ICombinedStations combinedStations = new CombinedStations(new List<ILeg> { leg6!, leg7! });
            await combinedStations.VisitStation(flight);
            await RunInStation(flight, leg8);
            await RunInStation(flight, leg4);
            await RunInStation(flight, leg9);
            Console.WriteLine($"flight {flight.Target}. Flight Code:{flight.FlightCode} ");
        }

        public async Task RunInStation(IFlight flight, ILeg? leg)
        {
            await leg!.EnterStation(flight);
            logList.Add(new Log { Flight = flight, Leg = leg, Time = DateTime.Now });
            Console.WriteLine($" flight in station: {leg.Number},Flight Code:{leg.Flight?.FlightCode}");
            await leg.Visit();
            leg.ExitStation();
        }



        public List<LegStatus> GetStatus()
        {
            var status = new AirPortStatus();
            status.Stations.AddRange(legService.GetStatus());
            return status.Stations;
        }

        public List<IFlight> GetFlights()
        {
            Console.WriteLine(flights.Count);
            return flights;
        }

        public List<ILog> GetLog()
        {
            Console.WriteLine($"Log list{logList.Count}");
            return logList;
        }
    }
}
