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
        public List<FlightPlan> FlightPlans = new List<FlightPlan>();
        public void init()
        {
            FlightPlans.Add(new FlightPlan());
            //FlightPlans[0].company_name = "swiss";
            FlightPlans[0].passengers = 50;
            FlightPlans[0].flight = new Flight();
            FlightPlans[0].flight.Flight_id = "0";
            j++;
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
        public void AddFlightPlan(string json)
        {
/*            FlightPlan obj = new FlightPlan();
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            obj = (FlightPlan)serializer.ReadObject(ms);
            Console.WriteLine("check");
            ms.Close();*/
            FlightPlan newF = JsonConvert.DeserializeObject<FlightPlan>(json);
            FlightPlans.Add(newF);
        }
        public FlightPlan GetFlightPlanById(string id)
        {
            return FlightPlans.Where(x => x.flight.Flight_id.Equals(id)).FirstOrDefault();
        }

    }
}