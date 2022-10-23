using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Log
    {
        public int Id { get; set; }
        public Flight? Flight { get; set; }
        public Leg? Leg { get; set; }
       // public DateTime CurrenTime { get; set; }
    }
}
