using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightControl.Models
{
    interface IFlightManager
    {
        void DeleteFlight(string id);

        List<Flight> Relative_To_Sync(DateTime date);

        List<Flight> Relative_To(DateTime date);
    }
}
