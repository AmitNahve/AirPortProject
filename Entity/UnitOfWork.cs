using Entity.Repositories;
using Shared.ContextRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly AirPortContext context;
        IFlightRepository? flightRepository;
        ILegRepository? legRepository;
        ILogRepository? logRepository;
      
        public UnitOfWork(AirPortContext context)
        {
            this.context = context;
        }
        public IFlightRepository Flights
        {
            get
            {
                if (flightRepository == null) flightRepository = new FlightRepository(context);
                return flightRepository;
            }
        }
        public ILegRepository Legs
        {
            get
            {
                if (legRepository == null) legRepository = new LegRepository(context);
                return legRepository;
            }
        }

        public ILogRepository Logs
        {
            get
            {
                if (logRepository == null) logRepository = new LogRepository(context);
                return logRepository;
            }
        }

    

        public void Complete()
        {
            context.SaveChanges();
        }
    }
}
