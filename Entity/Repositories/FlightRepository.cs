using Contract;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repositories
{
    internal class FlightRepository : BaseRepository<Flight>, IFlightRepository
    {
        public FlightRepository(AirPortContext context) : base(context)
        {

        }
    }
}
