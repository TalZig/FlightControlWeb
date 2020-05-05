using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlightControl.Controllers
{
    public class FlightPlanController : ApiController
    {
        Models.FlightPlanManager FlightPlans = new Models.FlightPlanManager();
/*        // GET: api/FlightPlan
        public IEnumerable<Models.FlightPlan> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET: api/FlightPlan/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FlightPlan
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FlightPlan/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FlightPlan/5
        public void Delete(int id)
        {
        }
    }
}
