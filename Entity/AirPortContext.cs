using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AirPortContext : DbContext
    {
       
        public AirPortContext(DbContextOptions<AirPortContext> options) : base(options)
        {
           
        }
        public DbSet<Flight>? Flights { get; set; }
        public DbSet<Leg>? Legs { get; set; }
        public DbSet<Log>? Logs { get; set; }
       
    }
}
