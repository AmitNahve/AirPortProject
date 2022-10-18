using Contract;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repositories
{
    internal class LegRepository : BaseRepository<Leg>, ILegRepository
    {
        public LegRepository(AirPortContext context) : base(context)
        {

        }
    }
}
