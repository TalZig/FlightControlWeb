using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.Json.Serialization;

namespace FlightControl.Models
{
    public class Flight
    {
        public double Longtitude { get; set; }
        public double Latitude { get; set; }

        //jsonPropertyNames[("passengers")]
        public int passengers { get; set; }
        public string company_name { get; set; }
        public int Flight_id { get; set; }
        public bool Is_external { get; set; }
        public DateTime Date_time { get; set; }




    }
}