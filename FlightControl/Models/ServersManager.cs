using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightControl.Models
{
    public class ServersManager :IServersManager
    {
        private static List<Server> Servers = new List<Server>();
        public void DeleteServer(string id)
        {
            Server Server1= Servers.Where(x => x.ServerId.Equals(id)).FirstOrDefault();
            if (Server1 != null)
            {
                Servers.Remove(Server1);
            }
        }
        public List<Server> getServers()
        {
            return Servers;
        }
        public void addServer(Server s)
        {
            Servers.Add(s);
        }

    }
}