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
    public class ServerController : ControllerBase
    {
        public static ServersManger servers = new ServersManger();
        // GET: api/Server
        [HttpGet]
        public IEnumerable<Server> Get()
        {
            return servers.getServers();
        }

        // GET: api/Server/5
        [HttpGet("{id}", Name = "GetS")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Server
        [HttpPost]
        public void Post([FromBody] Server value)
        {
            servers.addServer(value);
        }

        // PUT: api/Server/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            servers.DeleteServer(id);
        }
    }
}
