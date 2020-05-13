using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightControl.Models;
using System.Text.RegularExpressions;

namespace FlightControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private IFlightManager flightManager = new FlightManager();
        // GET: api/Flights/5
        [HttpGet]
        public ActionResult<Flights> Get([FromQuery] string relative_To)
        {
            string urlRequest = Request.QueryString.Value;
            string date = relative_To.Substring(1, 20);
            IEnumerable<Flights> flightList = new List<Flights>();
            if (urlRequest.Contains("sync_all"))
            {
                flightList = flightManager.GetFlightsByDateTimeAndSync(date);
            }
            else
            {
                flightList = flightManager.GetFlightsByDateTime(date);
            }
            if (flightList == null) { return NotFound(flightList); }
            return Ok(flightList);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (flightManager.DeleteFlightById(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        // POST: api/Flight
        [HttpPost]
        public void Post([FromBody] Flights flight)
        {
        }

        // PUT: api/Flight/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
