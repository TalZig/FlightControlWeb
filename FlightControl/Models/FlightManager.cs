using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightControl.Models
{
    public class FlightManager : IFlightManager
    {
        private static List<Flight> flights = new List<Flight>();
        public void DeleteFlight(string id)
        {
            Flight flight = flights.Where(x => x.Flight_id.Equals(id)).FirstOrDefault();
            if(flight != null)
            {
                flights.Remove(flight);
            }
        }
        public List<Flight> Relative_To_Sync(DateTime date)
        {
            List<Flight> relativeFlights = (List<Flight>) flights.Where(x => x.Date_time.Equals(date));
            return relativeFlights;
        }
        public List<Flight> Relative_To(DateTime date)
        {
            List<Flight> relativeFlights = (List<Flight>)flights.Where(x => x.Date_time.Equals(date) && x.Is_external == false);
            return relativeFlights;
        }

    }

}