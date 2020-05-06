using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightControl.Models
{
    public interface IFlightPlanManager
    {
        void AddFlightPlan(FlightPlan f);

        FlightPlan GetFlightPlanById(string id);
    }
}
