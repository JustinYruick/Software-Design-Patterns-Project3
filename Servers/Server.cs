using System;

namespace Assi3
{
    
    //Concrete server class
    class Server : AbstractServer
    {
        public Request Request = null;

        //accepts a refernce of the visitor an checks if the server is busy
        public bool Accept(ServerQuery serverQuery)
        {
            return serverQuery.ServerBusy(this);
        }

        //sets a request
        public void takeRequest(Request request)
        {
            Request = request;
        }

        //removes a request
        public void RemoveRequest()
        {
            Request = null;
        }

        //executes the request by calling reaquest.execute
        public int executeRequest()
        {
            return Request.Execute();
        }
    }
}
