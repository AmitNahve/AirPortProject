using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Shared;

namespace FinalProjectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirPortController : ControllerBase
    {
        private readonly IAirPortLogic airPortLogic;
        public AirPortController(IAirPortLogic airPortLogic)
        {
            this.airPortLogic = airPortLogic;
        }
        //// GET: api/<AirPortController>
        //[HttpGet]
        //[Route("AddLandingFlight")]
        //public ActionResult<Flight> AddLandingFlight()
        //{
        //    airPortLogic.AddNewFlight(new Flight { Target = Target.Landing });
        //    return Ok();
        //}
        //[HttpGet]
        //[Route("AddDepartureFlight")]
        //public ActionResult<Flight> AddDepartureFlight()
        //{
        //    airPortLogic.AddNewFlight(new Flight { Target = Target.Departure });
        //    return Ok();
        //}
        [HttpGet]
        [Route("GetStatus")]
        public List<LegStatus> GetStatus()
        {
          
            return airPortLogic.GetStatus();
        }
        [HttpGet]
        [Route("GetFlights")]
        public List<IFlight> GetFlights()
        {
            
          
            return airPortLogic.GetFlights();
        }
        [HttpGet]
        [Route("GetLog")]
        public List<ILog> GetLog()
        {
            
          
            return airPortLogic.GetLog();
        }

        // GET api/<AirPortController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Start";
        }

        // POST api/<AirPortController>
        [HttpPost]
        [Route("AddLandingFlight")]
        public void Post(Flight flight)
        {
            airPortLogic.AddNewFlight(flight);
        }

        // PUT api/<AirPortController>/5
        [HttpPut("{id}")]
        public void Put(int id, Flight value)
        {
        }

        // DELETE api/<AirPortController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
