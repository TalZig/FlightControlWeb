using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightControl.Models
{
    public class Flight
    {
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
        public int Passengers { get; set; }
        public string Company_name { get; set; }
        public string Flight_id { get; set; }
        public bool Is_external { get; set; }
        public DateTime Date_time { get; set; }




    }
}