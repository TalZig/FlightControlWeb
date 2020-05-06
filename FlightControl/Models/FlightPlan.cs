using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.Json.Serialization;
public struct Segments
{
    public double Longtitude { get; set; }
    public double Latitude { get; set; }
    public long Timespan_seconds { get; set; }
}

namespace FlightControl.Models
{
    public class FlightPlan
    {
        [JsonPropertyName("flight")]
        public Flight flight { get; set; }
        [JsonPropertyName("passengers")]
        public int passengers { get; set; }
        [JsonPropertyName("company_name")]
        public string company_name { get; set; }
        public struct Initial_location
        {
            public double Longtitude { get; set; }
            public double Latitude { get; set; }
            public DateTime Date_time { get; set; }
        }
        public List<Segments> Segments { get; set; }
    }


}