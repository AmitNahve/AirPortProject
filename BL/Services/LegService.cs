using Models;
using Shared;
using Shared.ContextRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class LegService : ILegService
    {
        IUnitOfWork unitOfWork;
        

        public List<ILeg> Stations = new List<ILeg>(); 
        public LegService(IUnitOfWork unitOfWork)
        {

            this.unitOfWork = unitOfWork;
            StationsStarter();

        }

        private void StationsStarter()
        {
            Leg station1 = new Leg { Id = 1, NextLegNumber = 2, LegNumber = 1, StationWatingTime = 3 };
            Leg station2 = new Leg { Id = 2, NextLegNumber = 3, LegNumber = 2, StationWatingTime = 3 };
            Leg station3 = new Leg { Id = 3, NextLegNumber = 4, LegNumber = 3, StationWatingTime = 3 };
            Leg station4 = new Leg { Id = 4, NextLegNumber = 5, LegNumber = 4, StationWatingTime = 3 };
            Leg station5 = new Leg { Id = 5, NextLegNumber = 6, LegNumber = 5, StationWatingTime = 3 };
            Leg station6 = new Leg { Id = 6, NextLegNumber = 8, LegNumber = 6, StationWatingTime = 5 };
            Leg station7 = new Leg { Id = 7, NextLegNumber = 8, LegNumber = 7, StationWatingTime = 5 };
            Leg station8 = new Leg { Id = 8, NextLegNumber = 4, LegNumber = 8, StationWatingTime = 3 };
            Leg station9 = new Leg { Id = 9, NextLegNumber = 4, LegNumber = 9, StationWatingTime = 2 };

           Stations.Add(station1);
           Stations.Add(station2);
           Stations.Add(station3);
           Stations.Add(station4);
           Stations.Add(station5);
           Stations.Add(station6);
           Stations.Add(station7);
           Stations.Add(station8);
           Stations.Add(station9);
            //unitOfWork.Legs.Create(station1);
            //unitOfWork.Legs.Create(station2);
            //unitOfWork.Legs.Create(station3);
            //unitOfWork.Legs.Create(station4);
            //unitOfWork.Legs.Create(station5);
            //unitOfWork.Legs.Create(station6);
            //unitOfWork.Legs.Create(station7);
            //unitOfWork.Legs.Create(station8);
            //unitOfWork.Legs.Create(station9);
            //unitOfWork.Complete();
        }

        //        public void MoveFlightsInStations(Flight flight)// list of flights
        //        {


        //            if (flight.Target == Target.Landing)
        //            {

        //                CheckTheStationsStatus(flight, station1);
        //                WaitInStation(station1);//wating in the station
        //                CheckTheStationsStatus(flight, station2);
        //                MoveThePlaneFromTheStation(station1);

        //                WaitInStation(station2);//wating in the station
        //                CheckTheStationsStatus(flight, station3);
        //                MoveThePlaneFromTheStation(station2);

        //                WaitInStation(station3);//wating in the station
        //                CheckTheStationsStatus(flight, station4);
        //                MoveThePlaneFromTheStation(station3);

        //                WaitInStation(station4);//wating in the station
        //                CheckTheStationsStatus(flight, station5);
        //                MoveThePlaneFromTheStation(station4);
        //                WaitInStation(station5);//wating in the station

        //            }
        //            if (flight.Target == Target.Departure)
        //            {
        //                if (CheckIfStationIsEmpty(station6))
        //                {
        //                    CheckTheStationsStatus(flight, station6);
        //                    WaitInStation(station6);//wating in the station
        //                    CheckTheStationsStatus(flight, station8);
        //                    MoveThePlaneFromTheStation(station6);
        //                    WaitInStation(station8);//wating in the station
        //                }
        //                if (CheckIfStationIsEmpty(station7))
        //                {
        //                    CheckTheStationsStatus(flight, station7);
        //                    WaitInStation(station7);//wating in the station
        //                    CheckTheStationsStatus(flight, station8);
        //                    MoveThePlaneFromTheStation(station7);
        //                    WaitInStation(station8);//wating in the station
        //                    if (CheckIfStationIsEmpty(station4))
        //                    {
        //                        CheckTheStationsStatus(flight, station4);
        //                        WaitInStation(station4);//wating in the station
        //                        CheckTheStationsStatus(flight, station9);
        //                    }
        //                }
        //            }

        //        }

        //        private void MoveThePlaneFromTheStation(Leg station)
        //        {
        //            stations.FirstOrDefault(station)!.Flight = null;
        //        }

        //        private void WaitInStation(Leg station)
        //        {
        //            Thread.Sleep(station.StationWatingTime * 1000);
        //        }

        //        private void CheckTheStationsStatus(Flight flight, Leg station)
        //        {
        //            var stationNumber = stations.FirstOrDefault(station)!.Number;
        //            var isVisitedOnStation4 = stations.FirstOrDefault(station)!.Flight!.IsVisitedOnStation4;
        //            if (CheckIfStationIsEmpty(station))
        //                PutPlaneInTheStation(flight, station);
        //            if (isVisitedOnStation4 == true && flight.Target == Target.Departure)
        //            {
        //                CheckTheStationsStatus(flight, station9);
        //                //do that plane move to station 9
        //            }
        //            if (stationNumber == 9)
        //            {
        //                MoveThePlaneFromTheStation(station9);
        //            }
        //            if (stationNumber == 4)
        //                stations.FirstOrDefault(station)!.Flight!.IsVisitedOnStation4 = true;
        //        }

        //        private void PutPlaneInTheStation(Flight flight, Leg station)
        //        {
        //            stations.FirstOrDefault(station)!.Flight = flight;
        //        }

        //        private bool CheckIfStationIsEmpty(Leg station)
        //        {
        //            return stations.FirstOrDefault(station)!.Flight == null;
        //        }
        public IEnumerable<LegStatus> GetStatus()
        {
            return Stations.Select(l => new LegStatus { LegId = l.Id, FlightCode = l.Flight?.FlightCode }) ;
        }

        public IEnumerable<ILeg> GetLegs()
        {
            return Stations;
        }
    }
}
