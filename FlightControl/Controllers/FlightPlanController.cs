﻿using System;
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
        FlightPlanManager FlightsPlans = new Models.FlightPlanManager();
        // GET: api/FlightPlan
        [HttpGet]
        public JsonResult Get()
        {
            FlightsPlans.init();
            return new JsonResult(FlightsPlans.FlightPlans[0]);
        }

        // GET: api/FlightPlan/5
        [HttpGet("{id}", Name = "GetFPC")]
        public JsonResult Get(string id)
        {
            return new JsonResult(FlightsPlans.GetFlightPlanById(id));
        }

        // POST: api/FlightPlan
        [HttpPost]
        public void Post([FromBody] FlightPlan value)
        {
            FlightsPlans.AddFlightPlan(value);
        }

        // PUT: api/FlightPlan/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Flight flight)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
