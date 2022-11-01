using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface ILog
    {
        public int? Id { get; set; }
        public IFlight? Flight { get; set; }
        public ILeg? Leg { get; set; }
        public DateTime Time { get; set; }
    }
}

