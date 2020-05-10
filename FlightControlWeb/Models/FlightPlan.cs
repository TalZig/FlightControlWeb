using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.Json.Serialization;
public struct Segments
{
    public double longtitude { get; set; }
    public double latitude { get; set; }
    public long timespan_seconds { get; set; }
}
public struct Initial_location
{
    
    public double Longtitude { get; set; }
    public double Latitude { get; set; }
    [JsonPropertyName("date_time")]
    public String Date_time { get; set; }
}

namespace FlightControl.Models
{
    public class FlightPlan
    {
/*        [JsonPropertyName("flight")]
        public Flight flight { get; set; }*/
        [JsonPropertyName("passengers")]
        public int passengers { get; set; }
        [JsonPropertyName("company_name")]
        public string company_name { get; set; }

        [JsonPropertyName("initial_location")]
        public Initial_location Initial_Location { get; set; }
        [JsonPropertyName("segments")]
        public List<Segments> segments{ get; set; }
    }


}