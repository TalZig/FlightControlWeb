using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightControl.Models
{
    public interface IServersManager
    {
        void DeleteServer(string id);

        List<Server> getServers();

        void addServer(Server s);
    }
}
