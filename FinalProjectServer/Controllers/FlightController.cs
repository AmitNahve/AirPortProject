using Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FinalProjectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        IUnitOfWork unitOfWork;

        public FlightController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        // GET: api/<FlightController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var flights = await unitOfWork.Flights.GetAll();
            return Ok(flights);
        }

        // GET api/<FlightController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var flights = unitOfWork.Flights.Get(id);
            return Ok(flights);
        }

        // POST api/<FlightController>
        [HttpPost]
        public IActionResult Post(Flight flight)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Flights.Create(flight);
                unitOfWork.Complete();
                return Created("", flight);
            }
            else
                return BadRequest();
        }


    }
}
