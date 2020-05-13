using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightControl.Models
{
    public class ServersManager : IServersManager
    {
        private static SqliteDataBase sqliteDataBase = new SqliteDataBase();
        public bool DeleteServer(string id)
        {
            return sqliteDataBase.DeleteServer(id);
        }
        public IEnumerable<Server> GetServers()
        {
            return sqliteDataBase.GetExternalServers();
        }
        public string AddServer(Server server)
        {
            return sqliteDataBase.AddServer(server);
        }

    }
}