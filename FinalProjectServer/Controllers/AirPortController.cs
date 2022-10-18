using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

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
        // GET: api/<AirPortController>
        [HttpGet]
        public ActionResult<Flight> Get()
        {
            return Ok(new List<Flight> { new Flight(), new Flight() });
        }

        // GET api/<AirPortController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return airPortLogic.Start();
        }

        // POST api/<AirPortController>
        [HttpPost]
        public void Post(Flight value)
        {
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
