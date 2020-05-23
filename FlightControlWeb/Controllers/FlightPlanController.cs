﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightControl.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http.Extensions;

namespace FlightControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightPlanController : ControllerBase
    {
        private static IFlightPlanManager flightPlanManager;
        public FlightPlanController(IFlightPlanManager iFlightPlanManager)
        {
            flightPlanManager = iFlightPlanManager;
        }
        // GET: api/FlightPlan/5
        [HttpGet("{id}", Name = "GetFlightPlan")]
        public async Task<ActionResult> GetFlightPlan(string id)
        {
            FlightPlan flightPlan;
            string urlRequest = Request.Path;
            string patternAndSync = @"^/api/FlightPlan/[a-zA-Z]{2}[0-9]{5}[a-zA-Z]{3}&sync_all$";
            string patternWithoutSync = @"^/api/FlightPlan/[a-zA-Z]{2}[0-9]{5}[a-zA-Z]{3}$";
            if (Regex.IsMatch(urlRequest, patternAndSync))
            {
                id = id.Substring(0, 10);
                flightPlan = await flightPlanManager.GetFlightPlanByIdAndSync(id);
            }
            else if (Regex.IsMatch(urlRequest, patternWithoutSync))
            {
                flightPlan = flightPlanManager.GetFlightPlanById(id);
            }
            else
            {
                return BadRequest();
            }
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
    }
}
