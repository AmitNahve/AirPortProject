using BL.Services;
using Contract;
using Models;
using Shared;
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
        private readonly List<IFlight> flights = new(); 
        public AirPortLogic(IUnitOfWork unitOfWork, ILegService legService)
        {
            this.unitOfWork = unitOfWork;
            this.legService = legService;
        }

        public Task AddNewFlight(IFlight flight)
        {
            //unitOfWork.Flights.Create(flight);
            //unitOfWork.Complete();
            StartFlight(flight);
            return Task.CompletedTask;
        }

        private void StartFlight(IFlight flight)
        {
           flights.Add(flight);
            var flightRoute = CreateRoute(flight.Target);
            flightRoute.AirPort = this;
            flight.Start(flightRoute);
        }

        private IFlightRoute CreateRoute( Target target)
        {
            var stations = legService.GetLegs();
            var path = new FlightRoute();
            if(target == Target.Landing)
            {
                return LandingRouteStarter(stations, path);
            }
            
            return DepartureRouteStarter(stations, path);

        }

        private IFlightRoute DepartureRouteStarter(IEnumerable<ILeg> stations, IFlightRoute path)
        {
            var leg6 = stations.FirstOrDefault(s => s.Number == 6);
            var leg7 = stations.FirstOrDefault(s => s.Number == 7);
            var leg8 = stations.FirstOrDefault(s => s.Number == 8);
            var leg4 = stations.FirstOrDefault(s => s.Number == 4);
            var leg9 = stations.FirstOrDefault(s => s.Number == 9);
            path.Legs?.Add(leg6!);
            path.Legs?.Add(leg7!);
            path.Legs?.Add(leg8!);
            path.Legs?.Add(leg4!);
            path.Legs?.Add(leg9!);
            return path;
        }

        private static IFlightRoute LandingRouteStarter(IEnumerable<ILeg> stations, IFlightRoute path)
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
                path.Legs?.Add(leg1!);
                path.Legs?.Add(leg2!);
                path.Legs?.Add(leg3!);
                path.Legs?.Add(leg4!);
                path.Legs?.Add(leg5!);
                path.Legs?.Add(leg6!);
                path.Legs?.Add(leg7!);
                path.Legs?.Add(leg8!);
                path.Legs?.Add(leg9!);
            return path;
        }

        //public  Task<IEnumerable<Flight>> GetPendingFlightsByOrder(bool IsLanding)
        //{
        //    // need to order this
        //    var flights = unitOfWork.Flights.GetAll();
        //    return  flights;
        //}

        //public Task StartApp()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task StartSimulator(int numOfFlights)
        //{
        //    throw new NotImplementedException();
        //}

        public AirPortStatus GetStatus()
        {
            var status = new AirPortStatus();
            status.Stations.AddRange(legService.GetStatus());
            return status;
        }
    }
}
