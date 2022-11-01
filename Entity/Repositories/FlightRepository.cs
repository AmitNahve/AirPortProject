using Models;
using Shared;
using Shared.ContextRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repositories
{
    internal class FlightRepository : BaseRepository<IFlight>, IFlightRepository
    {
        public FlightRepository(AirPortContext context) : base(context)
        {

        }
    }
}
