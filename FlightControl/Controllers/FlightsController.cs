using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlightControl.Controllers
{
    public class FlightsController : ApiController
    {
        Models.FlightManager flightManager = new Models.FlightManager();

        // GET: api/Flights
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Flights/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Flights
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Flights/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Flights/5
        public void Delete(int id)
        {
        }
    }
}
