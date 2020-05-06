using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightControl.Models;

namespace FlightControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        public static IFlightManager Flights = new FlightManager();
        // GET: api/Flight
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Flight/5
        [HttpGet("{id}", Name = "GetFC")]
        public string Get(int id)
        {
            return "blabla";
        }

        // POST: api/Flight
        [HttpPost]
        public void Post([FromBody] Flight flight)
        {
        }

        // PUT: api/Flight/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Flights.DeleteFlight(id);
        }
    }
}
