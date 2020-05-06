using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightControl.Models
{
    public interface IFlightManager
    {
        void DeleteFlight(int id);

        List<Flight> Relative_To_Sync(DateTime date);

        List<Flight> Relative_To(DateTime date);
    }
}
