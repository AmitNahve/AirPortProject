using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Log
    {
        public int LogId { get; set; }
        ICollection<Flight>? Flights { get; set; }
    }
}
