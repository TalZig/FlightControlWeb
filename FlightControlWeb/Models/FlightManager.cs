using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using FlightControl.Controllers;
namespace FlightControl.Models
{
    public class FlightManager : IFlightManager
    {
        private SqliteDataBase sqliteDataBase = new SqliteDataBase();
        public bool DeleteFlightById(string id)
        {
            return sqliteDataBase.DeleteFlightPlanFromTable(id);
        }

        public IEnumerable<Flight> GetFlightsByDateTime(string dateTime)
        {
            return sqliteDataBase.GetFlightsByDateTime(dateTime);
        }

        public IEnumerable<Flight> GetFlightsByDateTimeAndSync(string dateTime)
        {
            return sqliteDataBase.GetFlightsByDateTimeAndSync(dateTime);
        }

    }

}