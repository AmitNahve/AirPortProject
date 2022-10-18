using Contract;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repositories
{
    internal class LogRepository : BaseRepository<Log>, ILogRepository
    {
        public LogRepository(AirPortContext context) : base(context)
        {

        }
    }
}
