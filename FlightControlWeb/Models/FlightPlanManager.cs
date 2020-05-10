using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace FlightControl.Models
{
    public class FlightPlanManager : IFlightPlanManager
    {
        public int j = 0;
        public Dictionary<int,FlightPlan> FlightPlans = new Dictionary<int, FlightPlan>();
        public void init()
        {
            FlightPlans.Add(0, new FlightPlan());
            //FlightPlans[0].company_name = "swiss";
            FlightPlans[0].passengers = 50;
/*            FlightPlans[0].flight = new Flight();
            FlightPlans[0].flight.Flight_id = "0";*/
            j++;
        }

         public void DeleteFlightPlan(int id)
         {
            if(FlightPlans.ContainsKey(id))
                FlightPlans.Remove(id);
         }
        public void AddFlightPlan(FlightPlan f)
        {
            Random random = new Random();
            int r = random.Next(0, 1000000);
            while (FlightPlans.ContainsKey(r))
                r = random.Next(0, 1000000);
            FlightPlans.Add(r, f);
        }
        public FlightPlan GetFlightPlanById(int id)
        {
            return FlightPlans[id];
        }

    }
}