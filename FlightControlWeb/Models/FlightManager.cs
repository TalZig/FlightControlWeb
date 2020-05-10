using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlightControl.Controllers;
namespace FlightControl.Models
{
    public class FlightManager : IFlightManager
    {
        //public static List<Flight> flights = new List<Flight>();
        public void DeleteFlight(int id)
        {
            if (FlightPlanController.FlightsPlans.FlightPlans.ContainsKey(id))
            {
                FlightPlanController.FlightsPlans.FlightPlans.Remove(id);
            }
        }
/*        public void AddFlight(Flight f)
        {
            flights.Add(f);
        }*/
        public List<Flight> Relative_To_Sync(string date)
        {
            List<Flight> flights = new List<Flight>();
            List<FlightPlan> relativeFlights = (List<FlightPlan>)FlightPlanController.FlightsPlans.FlightPlans.Where(x => x.Value.Initial_Location.Date_time.Equals(date));
            if (relativeFlights.Count == 0)
                return flights;
            foreach(FlightPlan f in relativeFlights){
                Flight f1 = new Flight();
                f1.company_name = f.company_name;
                f1.Date_time = f.Initial_Location.Date_time;
                f1.Flight_id = FlightPlanController.FlightsPlans.FlightPlans.FirstOrDefault(x => x.Value.Equals(f)).Key;
                f1.passengers = f.passengers;
                f1.Longtitude = f.Initial_Location.Longtitude;
                f1.Latitude = f.Initial_Location.Latitude;
                f1.Is_external = false;
                flights.Add(f1);
            }
            return flights;
        }
        public List<Flight> Relative_To(string date)
        {
            List<Flight> flights = new List<Flight>();
            List<FlightPlan> relativeFlights = (List<FlightPlan>)FlightPlanController.FlightsPlans.FlightPlans.Where(x => x.Value.Initial_Location.Date_time.Equals(date));
            if (relativeFlights.Count == 0)
                return flights;
            foreach (FlightPlan f in relativeFlights)
            {
                Flight f1 = new Flight();
                f1.company_name = f.company_name;
                f1.Date_time = f.Initial_Location.Date_time;
                f1.Flight_id = FlightPlanController.FlightsPlans.FlightPlans.FirstOrDefault(x => x.Value.Equals(f)).Key;
                f1.passengers = f.passengers;
                f1.Longtitude = f.Initial_Location.Longtitude;
                f1.Latitude = f.Initial_Location.Latitude;
                f1.Is_external = false;
                flights.Add(f1);
            }
            return flights;
        }

    }

}