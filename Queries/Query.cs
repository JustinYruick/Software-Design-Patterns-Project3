using System;

namespace Assi3
{
    //query interface 
    interface Query
    {
      //visitor method to check if server is busy
       public bool ServerBusy(Server server);
    }
}
