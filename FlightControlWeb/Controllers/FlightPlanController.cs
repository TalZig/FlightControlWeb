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
    public class FlightPlanController : ControllerBase
    {
        private static IFlightPlanManager flightPlanManager = new FlightPlanManager();
        // GET: api/FlightPlan/5
        [HttpGet("{id}", Name = "GetFlightPlan")]
        public ActionResult GetFlightPlan([FromQuery]string id)
        {
            FlightPlan flightPlan = flightPlanManager.GetFlightPlanById(id);
            if (flightPlan != null)
            {
                return Ok(flightPlan);
            }
            return NotFound(flightPlan);
        }

        // POST: api/FlightPlan
        [HttpPost]
        public ActionResult Post([FromBody] FlightPlan flightPlan)
        {
            string idOfAddedFlightPlan = flightPlanManager.AddFlightPlan(flightPlan);
            return CreatedAtAction(actionName: "GetFlightPlan", new { id = idOfAddedFlightPlan }, flightPlan);
        }

        // DELETE: api/FlightPlan/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (flightPlanManager.DeleteFlightPlanById(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/FlightPlan/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Flight flight)
        {

        }
    }
}
