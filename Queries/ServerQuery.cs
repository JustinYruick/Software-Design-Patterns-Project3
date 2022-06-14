using System;

namespace Assi3
{
    //query interface acts as visistor
    class ServerQuery : Query
    {
        //visitor method to check if server is busy
        public bool ServerBusy(Server server)
        {
            if (server.Request == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
