using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightControl.Models
{
    public class FlightPlanManager : IFlightPlanManager
    {
        public List<FlightPlan> FlightPlans = new List<FlightPlan>();
        public void init()
        {
            FlightPlans.Add(new FlightPlan());
            FlightPlans[0].company_name = "swiss";
            FlightPlans[0].passengers = 20;
            
        }
        

/*        public void DeleteFlightPlan(string id)
        {
            FlightPlan FlightPlan = FlightPlans.Where(x => x.flight.Flight_id.Equals(id)).FirstOrDefault();
            if (FlightPlan != null)
            {
                FlightPlans.Remove(FlightPlan);
            }
        }*/
        public void AddFlightPlan(FlightPlan f)
        {
            FlightPlans.Add(f);
        }
        public FlightPlan GetFlightPlanById(string id)
        {
            return FlightPlans.Where(x => x.flight.Flight_id.Equals(id)).FirstOrDefault();
        }

    }
}