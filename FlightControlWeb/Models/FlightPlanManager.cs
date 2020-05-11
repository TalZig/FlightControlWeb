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
        private static SqliteDataBase sqliteDataBase = new SqliteDataBase();
        public string AddFlightPlan(FlightPlan flightPlan)
        {
            return sqliteDataBase.AddFlightPlan(flightPlan);
        }

        public FlightPlan GetFlightPlanById(string id)
        {
            return sqliteDataBase.GetFlightPlanById(id);
        }

        public bool DeleteFlightPlanById(string id)
        {
            return sqliteDataBase.DeleteFlightPlanFromTable(id);
        }

    }
}