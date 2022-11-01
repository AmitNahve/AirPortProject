using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Log:ILog
    {
        public int? Id { get; set; }
        public IFlight? Flight { get; set; }
        public ILeg? Leg { get; set; }
        public DateTime Time { get; set; }
      
    }
}
